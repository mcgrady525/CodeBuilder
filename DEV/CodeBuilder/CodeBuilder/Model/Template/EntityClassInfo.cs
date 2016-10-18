using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeBuilder.Model.Template
{
    [Serializable]
    public class EntityClassInfo
    {
        public EntityClassInfo(DataTable dt)
        {
            this.ClassName = dt.TableName;

            List<EntityClassPropertyInfo> ropertyListTemp = new List<EntityClassPropertyInfo>();
           
            foreach (DataColumn dcol in dt.Columns)
            {
                ropertyListTemp.Add(new EntityClassPropertyInfo(dcol));
            }
            this.RopertyList = ropertyListTemp;

            List<EntityClassPropertyInfo> primaryKeyListTemp = new List<EntityClassPropertyInfo>();
            List<EntityClassPropertyInfo> notPrimaryKeyListTemp = new List<EntityClassPropertyInfo>(ropertyListTemp);
            foreach (DataColumn dcol in dt.PrimaryKey)
            {
                primaryKeyListTemp.Add(new EntityClassPropertyInfo(dcol));
                notPrimaryKeyListTemp.Remove(new EntityClassPropertyInfo(dcol));
            }
            this.PrimaryKeyList = primaryKeyListTemp;
            this.NotPrimaryKeyList = notPrimaryKeyListTemp;
        }
        public string ClassName
        {
            get;
            private set;
        }
        public List<EntityClassPropertyInfo> RopertyList
        {
            get;
            private set;
        }
        public List<EntityClassPropertyInfo> PrimaryKeyList
        {
            get;
            private set;
        }
        public List<EntityClassPropertyInfo> NotPrimaryKeyList
        {
            get;
            private set;
        }
    }
}