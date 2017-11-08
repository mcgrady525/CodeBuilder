using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 代码生成辅助类
    /// </summary>
    public static class CodeHelper
    {
        //将首字母大写
        public static string MakeFirstLetterUppercase(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            string result = str ;
            if (Char.IsLower(str[0]))
            {
                result = Char.ToUpper(str[0]).ToString() + str.Substring(1);
            }

            int index;
            while((index = result.IndexOf('_')) >= 0)
            {
                string c = string.Empty;
                if(result.Length > index + 1)
                {
                    c = result.Substring(index + 1, 1).ToUpper();
                }
                result = result.Substring(0, index) + c + result.Substring(index + 2);
            }
            return result;
        }

        public static string MakeFirstLetterLowercase(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            if (Char.IsUpper(str[0]))
            {
                return Char.ToLower(str[0]).ToString() + str.Substring(1);
            }
            else
            {
                return str;
            }
        }

        //DbType. 转换
        public static string ConvertTypeToDbType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return typeName;

            if (typeName.ToLower() == "int")
            {
                return "Int32";
            }
            else if (typeName.ToLower() == "smartdate")
            {
                return "DateTime";
            }
            else
            {
                return MakeFirstLetterUppercase(typeName);
            }
        }

        //得到指定数量的空格串
        public static string GetSpaces(int count)
        {
            if (count <= 0)
                return string.Empty;
            else
                return new string(' ', count);
        }

        /// <summary>
        /// 得到注释字符串
        /// </summary>
        public static string GetRemarks(string remark, int prefixSpacesCount)
        {
            if (string.IsNullOrEmpty(remark)) return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CodeHelper.GetSpaces(prefixSpacesCount) + "/// <summary>");
            sb.AppendLine(CodeHelper.GetSpaces(prefixSpacesCount) + "/// " + remark);
            sb.Append(CodeHelper.GetSpaces(prefixSpacesCount) + "/// </summary>");

            return sb.ToString();
        }

        /// <summary>
        /// 根据属性类型得到dr.Get...()语句中的对应字符串
        /// </summary>
        public static string GetConvertedTypeName(string propertyType)
        {
            if (propertyType == "string")
            {
                return "String";
            }
            else if (propertyType == "int")
            {
                return "Int32";
            }
            else if (propertyType == "decimal")
            {
                return "Decimal";
            }
            else if (propertyType == "bool")
            {
                return "Boolean";
            }
            else if (propertyType == "byte[]")
            {
                return "Bytes";
            }
            else if (propertyType == "double")
            {
                return "Double";
            }
            else if (propertyType == "bool")
            {
                return "Boolean";
            }
            else if (propertyType == "bool")
            {
                return "Boolean";
            }
            else
                return propertyType;
        }

        /// <summary>
        /// 生成存储过程参数字符串
        /// </summary>
        public static string GetProcParaString(ColumnInfo columnInfo)
        {
            string typeName = columnInfo.TypeName.ToLower();

            if (typeName == "nvarchar" || typeName == "nchar" || typeName == "varchar")
            {
                return String.Format("@{0} {1}({2})", columnInfo.Name, typeName, columnInfo.Length);
            }
            else if (typeName == "decimal")
            {
                return String.Format("@{0} {1}({2},{3})", columnInfo.Name, typeName, columnInfo.NumericPrecision, columnInfo.NumericScale);
            }
            else
            {
                return String.Format("@{0} {1}", columnInfo.Name, typeName);
            }
        }

        public static bool ContainColumn(List<ColumnInfo> columnList, string columnName)
        {
            columnName = columnName.ToLower();

            foreach (ColumnInfo column in columnList)
            {
                if (column.Name.ToLower() == columnName)
                {
                    return true;
                }
            }
            return false;
        }

        public static ColumnInfo GetTimestampColumn(List<ColumnInfo> columnList)
        {
            foreach (ColumnInfo column in columnList)
            {
                if (column.TypeName.ToLower() == "timestamp")
                {
                    return column;
                }
            }
            return null;
        }
    }
}
