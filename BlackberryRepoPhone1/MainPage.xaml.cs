using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BlackberryRepoPhone1.Resources;
using BlackberryRepo.Portable.ViewModels;
using BlackberryRepo.Portable.Models;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.Globalization;
using System.Threading;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.Phone.Tasks;

namespace BlackberryRepoPhone1
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        bool toggle = false;
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;   
            //App.MainViewModel.Initialize();


            //var rd = App.Current.Resources["styles"] as ResourceDictionary;
            //var rd1 = rd.MergedDictionaries[1];

            //// Set custom Theme
            //ThemeManager.SetCustomTheme(rd1, Theme.Dark);
            //var style = rd1["ImageTest"] as Style;
            //LayoutRoot.Style = style;
           
            // Sample code to localize the ApplicationBar
           BuildLocalizedApplicationBar();
          
        }

        private void BuildLocalizedApplicationBar()
        {  // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create new menu items with hard-coded, translated values for the language selections.
            //These do not localize.
            ApplicationBarMenuItem en_appBarMenuItem = new ApplicationBarMenuItem("English");
            ApplicationBarMenuItem ar_appBarMenuItem = new ApplicationBarMenuItem("العربية");
            ApplicationBarMenuItem share_appBarMenuItem = new ApplicationBarMenuItem("share");
           // ApplicationBarMenuItem ar_appBarMenuItem = new ApplicationBarMenuItem(AppResources.Settings);
            ApplicationBar.MenuItems.Add(en_appBarMenuItem);
            ApplicationBar.MenuItems.Add(ar_appBarMenuItem);
            ApplicationBar.MenuItems.Add(share_appBarMenuItem);

            en_appBarMenuItem.Click += new EventHandler(en_appBarMenuItem_Click);
            ar_appBarMenuItem.Click += new EventHandler(ar_appBarMenuItem_Click);
            share_appBarMenuItem.Click += new EventHandler(share_appBarMenuItem_Click);

        }

        private void share_appBarMenuItem_Click(object sender, EventArgs e)
        {
            //ShareLinkTask shareLinkTask = new ShareLinkTask();

            //shareLinkTask.Title = "Code Samples";
            //shareLinkTask.LinkUri = new Uri("http://code.msdn.com/wpapps", UriKind.Absolute);
            //shareLinkTask.Message = "Here are some great code samples for Windows Phone.";

            //shareLinkTask.Show();
            // Get the custom theme
            var rd = App.Current.Resources["styles"] as ResourceDictionary;

            //int x = 5;
            if (!toggle)
            {
               
                var rd1 = rd.MergedDictionaries[0];


                // Set custom Theme
                ThemeManager.SetCustomTheme(rd1, Theme.Dark);

                //var style = rd1["ImageTest"] as Style;
                //LayoutRoot.Style = style;
                toggle = true;
            }
            else
            {
                var rd1 = rd.MergedDictionaries[1];

                // Set custom Theme
                ThemeManager.SetCustomTheme(rd1, Theme.Dark);
                //var style = rd1["ImageTest"] as Style;
                //LayoutRoot.Style = style;
                toggle = false;
 
            }

        }

        private void en_appBarMenuItem_Click(object sender, EventArgs e)
        {
            SetUILanguage("en-US");
        }

        
        private void ar_appBarMenuItem_Click(object sender, EventArgs e)
        {
            SetUILanguage("ar");
        }



        private void SetUILanguage(string locale)
        {
            CultureInfo newCulture = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection),
             AppResources.ResourceFlowDirection);
            App.RootFrame.FlowDirection = flow;

            // Set the Language of the RootFrame to match the new culture.
            App.RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
            PageTitle.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
            PageTitle.Text = AppResources.Repositories;
        }
         void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await App.MainViewModel.Initialize();
            this.DataContext = App.MainViewModel;
            /*ObservableCollection<Group<RepoItem>> list = App.MainViewModel.GetLanguages();
            longList.ItemsSource = list;*/

           

        }

         private void Settings_Click(object sender, EventArgs e)
         {
             this.NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
         }

        
      
    }
}