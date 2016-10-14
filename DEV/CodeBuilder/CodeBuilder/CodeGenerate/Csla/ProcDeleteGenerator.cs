using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    public class ProcDeleteGenerator
    {
        private string m_ProcName;
        private string m_TableName;

        public ProcDeleteGenerator(string procName, string tableName)
        {
            m_ProcName = procName;
            m_TableName = tableName;
        }

        public string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            //注释
            sb.AppendLine();
            sb.AppendLine("/*");
            sb.AppendLine("功能: 删除某条记录");
            sb.AppendLine("*/");

            //过程头
            sb.AppendLine(String.Format("CREATE PROCEDURE [dbo].[{0}]", m_ProcName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "@Id int");
            sb.AppendLine("AS");
            
            sb.AppendLine();
            sb.AppendLine("SET NOCOUNT ON");
            sb.AppendLine();

            sb.AppendLine(String.Format("DELETE FROM [dbo].[{0}]", m_TableName));
            sb.AppendLine("WHERE [Id] = @Id");
            
            sb.AppendLine();
            sb.AppendLine("GO");
                      
            return sb.ToString();
        }
    }
}
