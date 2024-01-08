using Elementary.Core;
using System;
using System.Runtime.InteropServices;

namespace Elementary.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {

		private PageId currentPage;

		public PageId CurrentPage
		{
			get { return currentPage; }
			set { currentPage = value; OnPropertyChanged(); }
		}


		void NavigateView(PageId newPage)
		{
			// Navigate to new page
            CurrentPage = newPage;
			// currentPage changes, invokes OnPropertyChanged() from ObservableObject which updates the view
        }
		public RelayCommand NavigateCommand => new RelayCommand ((object pageId) => NavigateView((PageId)pageId));

		public MainViewModel() {
			// Default page
			CurrentPage = PageId.Home;	
		}

    }
}
