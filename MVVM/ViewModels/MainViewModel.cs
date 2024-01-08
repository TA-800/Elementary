using Elementary.Core;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Elementary.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        public ObservableCollection<PageId> NavigationItemList { get; set; }

        private PageId currentPage;
        public PageId CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            // Default page
            CurrentPage = PageId.Home;

            // Navigation items = PageId.Home, About, Info
            NavigationItemList = new ObservableCollection<PageId>
            {
                PageId.Home,
                PageId.About,
                PageId.Info
            };

        }

    }
}
