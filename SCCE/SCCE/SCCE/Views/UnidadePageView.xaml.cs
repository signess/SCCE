using Plugin.SharedTransitions;
using SCCE.Models;
using SCCE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnidadePageView : ContentPage
    {
        public UnidadePageView(RegionalModel unidade)
        {
            InitializeComponent();
            this.UnidadeItem = unidade;
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        public RegionalModel UnidadeItem { get; set; }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void UnidadeTapped(object sender, EventArgs e)
        {
            var processo = (sender as View).BindingContext as ProcessosItem;
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, processo.Id);
            Navigation.PushAsync(new FinalView(processo, UnidadeItem.BackgroundStartColor, UnidadeItem.BackgroundEndColor));
        }
    }
}