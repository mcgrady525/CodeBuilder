using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    public class ProcAddGenerator
    {
        private string m_ProcName;
        private string m_TableName;
        private List<ColumnInfo> m_ColumnList;
        
        private List<ColumnInfo> m_InParaColumnList;
        private List<ColumnInfo> m_OutParaColumnList;
        private List<ColumnInfo> m_InOutParaColumnList;

        public ProcAddGenerator(string procName, string tableName, List<ColumnInfo> columnList)
        {
            m_ProcName = procName;
            m_TableName = tableName;
            m_ColumnList = columnList;

            SortParaColumns();
        }

        public string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            //注释
            sb.AppendLine();
            sb.AppendLine("/*");
            sb.AppendLine("功能: 新增一条记录");
            sb.AppendLine("*/");

            //过程头
            sb.AppendLine(String.Format("CREATE PROCEDURE [dbo].[{0}]", m_ProcName));
            foreach (ColumnInfo column in m_InParaColumnList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(8) + CodeHelper.GetProcParaString(column) + ",");
            }
            foreach (ColumnInfo column in m_OutParaColumnList)
            {
                if (column.TypeName.ToLower() == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + "@New" + column.Name  + " timestamp output,");
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + CodeHelper.GetProcParaString(column) + " output,");
                }
            }
            foreach (ColumnInfo column in m_InOutParaColumnList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(8) + CodeHelper.GetProcParaString(column) + ",");
            }
            sb.Remove(sb.Length - (Environment.NewLine.Length + 1), 1);

            sb.AppendLine("AS");
            sb.AppendLine();
            sb.AppendLine("SET NOCOUNT ON");
            sb.AppendLine();

            //得到输出参数
            if (CodeHelper.ContainColumn(m_OutParaColumnList, "Id"))
            {
                sb.AppendLine("Select @Id=isnull(Max(Id),0)+1 From " + m_TableName);
            }
            if (CodeHelper.ContainColumn(m_OutParaColumnList, "CodePinyin"))
            {
                sb.AppendLine("Exec usp_00001_CreateCodeChinese 1,@Name,@CodePinyin OUTPUT");
            }
            if (CodeHelper.ContainColumn(m_OutParaColumnList, "CodeWubi"))
            {
                sb.AppendLine("Exec usp_00001_CreateCodeChinese 2,@Name,@CodeWubi OUTPUT");
            }
            if (CodeHelper.ContainColumn(m_OutParaColumnList, "CreateTime"))
            {
                sb.AppendLine("Select @CreateTime=getdate()");
            }
            if (CodeHelper.ContainColumn(m_OutParaColumnList, "ModifyTime"))
            {
                sb.AppendLine("Select @ModifyTime=getdate()");
            }

            //Insert语句
            sb.AppendLine();
            sb.AppendLine(String.Format("INSERT INTO [dbo].[{0}] (", m_TableName));
            foreach (ColumnInfo column in m_ColumnList)
            {
                if (column.TypeName.ToLower() != "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("[{0}],", column.Name));
                }
            }
            sb.Remove(sb.Length - (Environment.NewLine.Length + 1), 1);
            sb.AppendLine(") VALUES (");
            foreach (ColumnInfo column in m_ColumnList)
            {
                if (column.TypeName.ToLower() != "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("@{0},", column.Name));
                }
            }
            sb.Remove(sb.Length - (Environment.NewLine.Length + 1), 1);
            sb.AppendLine(")");
            sb.AppendLine();

            //得到时间戳
            ColumnInfo timestampColumn = CodeHelper.GetTimestampColumn(m_ColumnList);
            if (timestampColumn != null)
            {
                sb.AppendLine(String.Format("Select @New{0}=[{0}] From {1} Where Id=@Id", timestampColumn.Name, m_TableName));
                sb.AppendLine();
            }

            sb.AppendLine("GO");
                      
            return sb.ToString();
        }

        private void SortParaColumns()
        {
            m_InParaColumnList = new List<ColumnInfo>();
            m_OutParaColumnList = new List<ColumnInfo>();
            m_InOutParaColumnList = new List<ColumnInfo>();

            foreach (ColumnInfo column in m_ColumnList)
            {
                if (IsInOutPara(column))
                {
                    m_InOutParaColumnList.Add(column);
                }
                else if (IsOutPara(column))
                {
                    m_OutParaColumnList.Add(column);
                }
                else
                {
                    m_InParaColumnList.Add(column);
                }
            }
        }

        private bool IsInOutPara(ColumnInfo column)
        {
            return false;   //Insert存储过程没有InOut参数
        }

        private bool IsOutPara(ColumnInfo column)
        {
            if (column.IsIdentity)
            {
                return true;
            }
            else if (column.TypeName.ToLower() == "timestamp")
            {
                return true;
            }
            else if (column.Name.ToLower() == "codepinyin" || column.Name.ToLower() == "codewubi" || column.Name.ToLower() == "createtime" || column.Name.ToLower() == "modifytime")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
