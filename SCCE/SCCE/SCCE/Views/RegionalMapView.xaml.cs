using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.IO;
using SCCE.ViewModels;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionalMapView : ContentPage
    {
        
        public RegionalMapView()
        {
            InitializeComponent();
            BindingContext = new RegionalMapViewModel(Navigation);
        }

    }
}