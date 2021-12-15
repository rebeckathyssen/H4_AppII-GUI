using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Comforter-Regular.ttf", Alias = "CoolFont")]
namespace PulseUpUI
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            // MainPage = new Pages.LoginPage();
            MainPage = new NavigationPage(new Pages.LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
