using BlackberryRepo.Controls;
using BlackberryRepo.Portable.Interfaces;
using Callisto.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace BlackberryRepo.Services
{
    public class SettingsService : ISettingsService
    {
        SettingsFlyout settings = null;
        double _settingsWidth = 346;
        Rect _windowBounds;

        private IResourcesService resourcesService;
        public SettingsService(IResourcesService resourcesService)
        {
            this.resourcesService = resourcesService;
        }

        public void Initialize()
        {
            SettingsPane settingsPane = SettingsPane.GetForCurrentView();
            _windowBounds = Window.Current.Bounds;
            settingsPane.CommandsRequested += OnSettingsPaneCommandsRequested;
        }

        //SettingsFlyout settings = null;
        public void OnSettingsPaneCommandsRequested(object sender, object args)
        {
            SettingsCommand settingsCommand = new SettingsCommand(0,resourcesService.GetString("Settings"), (x) =>
            {
                settings = new SettingsFlyout();
                settings.Closed += settings_Closed;
                settings.Content = new SettingsControl();
                settings.HeaderText = resourcesService.GetString("Settings");
                Window.Current.Activated += Current_Activated;

               //SolidColorBrush bg = (SolidColorBrush)resourcesService.GetApplicationResource("ApplicationPageBackgroundThemeBrush");
              //  settings.HeaderBrush = bg;
                //settings.Background = new SolidColorBrush(Colors.Red);
                settings.IsOpen = true;
            });
            SettingsPaneCommandsRequestedEventArgs settingsArgs = args as SettingsPaneCommandsRequestedEventArgs;
            if (!settingsArgs.Request.ApplicationCommands.Contains(settingsCommand))
                settingsArgs.Request.ApplicationCommands.Add(settingsCommand);
            

        }

        void settings_Closed(object sender, object e)
        {
            Window.Current.Activated -= Current_Activated;
        }

        void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            //if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            //    settings.IsOpen = false;
        }
       
        private void OnSettingsCommandInvoked(IUICommand command)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            SettingsControl settingsControl = new SettingsControl();
            settingsControl.Height = rootFrame.ActualHeight;
            //settingsControl.Width = 300;

            Popup popup = new Popup()
            {
                IsLightDismissEnabled = true,
                Child = settingsControl,
                IsOpen = true,
                HorizontalOffset = rootFrame.ActualWidth - settingsControl.Width
            };
        }
    }
}
