using Newtonsoft.Json;
using SCCE.Data;
using SCCE.Models;
using SCCE.Services;
using SCCE.Validator;
using SCCE.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private readonly APIService apiService = new APIService();
        private bool DBFound { get; set; }
        private bool activityIndicator = false;
        public bool ActivityIndicatorIsRunning
        {
            set
            {
                if(activityIndicator != value)
                {
                    activityIndicator = value;
                    OnPropertyChanged(nameof(ActivityIndicatorIsRunning));
                }
            }
            get
            {
                return activityIndicator;
            }
        }
        private bool viewIsVisible = false;
        public bool ViewIsVisible
        {
            get => viewIsVisible;
            set
            {
                if(viewIsVisible != value)
                {
                    viewIsVisible = value;
                    OnPropertyChanged(nameof(ViewIsVisible));
                }
            }
        }
        string entryUsername;
        public string EntryUsername
        {
            set
            {
                if(entryUsername != value)
                {
                    entryUsername = value;
                    OnPropertyChanged(nameof(EntryUsername));
                }
            }
            get
            {
                return entryUsername;
            }
        }
        string entryPassword;
        public string EntryPassword
        {
            set
            {
                if(entryPassword != value)
                {
                    entryPassword = value;
                    OnPropertyChanged(nameof(EntryPassword));
                }
            }
            get
            {
                return entryPassword;
            }
        }

        public ICommand LoginCommand { get; private set; }
        public WelcomeViewModel(INavigation navigation, bool dbFound)
        {
            Navigation = navigation;
            _dataValidator = new DataValidator();
            _dataRepository = new DataRepository();
            DBFound = dbFound;
            LoginCommand = new Command(async () => await ButtonLogin());
            CheckIfShouldUpdateDatabase();
        }

        private async Task ButtonLogin()
        {
            Console.WriteLine($"Apertou botao: {EntryUsername}, {EntryPassword}");
            LoginService services = new LoginService();
            var getLoginDetail = await services.CheckLoginIfExists(EntryUsername, EntryPassword);

            if (getLoginDetail)
            {
                await _messageService.ShowAsync("Login Sucess", "You are login", "Okay", "Cancel");
                CheckIfShouldUpdateDatabase();
            }
            else
            {
                await _messageService.ShowAsync("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }

        private async void CheckIfShouldUpdateDatabase()
        {
            if (DBFound)
            {
                bool resposta = await _messageService.ShowAsyncBool("Atualização", "Deseja buscar por atualizações no banco de dados?", "Sim", "Não");
                if (resposta)
                {
                    _dataRepository.DeleteAllData();
                    await RetriveDataFromCloud();
                }
                else
                {
                    await Navigation.PushAsync(new RegionaisPage());
                }

            }
            else
            {
                await _messageService.ShowAsync("Primeira inicialização", "O SCCO vai buscar agora os dados necessários. Esse processo pode demorar um pouco.", "Tudo bem!");
                await RetriveDataFromCloud();
            }
        }


        private async Task RetriveDataFromCloud()
        {
            ActivityIndicatorIsRunning = true;
            ViewIsVisible = true;
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

            ViewIsVisible = false;
            ActivityIndicatorIsRunning = false;
            await _messageService.ShowAsync("Get Data", "Finished downloading data!", "OK");
            await Navigation.PushAsync(new RegionaisPage());
        }

    }
}
