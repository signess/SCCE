using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SCCE.Data;
using SCCE.Models;
using SCCE.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views.Database
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : PopupPage
    {
        private readonly APIService apiService = new APIService();

        private readonly DataRepository _dataRepository;

        public DataPage()
        {
            InitializeComponent();
            _dataRepository = new DataRepository();
        }

        private async Task TryLogin()
        {
            LoginService services = new LoginService();
            var getLoginDetail = await services.CheckLoginIfExists("evandro", "sanesoares");

            if (getLoginDetail)
            {
                await DisplayAlert("Conectado com sucesso!", "O download de dados começara agora!", "Okay");
                await RetriveDataFromCloud();
            }
            else
            {
                var failed = await DisplayAlert("Conexão indisponivel", "Não foi possível estabelecer uma conexão com o servidor. Verifique se está conectado a uma rede Sanesul.", "Tentar novamente", "Fechar aplicativo");
                if (failed)
                {
                    await TryLogin();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private async Task ToNextPage()
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegionaisPage()));
            await PopupNavigation.Instance.PopAsync();

            /*
            foreach (var item in Navigation.NavigationStack)
            {
                if (item.GetType().Name == "WelcomePage")
                {
                    Navigation.RemovePage(item);
                }
            }*/
        }

        private async void CheckIfShouldUpdateDatabase()
        {
            if (App.DataList.Count > 0)
            {
                bool resposta = await DisplayAlert("Atualização", "Deseja buscar por atualizações no banco de dados?", "Sim", "Não");
                if (resposta)
                {
                    _dataRepository.DeleteAllData();
                    await TryLogin();
                }
                else
                {
                    await ToNextPage();
                }
            }
            else
            {
                await TryLogin();
            }
        }

        private async Task RetriveDataFromCloud()
        {
            try
            {
                List<RegionalModel> regionais = await apiService.GetRegionaisAsync();
                if (regionais == null || regionais.Count == 0)
                {
                    //ERROR RETRIVE LIST
                }
                else
                {
                    try
                    {
                        List<LocalidadeModel> localidades = await apiService.GetLocalidadesAsync();
                        if (localidades == null || localidades.Count == 0)
                        {
                            Console.WriteLine($"Erro retriving localidades {localidades}");
                        }
                        else
                        {
                            List<BackgroundColors> bgColor = new List<BackgroundColors> {
                                new BackgroundColors { BackgroundStartColor = "#32B300", BackgroundEndColor = "#2A9600"},
                                new BackgroundColors { BackgroundStartColor = "#68B265", BackgroundEndColor = "#559152"},
                                new BackgroundColors { BackgroundStartColor = "#6599FF", BackgroundEndColor = "#5988E0"},
                                new BackgroundColors { BackgroundStartColor = "#630396", BackgroundEndColor = "#6700b0"},
                                new BackgroundColors { BackgroundStartColor = "#98E603", BackgroundEndColor = "#82C103"},
                                new BackgroundColors { BackgroundStartColor = "#039079", BackgroundEndColor = "#016353"},
                                new BackgroundColors { BackgroundStartColor = "#33BECC", BackgroundEndColor = "#2896A0"},
                                new BackgroundColors { BackgroundStartColor = "#FE4B4E", BackgroundEndColor = "#D84146"},
                                new BackgroundColors { BackgroundStartColor = "#feb103", BackgroundEndColor = "#b57e02"},
                                new BackgroundColors {BackgroundStartColor = "#FE7E00", BackgroundEndColor = "#CE6300"} };
                            for (int index = 0; index < regionais.Count; index++)
                            {
                                if (regionais[0].Codigo == 15)
                                {
                                    regionais.RemoveAt(0);
                                }
                                Console.WriteLine($"{regionais[index].Nome} atribuido cor: {bgColor[index].BackgroundEndColor}");
                                regionais[index].BackgroundStartColor = bgColor[index].BackgroundStartColor;
                                regionais[index].BackgroundEndColor = bgColor[index].BackgroundEndColor;
                                regionais[index].Localidades = localidades.FindAll(delegate (LocalidadeModel localidade) { return localidade.CentroCusto.StartsWith(regionais[index].CentroCusto); });
                                if (regionais[index].Localidades != null)
                                {
                                    for (int i = 0; i < regionais[index].Localidades.Count; i++)
                                    {
                                        Console.WriteLine($"Localidades de {regionais[index].Nome}: {regionais[index].Localidades[i].Nome}");
                                        try
                                        {
                                            List<ProcessosModel> processos = await apiService.GetProcessosAsync(regionais[index].Localidades[i].Codigo);
                                            if (processos == null || processos.Count == 0)
                                            {
                                                //ERROR RETRIVE LOCALIDADES
                                                Console.WriteLine("Nao achou processos");
                                            }
                                            else
                                            {
                                                //Prossiga pra atribuir itens de processo
                                                regionais[index].Localidades[i].Processos = processos;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nâo achou localidades!");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    App.DataList = regionais;
                    var jsonString = JsonConvert.SerializeObject(regionais);
                    DataTable data = new DataTable
                    {
                        DataString = jsonString
                    };
                    _dataRepository.InsertData(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            await DisplayAlert("Download completo", "Os dados foram baixados com sucesso!", "OK");
            await ToNextPage();
        }

        protected override void OnAppearingAnimationEnd()
        {
            CheckIfShouldUpdateDatabase();
        }
    }
}