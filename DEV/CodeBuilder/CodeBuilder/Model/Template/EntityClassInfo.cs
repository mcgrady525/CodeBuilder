using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CodeBuilder.Model.Domain;
using CodeBuilder.Common;

namespace CodeBuilder.Model.Template
{
    [Serializable]
    public class EntityClassInfo
    {
        public EntityClassInfo(DataTable dt, CreateCodeRequest request)
        {
            this.OriginalClassName = request.TableName;
            this.ClassName = CodeBuilderHelper.GetClassNameByTableName(dt.TableName);
            this.ClassDescription = request.ClassDescription;
            this.TopNameSpace = request.TopNameSpace;
            this.SecondNameSpace = request.SecondNameSpace;

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
        
        /// <summary>
        /// 所有字段
        /// </summary>
        public List<EntityClassPropertyInfo> RopertyList
        {
            get;
            private set;
        }

        /// <summary>
        /// 主键字段
        /// </summary>
        public List<EntityClassPropertyInfo> PrimaryKeyList
        {
            get;
            private set;
        }

        /// <summary>
        /// 非主键字段
        /// </summary>
        public List<EntityClassPropertyInfo> NotPrimaryKeyList
        {
            get;
            private set;
        }

        /// <summary>
        /// 原始的类名(即数据库中的名称)
        /// </summary>
        public string OriginalClassName { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 类的描述
        /// </summary>
        public string ClassDescription { get; set; }

        /// <summary>
        /// 顶级命名空间，一般为解决方案名
        /// </summary>
        public string TopNameSpace { get; set; }

        /// <summary>
        /// 二级命名空间，一般为项目名，如Model或Entity
        /// </summary>
        public string SecondNameSpace { get; set; }

    }
}