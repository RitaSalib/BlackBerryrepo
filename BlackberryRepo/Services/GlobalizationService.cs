using BlackberryRepo.Portable.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlackberryRepo.Services
{
    public class GlobalizationService : BlackberryRepo.Portable.Interfaces.IGlobalizationService
    {
        async public void SetCulture(Language language)
        {
            var frame = Window.Current.Content as Frame;
            CultureInfo info = null;
            switch (language)
            {
                case Language.ENGLISH:
                   Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "en-US";
                    //frame.FlowDirection = FlowDirection.LeftToRight;
                    info = new CultureInfo("en-US");
               frame.Navigate(frame.Content.GetType());
                frame.GoBack(); // remove from BackStack
                   
                    break;
                case Language.ARABIC:
                   Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "ar-EG";
                    info = new CultureInfo("ar-EG");
                      frame.Navigate(frame.Content.GetType());
               frame.GoBack(); // remove from BackStack

                    break;
            }






        }

        public Language GetCurrentLanguage()
        {
            //string lang = Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride;
            //string lang = Windows.Globalization.ApplicationLanguages.Languages[0];
            string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (lang == "en")
                return Language.ENGLISH;
            else
                return Language.ARABIC;
        }
    }
}
