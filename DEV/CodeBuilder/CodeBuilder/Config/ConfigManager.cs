using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CodeBuilder
{
    /// <summary>
    /// 配置管理类
    /// </summary>
    public static class ConfigManager
    {
        private const string ConfigFileName = "Config";

        private static ConfigInfo s_ConfigInfo;

        /// <summary>
        /// 从配置文件中加载ConfigInfo,如果不存在配置文件，创建默认的配置对象
        /// </summary>
        public static ConfigInfo GetConfigInfo()
        {
            if (s_ConfigInfo == null)
            {
                ConfigInfo configInfo = null;

                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);

                if (File.Exists(fileName))
                {
                    byte[] bytes = File.ReadAllBytes(fileName);

                    configInfo = BinarySerializer.Deserialize<ConfigInfo>(bytes);
                }
                else
                {
                    configInfo = GetDefaultConfig();
                }

                s_ConfigInfo = configInfo;
            }

            return s_ConfigInfo;
        }

        public static void SaveConfigInfo(ConfigInfo config)
        {            
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);

            byte[] bytes = BinarySerializer.Serialize(config);

            File.WriteAllBytes(fileName, bytes);

            s_ConfigInfo = config;
        }

        private static ConfigInfo GetDefaultConfig()
        {
            ConfigInfo config = new ConfigInfo();

            config.ConstantPrefix = "C_";
            config.NameSpaceForClass = "SSharing.Ubtrip.Model.Hotel";
            config.UsingStatements = GetUsingStatements();

            return config;
        }

        private static string GetUsingStatements()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using SSharing.Ubtrip.Common.Entity;");
            sb.Append("using SSharing.Ubtrip.Common.Sql;");

            return sb.ToString();
        }
    }
}
