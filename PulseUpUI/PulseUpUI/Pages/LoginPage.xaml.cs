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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            //var vm = new LoginViewModel();
            //this.BindingContext = vm;
            
            InitializeComponent();
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(Email.Text, Password.Text);

            if (getLoginDetails)
            {
                //await DisplayAlert("Login succes", "Du logges ind...", "Okay");
                //await Navigation.PushAsync(new AdminPage());
                App.Current.MainPage = new AdminPage();
            }
            else
            {
                await DisplayAlert("Login fejlede", "Fejl i login", "Annullér");
            }
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new RegisterPage();
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}