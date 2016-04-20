using BlackberryRepo.Portable.Enumerations;
using BlackberryRepoPhone1.Resources;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace BlackberryRepoPhone1.Services
{
    public class GlobalizationService : BlackberryRepo.Portable.Interfaces.IGlobalizationService
    {
         public void SetCulture(Language language)
        {
           // var frame = Window.Current.Content as Frame;
            CultureInfo info = null;
            switch (language)
            {
                case Language.ENGLISH:
                    //frame.FlowDirection = FlowDirection.LeftToRight;
                    info = new CultureInfo("en-US");
                  
                    break;
                case Language.ARABIC:
                    info = new CultureInfo("ar");
                 
                 

                    break;
            }

            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;
            FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection),
                      AppResources.ResourceFlowDirection);
            App.RootFrame.FlowDirection = flow;
            // Set the Language of the RootFrame to match the new culture.
            App.RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
       

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
