using SCCE.Models;
using SCCE.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessosPage : ContentPage
    {
        readonly ObjetoFuncionalModel localidade;
        readonly string startColor;
        readonly string endColor;
        public ProcessosPage(ObjetoFuncionalModel localidade, string startColor, string endColor)
        {
            InitializeComponent();
            this.localidade = localidade;
            this.startColor = startColor;
            this.endColor = endColor;

        }

        protected override void OnAppearing()
        {
            BindingContext = new ProcessosViewModel(Navigation, localidade, startColor, endColor);
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}