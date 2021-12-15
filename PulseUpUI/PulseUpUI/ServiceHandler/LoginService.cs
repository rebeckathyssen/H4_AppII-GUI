using PulseUpUI.Models;
using PulseUpUI.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PulseUpUI.ServiceHandler
{
    public class LoginService
    {
        // fetch the RestClient<T>
        RestClient<User> _restClient = new RestClient<User>();

        // Boolean function with the following parameters of username & password.
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);

            return check;
        }
    }
}
