using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 业务集合类生成器
    /// </summary>
    public class ReadOnlyListClassGenerator
    {
        private string m_CollectionClassName;
        private string m_ItemClassName;
        private string m_CollectionClassRemark;
        private string m_ProcNum;
        private List<ColumnInfo> m_ColumnList;

        public ReadOnlyListClassGenerator(string collectionClassName, string itemClassName, string remark, string procNum, List<ColumnInfo> columnList)
        {
            m_CollectionClassName = collectionClassName;
            m_ItemClassName = itemClassName;
            m_CollectionClassRemark = remark;
            m_ProcNum = procNum;
            m_ColumnList = columnList;
        }

        public string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            //using 语句
            sb.AppendLine(ConfigManager.GetConfigInfo().UsingStatements);
            sb.AppendLine();

            //类定义头部
            sb.AppendLine(String.Format("namespace {0}", ConfigManager.GetConfigInfo().NameSpaceForClass));
            sb.AppendLine("{");
            if (!String.IsNullOrEmpty(CodeHelper.GetRemarks(m_CollectionClassRemark, 4)))
            {
                sb.AppendLine(CodeHelper.GetRemarks(m_CollectionClassRemark, 4));
            }
            sb.AppendLine(CodeHelper.GetSpaces(4) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0} : LandCsla.ReadOnlyListBase<{0}, {1}>", m_CollectionClassName, m_ItemClassName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + "{");

            //工厂方法
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region Factory Methods");
            sb.AppendLine();
            sb.AppendLine(this.GetFactoryMethodDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //数据访问方法
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region Data Access");
            sb.AppendLine();
            sb.AppendLine(this.GetDataAccessDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //查询类定义
            sb.AppendLine();
            sb.AppendLine(this.GetCriteriaDefinition());

            //常量定义
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_GetList = \"usp_A{1}4_Get{2}List\";",
                                            ConfigManager.GetConfigInfo().ConstantPrefix,
                                            m_ProcNum,
                                            m_ItemClassName));
            sb.AppendLine();

            //类结尾
            sb.AppendLine(CodeHelper.GetSpaces(4) + "}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GetFactoryMethodDefinition()
        {
            StringBuilder sb = new StringBuilder();

            //contructor
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0}()", m_CollectionClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //get...
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static {0} Get{0}({0}.Criteria criteria)", m_CollectionClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("return DataPortal.Fetch<{0}>(criteria);", m_CollectionClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }

        private string GetDataAccessDefinition()
        {
            StringBuilder sb = new StringBuilder();

            //DataPortal_Fetch
            sb.AppendLine(CodeHelper.GetSpaces(8) + "private void DataPortal_Fetch(Criteria criteria)");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("this.RaiseListChangedEvents = false;"));
            sb.AppendLine();            
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "//如果存储过程有参数,在这里添加");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "//db.AddCmdParameter(\"Name\", criteria.Name);");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("using (SafeDataReader dr = new SafeDataReader(db.ExecuteReader({0}, CommandType.StoredProcedure)))",                                                        
                                                        ConfigManager.GetConfigInfo().ConstantPrefix + "SP_GetList"));
            sb.AppendLine(CodeHelper.GetSpaces(16) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "IsReadOnly = false;");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "while (dr.Read())");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(24) + String.Format("this.Add(new {0}(dr));", m_ItemClassName));
            sb.AppendLine(CodeHelper.GetSpaces(20) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "IsReadOnly = true;");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "this.RaiseListChangedEvents = true;");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            ////Get...
            //sb.AppendLine();
            //sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0} Get{0}(SafeDataReader dr)", m_ItemClassName));
            //sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            //sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} info = new {0}(", m_ItemClassName));
            //foreach (ColumnInfo c in m_ColumnList)
            //{
            //    if (c.TypeName.ToLower() == "timestamp") continue;

            //    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("dr.Get{0}({1}),", 
            //                CodeHelper.GetConvertedTypeName(c.CodeTypeName), 
            //                ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName));
            //}
            //sb.Remove(sb.Length - (Environment.NewLine.Length + 1), 1);
            //sb.AppendLine(CodeHelper.GetSpaces(16) + ");");
            //sb.AppendLine();
            //sb.AppendLine(CodeHelper.GetSpaces(12) + "return info;");
            //sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }

        private string GetCriteriaDefinition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "public class Criteria");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "//public string Name;");
            sb.Append(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }
    }
}
