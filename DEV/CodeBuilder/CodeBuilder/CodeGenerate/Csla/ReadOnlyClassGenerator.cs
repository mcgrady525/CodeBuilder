using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 只读实体类代码生成类
    /// </summary>
    public class ReadOnlyClassGenerator
    {
        private string m_ClassName;
        private string m_ClassRemark;
        private List<ColumnInfo> m_ColumnList;

        //是否使用业务类中的常量
        private bool m_UseBusinessConstants;

        public ReadOnlyClassGenerator(string className, string classRemark, bool useBusinessConstants, List<ColumnInfo> columnList)
        {
            m_ClassName = className;
            m_ClassRemark = classRemark;
            m_UseBusinessConstants = useBusinessConstants;
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
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0} : LandCsla.ReadOnlyBase<{0}>", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + "{");

            //属性
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region Business Methods");
            sb.AppendLine();
            sb.Append(this.GetPropertyDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //构造器
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region Constructors");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0}()", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("internal {0}(SafeDataReader dr)", m_ClassName));
            //foreach (ColumnInfo c in m_ColumnList)
            //{
            //    if (c.TypeName.ToLower() == "timestamp") continue;                
            //    sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} {1},", c.CodeTypeName, CodeHelper.MakeFirstLetterLowercase(c.PublicPropertyName))); 
            //}
            //sb[sb.Length - (Environment.NewLine.Length + 1)] = ')';
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            foreach (ColumnInfo c in m_ColumnList)
            {
                if (c.TypeName.ToLower() == "timestamp") continue;
                sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("m_{0} = dr.Get{1}({2});",
                                        c.PublicPropertyName,
                                        CodeHelper.GetConvertedTypeName(c.CodeTypeName),
                                        m_UseBusinessConstants ? (GetBusinessClassName() + "." + ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName) : "\"" + c.Name + "\""));
            }
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //类结尾
            sb.AppendLine(CodeHelper.GetSpaces(4) + "}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GetBusinessClassName()
        {
            if (m_ClassName.EndsWith("Info"))
                return m_ClassName.Substring(0, m_ClassName.Length - 4);
            else
                return m_ClassName;
        }

        private string GetPropertyDefinition()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ColumnInfo c in m_ColumnList)
            {
                if (c.TypeName.ToLower() == "timestamp")
                {
                    continue;
                }

                //字段
                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0} m_{1};",
                                                                            c.CodeTypeName,
                                                                            c.PublicPropertyName));

                //属性注释
                string remarkStr = CodeHelper.GetRemarks(c.Remark, 8);
                if (!String.IsNullOrEmpty(remarkStr))
                {
                    sb.AppendLine(remarkStr);
                }

                //属性名
                if (c.CodeTypeName == "SmartDate")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public string {0}", c.PublicPropertyName));
                    sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "get");
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("m_{0}.FormatString = \"yyyy-MM-dd HH:mm:ss\";", c.PublicPropertyName)); ;
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("return m_{0}.ToString();", c.PublicPropertyName));
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
                    sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public {0} {1} {{ get {{ return m_{1}; }} }}",
                                                                                        c.CodeTypeName,
                                                                                        c.PublicPropertyName));
                }

                sb.AppendLine();
            }

            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override object GetIdValue()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "return Id;");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            sb.AppendLine(CodeHelper.GetSpaces(8) + "public override string ToString()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "return base.ToString();");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
