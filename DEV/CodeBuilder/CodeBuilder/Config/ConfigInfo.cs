using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 配置信息
    /// </summary>
    [Serializable]
    public class ConfigInfo
    {
        private string m_ConstantPrefix;
        /// <summary>
        /// 常量前缀
        /// </summary>
        public string ConstantPrefix
        {
            get { return m_ConstantPrefix; }
            set { m_ConstantPrefix = value; }
        }

        private string m_NameSpaceForClass;
        /// <summary>
        /// 业务类所在的命名空间
        /// </summary>
        public string NameSpaceForClass
        {
            get { return m_NameSpaceForClass; }
            set { m_NameSpaceForClass = value; }
        }

        private string m_UsingStatements;
        /// <summary>
        /// using语句
        /// </summary>
        public string UsingStatements
        {
            get { return m_UsingStatements; }
            set { m_UsingStatements = value; }
        }

    }
}
