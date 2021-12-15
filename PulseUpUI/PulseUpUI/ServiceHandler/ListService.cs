using PulseUpUI.Models;
using PulseUpUI.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PulseUpUI.ServiceHandler
{
    public class ListService
    {
        // fetch the RestClient<T>
        RestClient<User> _restClient = new RestClient<User>();

        //public async Task<ObservableCollection<User>> GetUsers()
        //{
        //    var users = await _restClient.getUsers();

        //    return users;
        //}

        public async Task<ObservableCollection<User>> GetUsers()
        {
            var users = await _restClient.RefreshDataAsync();

            return users;
        }

        public async Task<bool> RemoveUser(User user)
        {
            var deleteIt = await _restClient.DeleteUser(user);
            return deleteIt;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var updateIt = await _restClient.UpdateUser(user);
            return updateIt;
        }
    }
}
