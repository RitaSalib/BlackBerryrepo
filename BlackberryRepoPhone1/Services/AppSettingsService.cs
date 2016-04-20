using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        
        public object GetValue(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
                return IsolatedStorageSettings.ApplicationSettings[key];
            else
                return 0;
        }



        public void RemoveValue(string key)
        {
            throw new NotImplementedException();
        }


        public void SaveValue(string key, object settingsValue)
        {
            IsolatedStorageSettings localSettings = IsolatedStorageSettings.ApplicationSettings;
            if (!localSettings.Contains(key))
                localSettings.Add(key, settingsValue);
            else
                localSettings[key] = settingsValue;
            
        }
    }
}
