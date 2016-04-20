using BlackberryRepo.Portable.ViewModels;
using BlackberryRepo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BlackberryRepo.Controls
{
    public sealed partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            this.InitializeComponent();
            AppSettingsViewModel settingsViewModel = new AppSettingsViewModel(new AppSettingsService(), new GlobalizationService(), new StyleService());
            this.DataContext = settingsViewModel;
        }

      
    }
}
