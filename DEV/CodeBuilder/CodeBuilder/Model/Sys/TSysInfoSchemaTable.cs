using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Model.Sys
{
    /// <summary>
    /// 获取当前数据库的所有表，视图
    /// </summary>
    public partial class TSysInfoSchemaTable
    {
        public string TABLE_SCHEMA { get; set; }

        public string TABLE_NAME { get; set; }

        public string FullTableName 
        {
            get
            {
                return string.Format("{0}.{1}", TABLE_SCHEMA, TABLE_NAME);
            }
        }

    }
}
