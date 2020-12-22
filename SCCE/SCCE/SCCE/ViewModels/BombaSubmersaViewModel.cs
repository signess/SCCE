using SCCE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class BombaSubmersaViewModel : BaseViewModel
    {
        private ObjetoFuncionalModel processo;
        public ObjetoFuncionalModel Processo
        {
            get => processo;
            private set => SetProperty(ref processo, value);
        }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }

        public bool IsEmpty { get { return BombaSubmersa.Count <= 0; } }
        public bool IsNotEmpty { get { return !IsEmpty; } }
        public ObservableCollection<ObjetoSerialModel> BombaSubmersa => GetProperties();

        private ObservableCollection<ObjetoSerialModel> GetProperties()
        {
            if (Processo.BombaSubmersa != null)
            {
                return new ObservableCollection<ObjetoSerialModel>(Processo.BombaSubmersa);
            }
            else
            {
                return new ObservableCollection<ObjetoSerialModel>();
            }
        }

        public BombaSubmersaViewModel(INavigation navigation, ObjetoFuncionalModel processo, string startColor, string endColor)
        {
            Navigation = navigation;
            Processo = processo;
            BackgroundStartColor = startColor;
            BackgroundEndColor = endColor;
        }
    }
}
