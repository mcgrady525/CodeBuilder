using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    public class ProcGetListGenerator
    {
        private string m_ProcName;
        private string m_TableName;

        public ProcGetListGenerator(string procName, string tableName)
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
            sb.AppendLine("功能: 得到一批记录");
            sb.AppendLine("*/");

            //过程头
            sb.AppendLine(String.Format("CREATE PROCEDURE [dbo].[{0}]", m_ProcName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "@Id int");
            sb.AppendLine("AS");

            sb.AppendLine();
            sb.AppendLine("SET NOCOUNT ON");
            sb.AppendLine();

            sb.AppendLine(String.Format("Select * From {0}", m_TableName));

            sb.AppendLine();
            sb.AppendLine("GO");

            return sb.ToString();
        }
    }
}
