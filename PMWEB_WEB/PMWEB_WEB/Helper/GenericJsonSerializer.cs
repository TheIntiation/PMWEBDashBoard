using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PMWEB_WEB.Helper
{
    public static class GenericJsonSerializer
    {
        public static string Serialize<T>(T value)
        {
            string objectString = string.Empty;

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, value);
                // Seek stream to first position
                ms.Seek(0, SeekOrigin.Begin);
                using(StreamReader reader = new StreamReader(ms))
                {
                    objectString = reader.ReadToEnd();
                }
            }

            return objectString;
        }

        public static T Deserialize<T>(string objectString)
        {
            if (string.IsNullOrWhiteSpace(objectString))
                throw new ArgumentException("Empty or non well-formatted strings are not allowed.");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(objectString)))
            {
                return (T)jsonSerializer.ReadObject(ms);
            }
        }
    }
}
