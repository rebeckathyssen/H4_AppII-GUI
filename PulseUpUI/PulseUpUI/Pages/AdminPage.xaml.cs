using PulseUpUI.Models;
using PulseUpUI.RestAPIClient;
using PulseUpUI.ServiceHandler;
using PulseUpUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PulseUpUI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            var vm = new ListViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            
            //FetchItFfs();
        }

        //public async void FetchItFfs()
        //{
        //    var listService = new ListService();
        //    var test = await listService.GetUsers();
        //    ListView1.ItemsSource = test;
        //}
    }
}