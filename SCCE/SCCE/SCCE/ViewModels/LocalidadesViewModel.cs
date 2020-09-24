using Android.Content.Res;
using Plugin.SharedTransitions;
using SCCE.Models;
using SCCE.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class LocalidadesViewModel : BaseViewModel
    {
        private RegionalModel Regional { get; set; }
        public string BackgroundStartColor => Regional.BackgroundStartColor;
        public string BackgroundEndColor => Regional.BackgroundEndColor;
        public string Nome => Regional.Nome;
        public ObservableCollection<LocalidadeModel> LocalidadesList { get; set; }
        public Command NavigateToProcessos { get; protected set; }

        private ObservableCollection<LocalidadeModel> GetProperties()
        {
            return new ObservableCollection<LocalidadeModel>(Regional.Localidades);
        }

        private string selectedLocalidadeId;
        public string SelectedLocalidadeId
        {
            get => selectedLocalidadeId;
            set => SetProperty(ref selectedLocalidadeId, value);
        }

        public LocalidadesViewModel(INavigation navigation, RegionalModel regional)
        {
            Navigation = navigation;
            Regional = regional;
            NavigateToProcessos = new Command<LocalidadeModel>(async (param) =>
            {
                SelectedLocalidadeId = param.Id;
                await ExecuteNavigateToProcessosCommand(param);
            });
            LocalidadesList = GetProperties();
            foreach(LocalidadeModel localidade in LocalidadesList)
            {
                var nome = Extensions.Extensions.RemoveWhitespace(localidade.Nome);
                localidade.Image = nome + ".jpg";
            }
        }

        private async Task ExecuteNavigateToProcessosCommand(LocalidadeModel param)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new ProcessosPage(param, BackgroundStartColor, BackgroundEndColor));
                IsBusy = false;
            }
        }


    }
}
