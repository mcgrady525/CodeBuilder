using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 数据表列信息
    /// </summary>
    public class ColumnInfo
    {        
        private string m_Name;
        /// <summary>
        /// 列名
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_TypeName;
        /// <summary>
        /// 数据类型
        /// </summary>
        public string TypeName
        {
            get { return m_TypeName; }
            set { m_TypeName = value; }
        }

        private int m_Length;
        /// <summary>
        /// 字段长度
        /// </summary>
        public int Length
        {
            get { return m_Length; }
            set { m_Length = value; }
        }

        private int m_NumericScale;
        /// <summary>
        /// 小数位数
        /// </summary>
        public int NumericScale
        {
            get { return m_NumericScale; }
            set { m_NumericScale = value; }
        }

        private int m_NumericPrecision;
        /// <summary>
        /// 精度,仅对decimal有效
        /// </summary>
        public int NumericPrecision
        {
            get { return m_NumericPrecision; }
            set { m_NumericPrecision = value; }
        }

        private bool m_IsIdentity;
        /// <summary>
        /// 是否标识
        /// </summary>
        public bool IsIdentity
        {
            get { return m_IsIdentity; }
            set { m_IsIdentity = value; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否外键
        /// </summary>
        public bool IsForeignKey { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        public bool IsNullalbe { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        private string m_Remark;
        /// <summary>
        /// 列备注
        /// </summary>
        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }

        //以下为代码生成时的信息
        private string m_PrivateFieldName;
        public string PrivateFieldName
        {
            get { return m_PrivateFieldName; }
            set { m_PrivateFieldName = value; }
        }

        private string m_PublicPropertyName;
        /// <summary>
        /// 生成代码的属性名
        /// </summary>
        public string PublicPropertyName
        {
            get { return m_PublicPropertyName; }
            set { m_PublicPropertyName = value; }
        }

        private string m_CodeTypeName;
        /// <summary>
        /// 生成代码的属性类型名
        /// </summary>
        public string CodeTypeName
        {
            get { return m_CodeTypeName; }
            set { m_CodeTypeName = value; }
        }

        private bool m_CanGet = true;
        public bool CanGet
        {
            get { return m_CanGet; }
            set { m_CanGet = value; }
        }

        private bool m_CanSet = true;
        public bool CanSet
        {
            get { return m_CanSet; }
            set { m_CanSet = value; }
        }

        public void SetDefultValue()
        {
            this.PublicPropertyName = CodeHelper.MakeFirstLetterUppercase(this.Name);
            this.CodeTypeName = CodeHelper.GetCodeTypeName(this.TypeName);

            this.CanSet = true;// this.Name.ToLower() != "id";
        }
    }
}
