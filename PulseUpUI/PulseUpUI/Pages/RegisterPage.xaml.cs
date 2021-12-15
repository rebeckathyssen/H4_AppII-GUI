using PulseUpUI.ServiceHandler;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            RegisterService registerService = new RegisterService();
            // TO DO: Lav tjek på om bruger allerede eksisterer
            var createUser = await registerService.CreateUser(Email.Text, Password.Text);

            if (createUser)
            {
                //await DisplayAlert("Bruger oprettet!", "Du logges ind...", "Okay");
                await Navigation.PushAsync(new AdminPage());
            } else
            {
                await DisplayAlert("Oprettelse fejlede", "Bruger findes allerede!", "Annullér");
            }
        }

    }
}