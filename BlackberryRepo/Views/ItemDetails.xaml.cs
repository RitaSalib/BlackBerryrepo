using BlackberryRepo.Portable.Models;
using BlackberryRepo.Portable.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace BlackberryRepo.Views
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetails : BlackberryRepo.Common.LayoutAwarePage
    {
         private const string ITEM_VIEW_MODEL = "itemViewModel";
        private ItemViewModel itemViewModel;
        RepoItem repo;
        private DataTransferManager dtm;

        public ItemDetails()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += dtm_DataRequested;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            dtm.DataRequested -= dtm_DataRequested;
        }


        void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            Uri linkSource = new Uri(repo.html_url);
            string linkTitle = repo.name;
            string linkDescription = repo.description;  //This is an optional value.

            DataPackage data = args.Request.Data;
            data.Properties.Title = linkTitle;
            data.Properties.Description = linkDescription;
            data.SetUri(linkSource);
        }
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Allow saved page state to override the initial item to display
            if (pageState != null)
            {
                if (pageState.ContainsKey(ITEM_VIEW_MODEL))
                {
                    if (pageState[ITEM_VIEW_MODEL] != null)
                    {
                        this.itemViewModel = pageState[ITEM_VIEW_MODEL] as ItemViewModel;
                    }
                }
            }

            if (itemViewModel == null)
            {
                if (navigationParameter != null)
                {
                    repo = navigationParameter as RepoItem;
                    itemViewModel = new ItemViewModel(repo);

                }
            }

            if (itemViewModel != null)
            {
                this.DataContext = itemViewModel;
            }
        }

        

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
           // var selectedItem = this.flipView.SelectedItem;
            // TODO: Derive a serializable navigation parameter and assign it to pageState["SelectedItem"]
        }
    }
}
