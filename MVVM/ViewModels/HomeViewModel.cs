using Elementary.Core;
using Elementary.MVVM.Models;
using Elementary.MVVM.Stores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Elementary.MVVM.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        // List of all elements
        public List<Element> AllElements { get; set; }

        // List of elements to display (can be filtered by search)
        public ObservableCollection<Element> Elements { get; set; }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }

        // Is Loading
        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }


        // Selected element
        private Element selectedElement;
        public Element SelectedElement
        {
            get { return selectedElement; }
            set
            {
                selectedElement = value;
                OnPropertyChanged();
                IsSelected = selectedElement != null;
            }
        }


        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();

                // Update list based on search text
                Elements.Clear();
                foreach (Element element in AllElements)
                {
                    if (element.Name.ToLower().Contains(searchText.ToLower()))
                    {
                        Elements.Add(element);
                    }
                }
            }
        }


        public HomeViewModel()
        {
            IsLoading = true;

            // Initialize lists
            AllElements = new List<Element>();
            Elements = new ObservableCollection<Element>();

            if (ElementStore.Elements != null)
            {
                foreach (Element element in ElementStore.Elements)
                {
                    AllElements.Add(element);
                    Elements.Add(element);
                }

                IsLoading = false;
            }
            else
            {
                _ = GetElementsAsync().ContinueWith((task) =>
                {
                    foreach (Element element in task.Result)
                    {
                        // https://stackoverflow.com/a/18336392
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            AllElements.Add(element);
                            Elements.Add(element);
                        });
                    }

                    ElementStore.Elements = task.Result;
                    // Do not define outside because this is a different thread
                    IsLoading = false;
                });
            }

        }
        public async Task<List<Element>> GetElementsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Get url
                var configJson = File.ReadAllText("../../config.json");
                dynamic config = JsonConvert.DeserializeObject(configJson);
                string url = config["BaseApiUrl"];

                // Fetch
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                // Deserialize
                return JsonConvert.DeserializeObject<List<Element>>(json);
            }

        }
    }
}
