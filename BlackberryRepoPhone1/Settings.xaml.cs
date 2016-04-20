using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BlackberryRepo.Portable.ViewModels;
using BlackberryRepo.Services;
using BlackberryRepoPhone1.Services;
using BlackberryRepoPhone1.Resources;
using System.Windows.Markup;

namespace BlackberryRepoPhone1
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
          
            this.Loaded += SettingsPage_Loaded;

          //  this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await App.MainViewModel.Initialize();
            AppSettingsViewModel settingsViewModel = new AppSettingsViewModel(new AppSettingsService(), new GlobalizationService(),null);
            
            PageTitle.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
            PageTitle.Text = AppResources.Settings;
            this.DataContext = settingsViewModel;
            /*ObservableCollection<Group<RepoItem>> list = App.MainViewModel.GetLanguages();
            longList.ItemsSource = list;*/
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    string guid = string.Empty;
        //    if (NavigationContext.QueryString.TryGetValue("guid", out guid))
        //    {
        //        //guid exists therefore it's a reload, so delete the last entry
        //        //from the navigation stack
        //      //  if (NavigationService.CanGoBack)
        //          //  NavigationService.RemoveBackEntry();
        //    }
        //}
    }
}