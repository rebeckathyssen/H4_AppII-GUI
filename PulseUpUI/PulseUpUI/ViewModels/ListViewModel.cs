using PulseUpUI.Models;
using PulseUpUI.Pages;
using PulseUpUI.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PulseUpUI.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RemoveUserCommand => new Command(RemoveUser);
        public ICommand UpdateUserCommand => new Command(UpdateUser);

        private ObservableCollection<User> _users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged("_users"); } 
        }

        public User SelectedUser { get; set; }

        public User updatedUser = new User();

        public string NewUsername { get; set; }
        public string NewPassword { get; set; }

        // constructor
        public ListViewModel()
        {
           FetchItFfs();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void FetchItFfs()
        {
            _users = new ObservableCollection<User>();

            var listService = new ListService();
            var test = await listService.GetUsers();

            // Users = await listService.GetUsers();  <- will break the application
            // _users = await listService.GetUsers(); <- will not show anything

            foreach (var something in test)
            {
                _users.Add(something); // <- does not update data when stuff is deleted directly from the API
            }
        }

        public async void RemoveUser()
        {
            var listService = new ListService();
            var delete = await listService.RemoveUser(SelectedUser);
            if (delete)
            {
                Users.Remove(SelectedUser);
            } else
            {
                Console.WriteLine("nope");
            }            
        }

        public async void UpdateUser()
        {
            updatedUser.Username = NewUsername;
            updatedUser.Password = NewPassword;
            updatedUser.Id = SelectedUser.Id;

            var listService = new ListService();
            var update = await listService.UpdateUser(updatedUser);
            if (update)
            {
                int newIndex = Users.IndexOf(SelectedUser);
                Users.Remove(SelectedUser);

                Users.Add(updatedUser);
                int oldIndex = Users.IndexOf(updatedUser);

                Users.Move(oldIndex, newIndex);
            } else
            {
                Console.WriteLine("definitely nope");
            }
        }
    }
}
