using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 命令类代码生成器
    /// </summary>
    [Serializable]
    public class CommandClassGenerator
    {
        private string m_ClassName;
        private string m_ProcName;
        private List<CommandParameter> m_ParameterList;

        public CommandClassGenerator(string className, string procName, List<CommandParameter> parameterList)
        {
            m_ClassName = className;
            m_ProcName = procName;
            m_ParameterList = parameterList;
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
            sb.AppendLine(CodeHelper.GetSpaces(4) + "[Serializable]");
            sb.AppendLine(CodeHelper.GetSpaces(4) + String.Format("public class {0} : Csla.CommandBase", m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(4) + "{");

            //字段定义
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0} m_{1};", item.TypeName, CodeHelper.MakeFirstLetterUppercase(item.Name)));
            }
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "private string m_Result;");

            //构造函数
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private {0}(", m_ClassName));
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} {1},", item.TypeName, CodeHelper.MakeFirstLetterLowercase(item.Name)));
            }
            sb[sb.Length - (Environment.NewLine.Length + 1)] = ')';
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("m_{0} = {1};",
                                                            CodeHelper.MakeFirstLetterUppercase(item.Name),
                                                            CodeHelper.MakeFirstLetterLowercase(item.Name)));
            }
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");
            
            //Execute方法
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("public static string Execute("));
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} {1},", item.TypeName, CodeHelper.MakeFirstLetterLowercase(item.Name)));
            }
            sb[sb.Length - (Environment.NewLine.Length + 1)] = ')';
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} cmd = new {0}(", m_ClassName));
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("{0},", CodeHelper.MakeFirstLetterLowercase(item.Name)));
            }
            sb[sb.Length - (Environment.NewLine.Length + 1)] = ')';
            sb.Insert(sb.Length - Environment.NewLine.Length, ';');
            sb.AppendLine(CodeHelper.GetSpaces(12) + String.Format("{0} cmd2 = DataPortal.Execute<{0}>(cmd);", m_ClassName));
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(12) + "return cmd2.Result;");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //Result
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "public string Result");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "get { return m_Result; }");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //DataPortal_Execute
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + "[Transactional(TransactionalTypes.Manual)]");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "protected override void DataPortal_Execute()");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "{");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "using (IDataAccess db = DbHelper.GetDefaultDb())");
            sb.AppendLine(CodeHelper.GetSpaces(12) + "{");
            foreach (CommandParameter item in m_ParameterList)
            {
                sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("db.AddCmdParameter(\"{0}\", m_{0});", CodeHelper.MakeFirstLetterUppercase(item.Name)));                
            }
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(16) + String.Format("m_Result = (string)db.ExecuteScalar({0}SP_{1}, CommandType.StoredProcedure);",
                                                                        ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                        m_ClassName));
            sb.AppendLine(CodeHelper.GetSpaces(12) + "}");
            sb.AppendLine(CodeHelper.GetSpaces(8) + "}");

            //常量
            sb.AppendLine();
            sb.AppendLine(CodeHelper.GetSpaces(8) + String.Format("private const string {0}SP_{1} = \"{2}\";",
                                                                        ConfigManager.GetConfigInfo().ConstantPrefix,
                                                                        m_ClassName,
                                                                        m_ProcName));

            //类结尾
            sb.AppendLine(CodeHelper.GetSpaces(4) + "}");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

    /// <summary>
    /// 命令类参数信息
    /// </summary>
    [Serializable]
    public class CommandParameter
    {
        private string m_Name;
        private string m_TypeName;

        public CommandParameter(string name, string typeName)
        {
            m_Name = name;
            m_TypeName = typeName;
        }

        public string Name
        {
            get { return m_Name; }
        }

        public string TypeName
        {
            get { return m_TypeName; }
        }
    }
}
