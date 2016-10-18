using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeBuilder.Model.Template
{
    [Serializable]
    public class EntityClassPropertyInfo
    {
        public EntityClassPropertyInfo(DataColumn dcol)
        {
            this.PropertyName = dcol.ColumnName;
            this.PropertyType = dcol.DataType.Name;
            this.IsValueType = false;
            if (dcol.DataType.IsValueType)
            {
                if (dcol.AllowDBNull)
                {
                    this.PropertyType = this.PropertyType + "?";
                }
                else
                {
                    this.IsValueType = true;
                }
            }
        }

        public string PropertyName
        {
            get;
            private set;
        }

        public string PropertyType
        {
            get;
            private set;
        }

        public bool IsValueType
        {
            get;
            private set;
        }

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
