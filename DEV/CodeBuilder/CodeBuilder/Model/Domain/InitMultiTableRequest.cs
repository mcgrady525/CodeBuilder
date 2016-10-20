using CodeBuilder.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Model.Domain
{
    /// <summary>
    /// 初始化批量生成窗体request
    /// </summary>
    [Serializable]
    public class InitMultiTableRequest
    {
        /// <summary>
        /// 当前server
        /// </summary>
        public string CurrentServer { get; set; }

        /// <summary>
        /// 当前db
        /// </summary>
        public string CurrentDB { get; set; }

        /// <summary>
        /// 顶级命名空间
        /// </summary>
        public string TopNameSpace { get; set; }

        /// <summary>
        /// 二级命名空间
        /// </summary>
        public string SecondNameSpace { get; set; }

        /// <summary>
        /// 代码类型
        /// </summary>
        public CodeType CodeType { get; set; }

        /// <summary>
        /// 所有的表和视图名称
        /// </summary>
        public List<string> TableViews { get; set; }

    }
}
