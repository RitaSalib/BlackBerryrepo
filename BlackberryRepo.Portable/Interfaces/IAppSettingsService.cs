using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface IAppSettingsService
    {
        object GetValue(string key);
        void SaveValue(string key, object settingsValue);
        void RemoveValue(string key);
    }
}
