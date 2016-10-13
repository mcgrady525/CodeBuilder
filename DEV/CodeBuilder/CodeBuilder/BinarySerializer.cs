using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    /// <summary>
    /// 二进制序列化器
    /// </summary>
    public static class BinarySerializer
    {
        public static byte[] Serialize(object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memStream, obj);

                return memStream.ToArray();
            }
        }

        public static string SerializeToBase64String(object obj) 
        { 
            using (MemoryStream memStream = new MemoryStream()) 
            { 
                new BinaryFormatter().Serialize(memStream, obj);
                
                return Convert.ToBase64String(memStream.ToArray()); 
            } 
        }
        
        public static T Deserialize<T>(byte[] bytes)
        {
            using (MemoryStream memStream = new MemoryStream(bytes))
            {
                memStream.Position = 0;
                return (T)new BinaryFormatter().Deserialize(memStream);
            }
        }

        public static T DeserializeFromBase64String<T>(string s) 
        { 
            using (MemoryStream memStream = new MemoryStream(Convert.FromBase64String(s))) 
            {
                memStream.Position = 0;
                return (T)new BinaryFormatter().Deserialize(memStream); 
            } 
        }

        /// <summary>
        /// 对象深克隆方法(采用二进制序列化然后反序列化的方式)
        /// </summary>
        /// <param name="obj">原对象,必须是可二进制序列化的</param>
        /// <returns>克隆后的对象</returns>
        public static object CloneObject(object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(memStream, obj);

                memStream.Position = 0;

                return formatter.Deserialize(memStream);
            }
        }
    }
}
