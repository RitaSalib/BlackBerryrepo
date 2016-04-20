using BlackberryRepo.Portable.Enumerations;
using BlackberryRepo.Portable.Interfaces;
using BlackberryRepo.Portable.Models;
using BlackberryRepo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlackberryRepo.Services
{
    public class NavigationService : INavigationService
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
            Frame currentFrame = Window.Current.Content as Frame;
            RepoItem item = (RepoItem)parameter;

            if (parameter != null)
                currentFrame.Navigate(typeof(ItemDetails), parameter);
            else
                currentFrame.Navigate(typeof(ItemDetails));

            
        }
    }
}
