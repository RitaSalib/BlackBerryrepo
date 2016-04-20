using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface ISerializationService
    {
        string Serialize(object obj);
        object DeSerialize(string json, Type type);
    }
}


