using Elementary.Core;
using Elementary.MVVM.Stores;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Elementary.MVVM.ViewModels
{

    public class MainViewModel : ObservableObject
    {

        UserStore userStore;
        HomeViewModel homeViewModel;

        public ObservableCollection<PageId> NavigationItemList { get; set; }
        private PageId currentPage;
        public PageId CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value; OnPropertyChanged();
                
                switch(currentPage)
                {
                    case PageId.Discover:

                        break;
                    case PageId.Guide:
                        break;
                    case PageId.Information:
                        break;
                    default:
                        break;
                }
            }
        }
        public MainViewModel()
        {
            // Default page
            CurrentPage = PageId.Discover;

            // Data Contexts

            // Navigation items = PageId.Home, About, Info
            NavigationItemList = new ObservableCollection<PageId>
            {
                PageId.Discover,
                PageId.Guide,
                PageId.Information
            };

        }

    }
}
