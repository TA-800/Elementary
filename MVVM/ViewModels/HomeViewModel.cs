using Elementary.Core;
using Elementary.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Elementary.MVVM.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        private User myUser;
        public User MyUser
        {
            get { return myUser; }
            set { myUser = value; OnPropertyChanged(); }
        }
        public HomeViewModel()
        {
            _ = GetUserAsync().ContinueWith((task) =>
            {
                MyUser = task.Result;
            });

        }
        public async Task<User> GetUserAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users/1");
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                return JsonConvert.DeserializeObject<User>(json);
            }

        }
    }
}
