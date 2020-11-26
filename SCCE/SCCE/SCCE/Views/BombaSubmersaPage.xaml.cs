using SCCE.Models;
using SCCE.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BombaSubmersaPage : ContentPage
    {
        readonly ObjetoFuncionalModel processo;
        readonly string startColor;
        readonly string endColor;
        public BombaSubmersaPage(ObjetoFuncionalModel processo, string startColor, string endColor)
        {
            InitializeComponent();
            this.processo = processo;
            this.startColor = startColor;
            this.endColor = endColor;
            
        }

        protected override void OnAppearing()
        {
            BindingContext = new BombaSubmersaViewModel(Navigation, processo, startColor, endColor);
        }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}