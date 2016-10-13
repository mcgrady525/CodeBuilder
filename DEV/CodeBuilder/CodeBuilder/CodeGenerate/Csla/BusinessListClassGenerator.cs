using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 业务集合类生成器
    /// </summary>
    public class BusinessListClassGenerator
    {
        private string m_TableName;
        private string m_ItemClassName;
        private string m_CollectionClassName;
        private string m_CollectionClassRemark;

        public BusinessListClassGenerator(string tableName, string itemClassName, string collectionClassName, string collectionClassRemark)
        {
            m_TableName = tableName;
            m_ItemClassName = itemClassName;
            m_CollectionClassName = collectionClassName;
            m_CollectionClassRemark = collectionClassRemark;
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
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0} : LandCsla.BusinessListBase<{0}, {1}>", m_CollectionClassName, m_ItemClassName));
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
            
            //new...
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static {0} New{0}()", m_CollectionClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("return DataPortal.Create<{0}>();", m_CollectionClassName));
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

            //DataPortal_Create
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[RunLocal]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override void DataPortal_Create()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //DataPortal_Fetch
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override void DataPortal_Fetch(object criteria)");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0}.Criteria cr = criteria as {0}.Criteria;", m_CollectionClassName));
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("string sqlString = \"Select * From {0}\";", m_TableName));
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(12) + "//如果有其它条件, 在这里添加...");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "using (SafeDataReader dr = new SafeDataReader(db.ExecuteReader(sqlString)))");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "RaiseListChangedEvents = false;");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "while (dr.Read())");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(24) + String.Format("this.Add(new {0}(dr));", m_ItemClassName));
            sb.AppendLine(CodeHelper.GetSpaces(20) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "RaiseListChangedEvents = true;");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }

        private string GetCriteriaDefinition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "public class Criteria");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "public int Id;");
            sb.Append(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }
    }
}
