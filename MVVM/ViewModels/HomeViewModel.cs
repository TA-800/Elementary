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
        public ObservableCollection<Element> Elements { get; set; }

        // Selected element
        private Element selectedElement;
        public Element SelectedElement
        {
            get { return selectedElement; }
            set { selectedElement = value; OnPropertyChanged(); }
        }

        public HomeViewModel()
        {

            Elements = new ObservableCollection<Element>();

            if (ElementStore.Elements != null)
            {
                foreach (Element element in ElementStore.Elements)
                {
                    Elements.Add(element);
                }

            }
            else
            {
                _ = GetElementsAsync().ContinueWith((task) =>
                {
                    foreach (Element element in task.Result)
                    {
                        // Users.Add(user);
                        // https://stackoverflow.com/a/18336392
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            Elements.Add(element);
                        });
                    }

                    ElementStore.Elements = task.Result;
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
