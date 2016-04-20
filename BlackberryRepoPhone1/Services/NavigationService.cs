using BlackberryRepo.Portable.Enumerations;
using BlackberryRepo.Portable.Models;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlackberryRepoPhone1.Services
{
    public class NavigationService : BlackberryRepo.Portable.Interfaces.INavigationService
    {
        public void NavigateTo(ApplicationSection section)
        {

        }


        public void NavigateTo(object parameter)
        {
            NavigateToPage(parameter);

        }

        private void NavigateToPage(object parameter)
        {
            Frame currentFrame = (Application.Current.RootVisual as PhoneApplicationFrame);
            RepoItem item = (RepoItem)parameter;

             if (parameter != null)
             currentFrame.Navigate(new Uri("/Page2.xaml?parameter="+item.id, UriKind.Relative));
            else
                 currentFrame.Navigate(new Uri("/Page2.xaml", UriKind.Relative));


        }
    }  
}
