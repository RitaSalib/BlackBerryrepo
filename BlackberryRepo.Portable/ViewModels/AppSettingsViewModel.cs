using BlackberryRepo.Portable.Enumerations;
using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.ViewModels
{
    public class AppSettingsViewModel
    {
        #region Constant Settings Keys
        private const string KEY_LANGUAGE = "Language";
        private const string KEY_THEME = "Theme";
        #endregion

        
        private IAppSettingsService appSettingsService;
        private IGlobalizationService globalizationService;
        private IStyleService styleService;
        public AppSettingsViewModel(IAppSettingsService appSettingsService, IGlobalizationService globalizationService, IStyleService styleService)
        {
            this.appSettingsService = appSettingsService;
            this.globalizationService = globalizationService;
            this.styleService = styleService;
          
        }
        
            
        
        public int AppLanguage
        {
            get
            {
                object language = appSettingsService.GetValue(KEY_LANGUAGE);
                if (language != null)
                {
                    int lang = (int)language;
                    return lang;
                }
                return 0;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        //set to English
                        globalizationService.SetCulture(Language.ENGLISH);
                     
                        break;
                    case 1:
                        //set to Arabic
                        globalizationService.SetCulture(Language.ARABIC);
              
                        break;
                }
                appSettingsService.SaveValue(KEY_LANGUAGE, value);
            }
        }

        public int AppTheme
        {
            get
            {
                object language = appSettingsService.GetValue(KEY_THEME);
                if (language != null)
                {
                    int lang = (int)language;
                    return lang;
                }
                return 0;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        //set to English
                        styleService.SetStyle(Theme.LIGHT);
                        break;
                    case 1:
                        //set to Arabic
                        styleService.SetStyle(Theme.DARK);
                        break;
                }
                appSettingsService.SaveValue(KEY_LANGUAGE, value);
            }
        }
    }
}
