using BlackberryRepo.Portable.Enumerations;
using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BlackberryRepo.Services
{
     public class StyleService :IStyleService
    {
         public void SetStyle(Theme theme)
            {
                var frame = Window.Current.Content as Frame;
             switch(theme)
             {
                 case Theme.DARK:
                     frame.Background =new SolidColorBrush(Colors.CadetBlue);
                     break;
                case Theme.LIGHT:
                     frame.Background = new SolidColorBrush(Colors.Red);
                     break;


             }
  
            }
      
    }
}
