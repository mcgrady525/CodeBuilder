using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 实体类代码生成类
    /// </summary>
    public class EntityClassGenerator
    {
        private string m_TableFullName;        
        private string m_ClassName;
        private string m_ClassRemark;
        private List<ColumnInfo> m_ColumnList;

        public EntityClassGenerator(string tableFullName, string className, string classRemark, List<ColumnInfo> columnList)
        {
            m_TableFullName = tableFullName;
            m_ClassName = className;
            m_ClassRemark = classRemark;
            m_ColumnList = columnList;
        }

        public string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            //using 语句
            sb.AppendLine(ConfigManager.GetConfigInfo().UsingStatements);

            //类定义头部
            sb.AppendLine();
            sb.AppendLine(String.Format("namespace {0}", ConfigManager.GetConfigInfo().NameSpaceForClass));
            sb.AppendLine("{");
            if (!String.IsNullOrEmpty(CodeHelper.GetRemarks(m_ClassRemark, 4)))
            {
                sb.AppendLine(CodeHelper.GetRemarks(m_ClassRemark, 4));
            }
            sb.AppendLine(CodeHelper.GetSpaces(4) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format(@"[Table(""{0}"")]", m_TableFullName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0}", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + "{");

            //属性
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region 基本属性");
            sb.AppendLine();
            sb.Append(this.GetPropertyDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //类结尾
            sb.AppendLine(CodeHelper.GetSpaces(4) + "}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GetPropertyDefinition()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ColumnInfo c in m_ColumnList)
            {   
                //属性注释
                string remarkStr = CodeHelper.GetRemarks(c.Remark, 8);
                if (!String.IsNullOrEmpty(remarkStr))
                {
                    sb.AppendLine(remarkStr);
                }

                //TableAttribute
                if (c.PublicPropertyName == c.Name)
                {
                    if (c.IsIdentity)
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(8) + "[Column(ColumnCategory=Category.IdentityKey)]");
                    }
                    else
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(8) + "[Column]");
                    }
                }
                else
                {
                    if (c.IsIdentity)
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format(@"[Column(""{0}"", ColumnCategory=Category.IdentityKey)]", c.Name));
                    }
                    else
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format(@"[Column(""{0}"")]", c.Name));
                    }
                }

                //属性名
                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public {0} {1} {{ get; set; }}",
                                                                                        c.CodeTypeName,
                                                                                        c.PublicPropertyName));                
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
