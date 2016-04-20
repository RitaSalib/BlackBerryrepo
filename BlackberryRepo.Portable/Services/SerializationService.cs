using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackberryRepo.Portable.Interfaces;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml;

namespace BlackberryRepo.Portable.Services
{
    public class SerializationService : ISerializationService
    {
        public string Serialize(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
           MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray(),0,ms.ToArray().Length);
            return retVal;
        }

        public object DeSerialize(string json, Type type)
        {
            object obj = null;
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            obj = (Object)serializer.ReadObject(ms);
            return obj;
        }
    }
}
