using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SCCE.Views;
using Plugin.SharedTransitions;
using Xamarin.Essentials;

[assembly: ExportFont("NunitoSans-Regular.ttf", Alias = "ThemeFontRegular")]
[assembly: ExportFont("NunitoSans-Bold.ttf", Alias = "ThemeFontBold")]
[assembly: ExportFont("NunitoSans-SemiBold.ttf", Alias = "ThemeFontMedium")]
namespace SCCE
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
