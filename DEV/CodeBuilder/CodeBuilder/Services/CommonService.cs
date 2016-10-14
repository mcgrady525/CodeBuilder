using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBuilder.DataAccess;
using Tracy.Frameworks.Common.Extends;

namespace CodeBuilder.Service
{
    public partial class CommonService
    {
        private static readonly CommonDao commonDao= new CommonDao();

        /// <summary>
        /// 获取当前数据库中的所有用户表和视图列表
        /// isTable为true:表, false:视图
        /// </summary>
        public List<string> GetTableOrViewList(bool isTable)
        {
            var result = new List<string>();
            var schemaTables= commonDao.GetTableOrViewList(isTable);
            if (schemaTables.HasValue())
            {
                foreach (var item in schemaTables)
                {
                    result.Add(item.FullTableName);
                }
            }
            result.Sort();

            return result;
        }


    }
}
