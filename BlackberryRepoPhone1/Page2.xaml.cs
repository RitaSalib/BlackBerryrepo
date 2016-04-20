using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BlackberryRepo.Portable.Models;

namespace BlackberryRepoPhone1
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value;
            if(NavigationContext.QueryString.TryGetValue("parameter",out value))
            {
                int id = Int32.Parse(value);
                RepoItem item = App.MainViewModel.GetItem(id);
                this.DataContext = item;
            }  
}
    }
}