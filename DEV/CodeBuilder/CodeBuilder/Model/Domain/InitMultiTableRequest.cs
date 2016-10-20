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
        /// 所有的表和视图名称
        /// </summary>
        public List<string> TableViews { get; set; }

    }
}
