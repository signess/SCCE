using Android;
using SCCE.Models;
using SCCE.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class LocalidadesViewModel : BaseViewModel
    {
        private RegionalModel Regional { get; set; }
        public string BackgroundStartColor => Regional.BackgroundStartColor;
        public string BackgroundEndColor => Regional.BackgroundEndColor;
        public string Nome => Regional.Nome;
        public string PlaceHolder { get; set; }
        public ObservableCollection<ObjetoFuncionalModel> LocalidadesList { get; set; }
        private Command<ObjetoFuncionalModel> navigatetoProcessos;
        public Command<ObjetoFuncionalModel> NavigateToProcessos
        {
            get
            {
                return navigatetoProcessos ?? (navigatetoProcessos = new Command<ObjetoFuncionalModel>(localidadeModel =>
                {
                    Navigation.PushAsync(new ProcessosPage(localidadeModel, BackgroundStartColor, BackgroundEndColor));
                }));
            }
        }

        private ObservableCollection<ObjetoFuncionalModel> GetProperties()
        {
            return new ObservableCollection<ObjetoFuncionalModel>(Regional.Localidades);
        }


        public LocalidadesViewModel(INavigation navigation, RegionalModel regional)
        {
            Navigation = navigation;
            Regional = regional;
            LocalidadesList = GetProperties();
            foreach(ObjetoFuncionalModel localidade in LocalidadesList)
            {
                var nome = Extensions.Extensions.RemoveWhitespace(localidade.Descricao);
                nome = string.Format(nome + ".jpg");
                localidade.Image = nome;   
            }
        }

    }
}
