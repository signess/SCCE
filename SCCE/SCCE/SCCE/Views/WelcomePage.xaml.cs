using SCCE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        readonly bool DB;
        public WelcomePage(bool dbFound)
        {
            InitializeComponent();
            DB = dbFound;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new WelcomeViewModel(Navigation, DB);
        }
    }
}