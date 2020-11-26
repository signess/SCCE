using SCCE.Models;
using SCCE.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class ProcessosViewModel : BaseViewModel
    {
        private ObjetoFuncionalModel localidade;
        public ObjetoFuncionalModel Localidade
        {
            get => localidade;
            private set => SetProperty(ref localidade, value);
        }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
        public ObservableCollection<ObjetoFuncionalModel> ProcessosList => GetProperties();

        private ObservableCollection<ObjetoFuncionalModel> GetProperties()
        {
            return new ObservableCollection<ObjetoFuncionalModel>(Localidade.Processos);
        }

        private Command<ObjetoFuncionalModel> navigateToBombaSubmersa;
        public Command<ObjetoFuncionalModel> NavigateToBombaSubmersa
        {
            get
            {
                return navigateToBombaSubmersa ?? (navigateToBombaSubmersa = new Command<ObjetoFuncionalModel>(processoModel =>
                {
                    Console.WriteLine($"BombaSubmersaCount: {processoModel.BombaSubmersa.Count}");
                    Navigation.PushAsync(new BombaSubmersaPage(processoModel, BackgroundStartColor, BackgroundEndColor));
                }));
            }
        }

        public ProcessosViewModel(INavigation navigation, ObjetoFuncionalModel localidade, string startColor, string endColor)
        {
            Navigation = navigation;
            Localidade = localidade;
            BackgroundStartColor = startColor;
            BackgroundEndColor = endColor;
        }

    }
}
