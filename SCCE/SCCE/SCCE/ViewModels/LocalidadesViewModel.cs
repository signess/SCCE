using SCCE.Models;
using SCCE.Views;
using System.Collections.ObjectModel;
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
        private Command<LocalidadeModel> navigatetoProcessos;
        public Command<LocalidadeModel> NavigateToProcessos
        {
            get
            {
                return navigatetoProcessos ?? (navigatetoProcessos = new Command<LocalidadeModel>(localidadeModel =>
                {
                    Navigation.PushAsync(new ProcessosPage(localidadeModel, BackgroundStartColor, BackgroundEndColor));
                }));
            }
        }

        private ObservableCollection<LocalidadeModel> GetProperties()
        {
            return new ObservableCollection<LocalidadeModel>(Regional.Localidades);
        }


        public LocalidadesViewModel(INavigation navigation, RegionalModel regional)
        {
            Navigation = navigation;
            Regional = regional;
            
            LocalidadesList = GetProperties();
            foreach(LocalidadeModel localidade in LocalidadesList)
            {
                var nome = Extensions.Extensions.RemoveWhitespace(localidade.Nome);
                localidade.Image = nome + ".jpg";
            }
        }

    }
}
