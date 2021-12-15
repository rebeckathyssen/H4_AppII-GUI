using PulseUpUI.Models;
using PulseUpUI.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PulseUpUI.ServiceHandler
{
    public class RegisterService
    {
        // fetch the RestClient<T>
        RestClient<User> _restClient = new RestClient<User>();

        public async Task<bool> CreateUser(string username, string password)
        {
            //var user = new User() { Username = username, Password = password };
            
            var check = await _restClient.postUser(username, password);

            return check;
        }
    }
}
