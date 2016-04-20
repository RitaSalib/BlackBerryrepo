using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BlackberryRepo.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        public object GetValue(string key)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
     
            return localSettings.Values[key];
        }



        public void RemoveValue(string key)
        {
            throw new NotImplementedException();
        }


        public void SaveValue(string key, object settingsValue)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values[key] = settingsValue;
        }
    }
}
