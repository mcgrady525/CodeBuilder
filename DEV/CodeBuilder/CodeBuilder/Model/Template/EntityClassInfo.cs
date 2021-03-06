﻿using System;
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
        public EntityClassInfo(DataTable dt, List<ColumnInfo> columnInfos, CreateCodeRequest request)
        {
            this.OriginalClassName = request.TableName;
            this.ClassName = CodeBuilderHelper.GetClassNameByTableName(request.TableName);
            this.ClassDescription = request.ClassDescription;
            this.TopNameSpace = request.TopNameSpace;
            this.SecondNameSpace = request.SecondNameSpace;
            this.IsSetClassDescription = request.GenerateType == Common.GenerateType.SingleTable;//只有单表生成时才设置类的描述

            List<EntityClassPropertyInfo> propertyListTemp = new List<EntityClassPropertyInfo>();

            foreach (DataColumn dcol in dt.Columns)
            {
                propertyListTemp.Add(new EntityClassPropertyInfo(dcol, columnInfos));
            }
            this.PropertyList = propertyListTemp;

            List<EntityClassPropertyInfo> primaryKeyListTemp = new List<EntityClassPropertyInfo>();
            List<EntityClassPropertyInfo> notPrimaryKeyListTemp = new List<EntityClassPropertyInfo>(propertyListTemp);
            foreach (DataColumn dcol in dt.PrimaryKey)
            {
                primaryKeyListTemp.Add(new EntityClassPropertyInfo(dcol, columnInfos));
                notPrimaryKeyListTemp.Remove(new EntityClassPropertyInfo(dcol, columnInfos));
            }
            this.PrimaryKeyList = primaryKeyListTemp;
            this.NotPrimaryKeyList = notPrimaryKeyListTemp;
        }

        /// <summary>
        /// 所有字段
        /// </summary>
        public List<EntityClassPropertyInfo> PropertyList
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

        /// <summary>
        /// 是否设置类的描述(针对单表生成)
        /// </summary>
        public bool IsSetClassDescription { get; set; }

    }
}