using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using PulseUpUI.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace PulseUpUI.RestAPIClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "http://10.0.2.2:58871/api/User/"; // Put your main host url here
        private const string LoginWebServiceUrl = MainWebServiceUrl + "GetUserDetails/"; // put your api extension url/uri here
        private const string CreateWebServiceUrl = MainWebServiceUrl + "Post/";

        // This code matches the HTTP Request that we included in our api controller
        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();
             
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);

            return response.IsSuccessStatusCode; // return either true or false
        }

        // POST new user
        public async Task<bool> postUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                var userExists = await client.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);
                if (userExists.IsSuccessStatusCode)
                {
                    return false; 
                } 
                else
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var userObject = new User() { Username = username, Password = password };
                    string jsonObject = JsonConvert.SerializeObject(userObject);

                    var content2 = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                    var result2 = await client.PostAsync("http://10.0.2.2:58871/api/User/Post", content2);

                    return result2.IsSuccessStatusCode;
                }
            }
        }

        // Get ALL users
        public async Task<ObservableCollection<User>> getUsers()
        {
            using (var client = new HttpClient())
            {
                var res = await client.GetStringAsync("http://10.0.2.2:58871/api/User/List");
                var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(res);
                return list;
            }
        }

        // test
        public ObservableCollection<User> Users { get; set; }

        public async Task<ObservableCollection<User>> RefreshDataAsync()
        {
            Users = new ObservableCollection<User>();
            var uri = new Uri("http://10.0.2.2:58871/api/User/List");
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(content);
                    }
                    
                } catch (Exception e)
                {
                    Console.WriteLine("Merp: " + e.Message);
                }
                return Users;
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            Guid id = user.Id;
            Uri uri = new Uri(string.Format("http://10.0.2.2:58871/api/User/Delete/" + id));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            Uri uri = new Uri(string.Format("http://10.0.2.2:58871/api/User/Put", user));

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync(uri, content);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
