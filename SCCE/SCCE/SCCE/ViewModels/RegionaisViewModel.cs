using SCCE.Models;
using SCCE.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class RegionaisViewModel : BaseViewModel
    {
        private ObservableCollection<RegionalModel> regionais;

        public ObservableCollection<RegionalModel> Regionais
        {
            get => regionais;
            set
            {
                if (regionais != value)
                {
                    SetProperty(ref regionais, value);
                    OnPropertyChanged(nameof(Regionais));
                }
            }
        }

        public Command NavigatoToRegionalItem { get; protected set; }

        public RegionaisViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NavigatoToRegionalItem = new Command<RegionalModel>(async (param) =>
            {
                await ExecuteNavigateToRegionalItemCommand(param);
            });
            Regionais = new ObservableCollection<RegionalModel>(App.DataList);
        }

        private async Task ExecuteNavigateToRegionalItemCommand(RegionalModel param)
        {
            await Navigation.PushAsync(new LocalidadesPage(param));
        }
    }
}