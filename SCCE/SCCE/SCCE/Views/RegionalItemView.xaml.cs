using Plugin.SharedTransitions;
using SCCE.Models;
using SCCE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionalItemView : ContentPage
    {
        public RegionalItemView(Regional regional)
        {
            InitializeComponent();
            BindingContext = new RegionalItemViewModel(Navigation, regional);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void UnidadeSelected(object sender, EventArgs e)
        {
            var unidade = (sender as View).BindingContext as UnidadeItem;
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, unidade.Id);
            await Navigation.PushAsync(new UnidadePageView(unidade));
        }

    }
}