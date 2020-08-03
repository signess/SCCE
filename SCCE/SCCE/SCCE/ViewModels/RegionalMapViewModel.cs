using SCCE.Models;
using SCCE.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class RegionalMapViewModel : BaseViewModel
    {
        public RegionalMapViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NavigatoToRegionalItem = new Command<Regional>(async (param) => await ExecuteNavigateToRegionalItemCommand(param));
            Regionais = new ObservableCollection<Regional>(GetRegionais());
        }

        public ObservableCollection<Regional> Regionais { get; set; }
        public Command NavigatoToRegionalItem { get; }
        public static ObservableCollection<Regional> GetRegionais()
        {
            return new ObservableCollection<Regional>()
            {
                new Regional()
                {
                    Nome = "Corumbá",
                    backgroundStartColor = "#68B265",
                    backgroundEndColor = "#559152",
                },
                new Regional()
                {
                    Nome = "Aquidauana",
                    backgroundStartColor = "#32B300",
                    backgroundEndColor = "#2A9600",
                },
                new Regional()
                {
                    Nome = "Jardim",
                    backgroundStartColor = "#98E603",
                    backgroundEndColor = "#82C103",
                },
                new Regional()
                {
                    Nome = "Dourados",
                    backgroundStartColor = BackgroundColors.DouradosStart,
                    backgroundEndColor = BackgroundColors.DouradosEnd,
                    Unidades = new List<UnidadeItem>()
                    {
                        new UnidadeItem { backgroundEndColor = BackgroundColors.DouradosEnd, backgroundStartColor=BackgroundColors.DouradosStart, Image = "dourados.jpg", Nome = "Dourados", ProcessosList =
                             new List<ProcessosItem> { new ProcessosItem { Locins = "4215", ProcessoName = "Dou-001", Address = "Rua Contra Mao, 231, Jd. Maromba", BombaSubmersa = new BombaSubmersaItem { CorrenteNominal = "1" } },
                                 new ProcessosItem { Locins = "3331", ProcessoName = "Dou-002", Address = "Rua Judas Sem Botas, 1111, Jd. Lugar Nenhum" } } },
                        new UnidadeItem { backgroundStartColor = BackgroundColors.DouradosStart, backgroundEndColor = BackgroundColors.DouradosEnd, Image = "maracaju.jpg", Nome = "Maracaju" }
                    }
                },
                new Regional()
                {
                    Nome = "Ponta Porã",
                    backgroundStartColor = "#feb103",
                    backgroundEndColor = "#b57e02",
                },
                new Regional()
                {
                    Nome = "Coxim",
                    backgroundStartColor = "#6599FF",
                    backgroundEndColor = "#5988E0",
                },
                new Regional()
                {
                    Nome = "Três Lagoas",
                    backgroundStartColor = "#FE7E00",
                    backgroundEndColor = "#CE6300",
                },
                new Regional()
                {
                    Nome = "Paranaíba",
                    backgroundStartColor = "#FE4B4E",
                    backgroundEndColor = "#D84146",
                },
                new Regional()
                {
                    Nome = "Nova Andradina",
                    backgroundStartColor = "#33BECC",
                    backgroundEndColor = "#2896A0",
                },
                new Regional()
                {
                    Nome = "Naviraí",
                    backgroundStartColor = "#039079",
                    backgroundEndColor = "#016353",
                }
            };
        }

        private async Task ExecuteNavigateToRegionalItemCommand(Regional param)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new RegionalItemView(param));
                IsBusy = false;
            }
        }
    }
}