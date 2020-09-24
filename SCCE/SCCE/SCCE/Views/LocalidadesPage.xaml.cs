using Plugin.SharedTransitions;
using SCCE.Models;
using SCCE.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalidadesPage : ContentPage
    {
        readonly RegionalModel regional;
        public LocalidadesPage(RegionalModel regional)
        {
            InitializeComponent();
            this.regional = regional;
        }

        protected override void OnAppearing()
        {
            BindingContext = new LocalidadesViewModel(Navigation, regional);
        }
        
        private void ProcessoSelected(object sender, EventArgs e)
        {
            /*
            var processo = (sender as View).BindingContext as ProcessosModel;
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, processo.Id);
            //await Navigation.PushAsync(new UnidadePageView(processo));*/
        }
    }
}