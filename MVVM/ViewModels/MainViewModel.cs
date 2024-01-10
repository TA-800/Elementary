using Elementary.Core;
using Elementary.MVVM.Stores;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Elementary.MVVM.ViewModels
{

    public class MainViewModel : ObservableObject
    {
        HomeViewModel homeViewModel;

        public ObservableCollection<PageId> NavigationItemList { get; set; }
        private PageId currentPage;
        public PageId CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value; OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            // Default page
            CurrentPage = PageId.Discover;

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
