using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 业务主类代码生成类
    /// </summary>
    public class BusinessClassGenerator
    {
        private string m_ClassName;
        private string m_ClassRemark;
        private string m_TableName;
        private string m_ProcNumber;
        private List<ColumnInfo> m_ColumnList;
        
        public BusinessClassGenerator(string className, string classRemark, string tableName, string procNumber, List<ColumnInfo> columnList)
        {
            m_ClassName = className;
            m_ClassRemark = classRemark;
            m_TableName = tableName;
            m_ProcNumber = procNumber;

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
            if (!String.IsNullOrEmpty(CodeHelper.GetRemarks(m_ClassRemark, 4)))
            {
                sb.AppendLine(CodeHelper.GetRemarks(m_ClassRemark, 4));
            }
            sb.AppendLine(CodeHelper.GetSpaces(4) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0} : LandCsla.BusinessBase<{0}>", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + "{");

            //属性
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region Business Methods");
            sb.AppendLine();
            sb.Append(this.GetPropertyDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //验证方法
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region  Validation Rules");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override void AddBusinessRules()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "//ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired,");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "//new Csla.Validation.RuleArgs(CodeProperty));");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "//在这里添加其它规则验证...");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //权限认证方法
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region  Authorization Rules");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override void AddAuthorizationRules()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "// add AuthorizationRules here");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected static void AddObjectAuthorizationRules()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "// add object-level authorization rules here");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            //工厂方法
            sb.AppendLine();
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

            //常量定义
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#region 常量定义");
            sb.AppendLine();
            sb.AppendLine(this.GetConstantsDefinition());
            sb.AppendLine(CodeHelper.GetSpaces(8) + "#endregion");

            ////查询类定义
            //sb.AppendLine();
            //sb.AppendLine(this.GetCriteriaDefinition());

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
                if (c.TypeName.ToLower() == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private byte[] m_{0} = new byte[8];", c.PublicPropertyName));
                    sb.AppendLine();
                    continue;
                }

                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private static PropertyInfo<{0}> {1}Property =", 
                                                                            c.CodeTypeName, 
                                                                            c.PublicPropertyName));

                sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("RegisterProperty<{0}>(typeof({1}), new PropertyInfo<{0}>({2}, \"{3}\"));", 
                                                                            c.CodeTypeName, 
                                                                            m_ClassName, 
                                                                            ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName, 
                                                                            c.Remark));
                //属性注释
                string remarkStr = CodeHelper.GetRemarks(c.Remark, 8);
                if (!String.IsNullOrEmpty(remarkStr))
                {
                    sb.AppendLine(remarkStr);
                }

                //属性名
                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public {0} {1}", c.CodeTypeName == "SmartDate" ? "string" : c.CodeTypeName, c.PublicPropertyName));
                
                //get...
                sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
                if (c.CodeTypeName == "SmartDate")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "get");
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("SmartDate date = GetProperty<SmartDate>({0}Property);", c.PublicPropertyName));
                    sb.AppendLine(CodeHelper.GetSpaces(16) + "date.FormatString = \"yyyy-MM-dd HH:mm:ss\";");
                    sb.AppendLine(CodeHelper.GetSpaces(16) + "return date.ToString();");
                    sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("get {{ return GetProperty<{0}>({1}Property); }}",
                                                                                        c.CodeTypeName,
                                                                                        c.PublicPropertyName));
                }

                if (c.CanSet)
                {
                    if (c.CodeTypeName == "SmartDate")
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("set {{ SetProperty<SmartDate, string>({0}Property, value); }}", c.PublicPropertyName));
                    }
                    else
                    {
                        sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("set {{ SetProperty<{0}>({1}Property, value); }}",
                                                                                        c.CodeTypeName,
                                                                                        c.PublicPropertyName));
                    }
                }

                sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
                sb.AppendLine();
            }

            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override object GetIdValue()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "return Id;");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            return sb.ToString();
        }
        
        private string GetFactoryMethodDefinition()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static {0} New{0}()", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("return DataPortal.Create<{0}>();", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static {0} Get{0}(int id)", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("return DataPortal.Fetch<{0}>(new SingleCriteria<{0}, int>(id));", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static void Delete{0}(int id)", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("DataPortal.Delete(new SingleCriteria<{0}, int>(id));", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("internal {0}(SafeDataReader dr)", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("FetchObject(dr);"));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            sb.AppendLine();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0}()", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
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
            sb.AppendLine(CodeHelper.GetSpaces(12) + "ValidationRules.CheckRules();");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            
            //DataPortal_Fetch
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private void DataPortal_Fetch(SingleCriteria<{0}, int> criteria)", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "db.AddCmdParameter(C_Id, criteria.Value);");
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("using (SafeDataReader dr = new SafeDataReader(db.ExecuteReader({0}SP_Get, CommandType.StoredProcedure)))", ConfigManager.GetConfigInfo().ConstantPrefix));
            sb.AppendLine(CodeHelper.GetSpaces(16) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "if (dr.Read())");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(24) + "FetchObject(dr);");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "else");
            sb.AppendLine(CodeHelper.GetSpaces(20) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(24) + String.Format("throw new Exception(string.Format(\"未找到Id为({{0}})的{0}数据\", criteria.Value));", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(20) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(16) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            
            //FetchObject
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "private void FetchObject(SafeDataReader dr)");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            foreach (ColumnInfo c in m_ColumnList)
            {
                if (c.TypeName.ToLower() == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("dr.GetBytes({0}{1}, 0, m_{1}, 0, 8);",
                                                                               ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                               c.PublicPropertyName));
                }
                else if (c.CodeTypeName.ToLower() == "smartdate")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("LoadProperty<{0}>({1}Property,{2}dr.Get{0}({3}));",
                                                                         "SmartDate",
                                                                         c.PublicPropertyName,
                                                                         GetSpacesStringByPropertyName(c.PublicPropertyName, c.CodeTypeName),                                                                         
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName));
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("LoadProperty<{0}>({1}Property,{2}dr.Get{3}({4}));",
                                                                         c.CodeTypeName,
                                                                         c.PublicPropertyName,
                                                                         GetSpacesStringByPropertyName(c.PublicPropertyName, c.CodeTypeName),
                                                                         CodeHelper.GetConvertedTypeName(c.CodeTypeName),
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName));
                }
            }
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //DataPortal_Insert
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Transactional(TransactionalTypes.Manual)]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("protected override void DataPortal_Insert()"));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            foreach (ColumnInfo c in m_ColumnList)  //添加Insert参数
            {
                string columnName = c.Name.ToLower();

                if (c.TypeName == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdOutParameter(\"New{0}\",{1}DbType.Binary);",
                                                                         c.Name,
                                                                         CodeHelper.GetSpaces(1)));
                }
                else if (columnName == "id" || columnName == "codepinyin" || columnName == "codewubi" || columnName == "createtime" || columnName == "modifytime")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdOutParameter({0}{1},{2}DbType.{3});",
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                         c.PublicPropertyName,
                                                                         CodeHelper.GetSpaces(35 - c.PublicPropertyName.Length),
                                                                         CodeHelper.ConvertTypeToDbType(c.CodeTypeName)));
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdParameter({0}{1},{2}ReadProperty<{3}>({1}Property){4});",
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                         c.PublicPropertyName,
                                                                         CodeHelper.GetSpaces(35 - c.PublicPropertyName.Length),
                                                                         c.CodeTypeName,
                                                                         c.CodeTypeName == "SmartDate" ? ".DBValue" : ""));
                }
            }
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.ExecuteNonQuery({0}SP_Add, CommandType.StoredProcedure);", ConfigManager.GetConfigInfo().ConstantPrefix));
            sb.AppendLine();
            foreach (ColumnInfo c in m_ColumnList)  
            {
                string columnName = c.Name.ToLower();

                if (c.TypeName == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("m_{0} = (byte[])db.GetParameterValue(\"New{0}\");",
                                                                         c.PublicPropertyName));
                }
                else if (columnName == "id" || columnName == "codepinyin" || columnName == "codewubi" || columnName == "createtime" || columnName == "modifytime")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("LoadProperty<{0}>({1}Property, ({2})db.GetParameterValue({3}{1}));",
                                                                         c.CodeTypeName,
                                                                         c.PublicPropertyName,
                                                                         c.CodeTypeName == "SmartDate" ? "DateTime" : c.CodeTypeName,
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix
                                                                         ));
                }
            }

            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
                        
            //DataPortal_Update
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Transactional(TransactionalTypes.Manual)]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("protected override void DataPortal_Update()"));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            foreach (ColumnInfo c in m_ColumnList)  //添加Update参数
            {
                string columnName = c.Name.ToLower();

                if (c.TypeName == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdParameter({0}{1},{2}m_{1});",
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                         c.PublicPropertyName,
                                                                         CodeHelper.GetSpaces(35 - c.PublicPropertyName.Length)));
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdOutParameter(\"New{0}\",{1}DbType.Binary);",
                                                                         c.Name,
                                                                         CodeHelper.GetSpaces(1)));
                }
                else if (columnName == "codepinyin" || columnName == "codewubi" || columnName == "modifytime")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdOutParameter({0}{1},{2}DbType.{3});",
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                         c.PublicPropertyName,
                                                                         CodeHelper.GetSpaces(35 - c.PublicPropertyName.Length),
                                                                         CodeHelper.ConvertTypeToDbType(c.CodeTypeName)));
                }
                else
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdParameter({0}{1},{2}ReadProperty<{3}>({1}Property){4});",
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                         c.PublicPropertyName,
                                                                         CodeHelper.GetSpaces(35 - c.PublicPropertyName.Length),
                                                                         c.CodeTypeName,
                                                                         c.CodeTypeName == "SmartDate" ? ".DBValue" : ""));
                }
            }
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.ExecuteNonQuery({0}SP_Update, CommandType.StoredProcedure);", ConfigManager.GetConfigInfo().ConstantPrefix));
            sb.AppendLine();
            foreach (ColumnInfo c in m_ColumnList)
            {
                string columnName = c.Name.ToLower();

                if (c.TypeName == "timestamp")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("m_{0} = (byte[])db.GetParameterValue(\"New{0}\");",
                                                                         c.PublicPropertyName));
                }
                else if (columnName == "codepinyin" || columnName == "codewubi" || columnName == "modifytime")
                {
                    sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("LoadProperty<{0}>({1}Property, ({2})db.GetParameterValue({3}{1}));",
                                                                         c.CodeTypeName,
                                                                         c.PublicPropertyName,
                                                                         c.CodeTypeName == "SmartDate" ? "DateTime" : c.CodeTypeName,
                                                                         ConfigManager.GetConfigInfo().ConstantPrefix
                                                                         ));
                }
            }

            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //DataPortal_DeleteSelf
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("protected override void DataPortal_DeleteSelf()"));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("DataPortal_Delete(new SingleCriteria<{0}, int>(GetProperty<int>(IdProperty)));", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //DataPortal_Delete
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Transactional(TransactionalTypes.Manual)]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private void DataPortal_Delete(SingleCriteria<{0}, int> criteria)", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdParameter({0}Id, criteria.Value);", ConfigManager.GetConfigInfo().ConstantPrefix));
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.ExecuteNonQuery({0}SP_Delete, CommandType.StoredProcedure);", ConfigManager.GetConfigInfo().ConstantPrefix));
            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            return sb.ToString();
        }

        //根据属性名及属性类型名，计算后面应有多少个空格，为了使后面的部分对齐
        private string GetSpacesStringByPropertyName(string propertyName, string propertyTypeName)
        {
            int length = (propertyName + "Property" + propertyTypeName).Length;

            int reslut = 45 - length;

            if (reslut <= 0) reslut = 1;

            return CodeHelper.GetSpaces(reslut);            
        }

        private string GetConstantsDefinition()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}Table = \"{1}\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_TableName));
            sb.AppendLine();

            foreach (ColumnInfo c in m_ColumnList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}{1}= \"{2}\";", 
                                                                        ConfigManager.GetConfigInfo().ConstantPrefix + c.PublicPropertyName,
                                                                        CodeHelper.GetSpaces(30 - c.PublicPropertyName.Length),
                                                                        c.Name));
            }
            
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_Get = \"usp_A{1}0_Get{2}\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_ProcNumber,  m_TableName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_Add = \"usp_A{1}1_Add{2}\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_ProcNumber, m_TableName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_Update = \"usp_A{1}2_Update{2}\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_ProcNumber, m_TableName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_Delete = \"usp_A{1}3_Delete{2}\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_ProcNumber, m_TableName));
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public const string {0}SP_GetList = \"usp_A{1}4_Get{2}s\";", ConfigManager.GetConfigInfo().ConstantPrefix, m_ProcNumber, m_TableName));

            return sb.ToString();
        }
    }
}
