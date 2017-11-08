using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CodeBuilder.Common;

namespace CodeBuilder.Model.Template
{
    [Serializable]
    public class EntityClassPropertyInfo
    {
        public EntityClassPropertyInfo(DataColumn dcol)
        {
            this.OriginalPropertyName = dcol.ColumnName;
            this.PropertyName = CodeHelper.MakeFirstLetterUppercase(dcol.ColumnName);
            this.PropertyType = CodeBuilderHelper.ConvertUserTypeToKeyword(dcol.DataType.FullName);
            this.IsPrimaryKey = dcol.Unique;
            this.IsValueType = false;
            if (dcol.DataType.IsValueType)
            {
                if (dcol.AllowDBNull)
                {
                    this.PropertyType = this.PropertyType + "?";
                }
                this.IsValueType = true;
            }
        }

        /// <summary>
        /// 原始字段名称(即数据库中的名称)
        /// </summary>
        public string OriginalPropertyName { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string PropertyName
        {
            get;
            private set;
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        public string PropertyType
        {
            get;
            private set;
        }

        /// <summary>
        /// 标识字段是否为值类型
        /// </summary>
        public bool IsValueType
        {
            get;
            private set;
        }

        /// <summary>
        /// 字段备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        public override bool Equals(object obj)
        {
            EntityClassPropertyInfo temp = obj as EntityClassPropertyInfo;
            if (this.PropertyName == temp.PropertyName && this.PropertyType == temp.PropertyType)
            {
                return true;
            }
            return false;
        }
        
    }
}
