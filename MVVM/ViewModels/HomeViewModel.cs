using Elementary.Core;
using Elementary.MVVM.Models;
using Elementary.MVVM.Stores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Elementary.MVVM.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public ObservableCollection<User> Users { get; set; }
        public HomeViewModel()
        {

            Users = new ObservableCollection<User>();

            if (UserStore.SavedUsers != null)
            {
                foreach (User user in UserStore.SavedUsers)
                {
                    Users.Add(user);
                }

            }
            else
            {
                _ = GetUserAsync().ContinueWith((task) =>
                {
                    foreach (User user in task.Result)
                    {
                        // Users.Add(user);
                        // https://stackoverflow.com/a/18336392
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            Users.Add(user);
                        });
                    }

                    UserStore.SavedUsers = task.Result;
                });
            }


        }
        public async Task<List<User>> GetUserAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }

        }
    }
}
