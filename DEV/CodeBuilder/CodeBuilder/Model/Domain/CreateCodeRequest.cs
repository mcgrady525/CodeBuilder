using CodeBuilder.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Model.Domain
{
    /// <summary>
    /// 生成代码request
    /// </summary>
    [Serializable]
    public class CreateCodeRequest
    {
        /// <summary>
        /// 当前数据库
        /// </summary>
        public string DBName { get; set; }

        /// <summary>
        /// 当前数据表(针对单表生成)
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 生成类型
        /// </summary>
        public GenerateType GenerateType { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 类的描述
        /// </summary>
        public string ClassDescription { get; set; }

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
        /// 输出目录(针对批量生成代码)
        /// </summary>
        public string OutPutPath { get; set; }

    }
}
