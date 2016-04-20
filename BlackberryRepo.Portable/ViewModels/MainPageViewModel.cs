using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackberryRepo.Portable.Models;
using System.Threading.Tasks;
using BlackberryRepo.Portable.Interfaces;
using BlackberryRepo.Portable.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BlackberryRepo.Portable.Commands;
using System.ComponentModel;
using BlackberryRepo.Portable.Enumerations;

namespace BlackberryRepo.Portable.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Group<RepoItem>> Items { get; set; }
        private IFileService fileService;
        private ISerializationService serializationService;
        private INavigationService navigationService;
        private IGlobalizationService globalizationService;
        private IResourcesService resourcesService;
        private ISettingsService settingsService;



        public ICommand ItemDetailsCommand
        {
            get;
            private set;
        }

        public bool IsDataLoaded = false;
        public ObservableCollection<RepoItem> repos { get; set; }
        ObservableCollection<Group<RepoItem>> groups;
        private bool _showProgressBar = false;
        public bool ShowProgressBar
        {
            get { return _showProgressBar; }
            set
            {
                _showProgressBar = value;
                OnPropertyChanged("ShowProgressBar");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");

            var changed = PropertyChanged;
            if (changed != null)
            {
                changed(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(ISerializationService serializationService, IFileService fileService, INavigationService navigationService, IGlobalizationService globalizationService, ISettingsService settingService, IResourcesService resourcesService)
        {
            this.Items = new ObservableCollection<Group<RepoItem>>();
            this.serializationService = serializationService;
            this.fileService = fileService;
            this.navigationService = navigationService;
            this.globalizationService = globalizationService;
            this.settingsService = settingService;
            this.resourcesService = resourcesService;
            this.ItemDetailsCommand = new DelegateCommand(NavigateToItemDetails);


        }


        public async Task Initialize()
        {

            //the main.xml file
            _showProgressBar = true;
            if (settingsService != null)
                settingsService.Initialize();

            object mainFile = await fileService.GetFile("BlackberryRepos.js");
            string mainFileContent = await fileService.ReadFileString(mainFile);

            repos = (ObservableCollection<RepoItem>)serializationService.DeSerialize(mainFileContent, typeof(ObservableCollection<RepoItem>));
            this.IsDataLoaded = true;
            if (this.repos.Count != 0)
                ShowProgressBar = false;


            var query = this.repos.GroupBy(x => x.language)
                       .Select(x => new Group<RepoItem>(x.Key, x));

            foreach (var item in query)
            {
                Items.Add(item);
            }

        }

        public ObservableCollection<Group<RepoItem>> GetLanguages()
        {

            groups = new ObservableCollection<Group<RepoItem>>();
            var query = this.repos.GroupBy(x => x.language)
                       .Select(x => new Group<RepoItem>(x.Key, x));

            foreach (var item in query)
            {
                groups.Add(item);
            }

            return groups;

        }

        public IEnumerable<RepoItem> GetSearchResults(string searchString)
        {

            IEnumerable<RepoItem> searchResults = from el in repos
                                                  where el.name.ToLower().Contains(searchString)
                                                  orderby el.name ascending
                                                  select el;
            return searchResults;

        }

      
        public RepoItem GetItem(int id)
        {

            RepoItem repo = new RepoItem();
            var query = this.repos.FirstOrDefault(i => i.id == id);

            repo = (RepoItem)query;
            return repo;

        }
        private void NavigateToItemDetails(object parameter)
        {
            this.navigationService.NavigateTo(parameter);

        }
    }
    public class Group<RepoItem> : ObservableCollection<RepoItem>
    {

        public Group(string name, IEnumerable<RepoItem> items)
            : base(items)
        {
            this.GroupName = name;
        }
        public string GroupName { get; set; }


    }
}

