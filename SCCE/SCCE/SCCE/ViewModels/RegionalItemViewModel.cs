using SCCE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class RegionalItemViewModel : BaseViewModel
    {
        public RegionalItemViewModel(INavigation navigation, Regional regional)
        {
            Navigation = navigation;
            Regional = regional;
        }

        public Regional Regional { get; set; }

        public ObservableCollection<UnidadeItem> UnidadesList => GetProperties();

        private ObservableCollection<UnidadeItem> GetProperties()
        {
            return new ObservableCollection<UnidadeItem>(Regional.Unidades);
        }
    }

}
