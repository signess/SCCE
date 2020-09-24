using SCCE.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionaisPage : ContentPage
    {
        
        public RegionaisPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            BindingContext = new RegionaisViewModel(Navigation);
        }


    }
}