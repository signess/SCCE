using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SCCE.Data;
using SCCE.Extensions;
using SCCE.Models;
using SCCE.Services;
using SCCE.Views.Popup;
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

        /*
        private async void TryLogin()
        {
            LoginService services = new LoginService();
            var getLoginDetail = await services.CheckLoginIfExists("teste.app", "123456");

            if (getLoginDetail)
            {
                var popupPage = new MessageBox("Conectado com sucesso!", "O download de dados começara agora!", "tick.json", "Continuar", Lottie.Forms.RepeatMode.Infinite, 0, 0);

                popupPage.Disappearing += async (c, d) =>
                {
                    await RetriveDataFromCloud();
                };
                await PopupNavigation.Instance.PushAsync(popupPage);
            }
            else
            {
                var choice = false;
                var popupPage = new ActionBox("Conexão indisponivel", "Não foi possível estabelecer uma conexão com o servidor. Verifique se está conectado a uma rede Sanesul.", "fail.json", "Tentar novamente", "Fechar aplicativo", Lottie.Forms.RepeatMode.Infinite, 0, 0);
                popupPage.CallbackEvent += (c, arg) =>
                {
                    choice = arg;
                };
                popupPage.Disappearing += (c, d) =>
                {
                    if (choice)
                    {
                        TryLogin();
                    }
                    else
                    {
                        Application.Current.Quit();
                    }
                };
                await PopupNavigation.Instance.PushAsync(popupPage);
            }
            
        }
        */
        private async void ToNextPage()
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegionaisPage()));
            await PopupNavigation.Instance.PopAsync();
        }

        private async void CheckIfShouldUpdateDatabase()
        {
            if (App.DataList.Count > 0)
            {
                bool choice = false;
                var popupPage = new ActionBox("Atualização", "Deseja buscar por atualizações no banco de dados?", "update.json", "Sim", "Não");
                popupPage.CallbackEvent += (c, arg) =>
                {
                    choice = arg;
                };
                popupPage.Disappearing += async (c, d) =>
                {
                    if (choice)
                    {
                        _dataRepository.DeleteAllData();
                        await RetriveDataFromCloud();
                        //TryLogin();
                    }
                    else
                    {
                        ToNextPage();
                    }
                };
                await PopupNavigation.Instance.PushAsync(popupPage);
            }
            else
            {
                await RetriveDataFromCloud();
                //TryLogin();
            }
        }

        private async Task<List<ObjetoSerialModel>> EstruturarDadosTecnicos()
        {
            try
            {
                List<DadosTecnicosModel> dadosTecnicos = await apiService.GetDadosTecnicosAsync();
                List<ObjetoSerialModel> objetoSeriais = await apiService.GetObjetosSerialAsync();
                List<ObjetoSerialModel> bombasSubmersas = objetoSeriais.FindAll(delegate (ObjetoSerialModel bhs) { return bhs.Codigo.Contains("BHS"); });
                for (int z = 0; z < bombasSubmersas.Count; z++)
                {
                    bombasSubmersas[z].DadosTecnicos = dadosTecnicos.FindAll(d => d.ID.Contains(bombasSubmersas[z].Codigo));
                }
                return bombasSubmersas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task RetriveDataFromCloud()
        {
            List<BackgroundColors> bgColor = new List<BackgroundColors> {
                    new BackgroundColors { BackgroundStartColor = "#6599FF", BackgroundEndColor = "#5988E0"},
                    new BackgroundColors { BackgroundStartColor = "#feb103", BackgroundEndColor = "#b57e02"},
                    new BackgroundColors {BackgroundStartColor = "#FE7E00", BackgroundEndColor = "#CE6300"},
                    new BackgroundColors { BackgroundStartColor = "#98E603", BackgroundEndColor = "#82C103"},
                    new BackgroundColors { BackgroundStartColor = "#039079", BackgroundEndColor = "#016353"},
                    new BackgroundColors { BackgroundStartColor = "#33BECC", BackgroundEndColor = "#2896A0"},
                    new BackgroundColors { BackgroundStartColor = "#FE4B4E", BackgroundEndColor = "#D84146"},
                    new BackgroundColors { BackgroundStartColor = "#68B265", BackgroundEndColor = "#559152"},
                    new BackgroundColors { BackgroundStartColor = "#32B300", BackgroundEndColor = "#2A9600"},
                    new BackgroundColors { BackgroundStartColor = "#630396", BackgroundEndColor = "#6700b0"}
            };
            try
            {
                List<RegionalModel> regionais = await apiService.GetRegionaisAsync();
                List<ObjetoSerialModel> bombasSubmersas = await EstruturarDadosTecnicos();
                if (regionais == null || regionais.Count == 0)
                {
                    //ERROR RETRIVE LIST
                    var errorPopUpPage = new MessageBox("Erro na captura de dados", "Verifique suas conexão com a rede Sanesul e tente novamente!", "fail.json", "Fechar aplicativo", Lottie.Forms.RepeatMode.Infinite, 0, 0);

                    errorPopUpPage.Disappearing += (c, d) =>
                    {
                        Application.Current.Quit();
                    };
                }
                else
                {
                    for (int index = 0; index < regionais.Count; index++)
                    {
                        if (regionais[index].Site == 15)
                        {
                            regionais.RemoveAt(index);
                        }
                        //Console.WriteLine($"{regionais[index].Nome} atribuido cor: {bgColor[index].BackgroundEndColor}");
                        regionais[index].BackgroundStartColor = bgColor[index].BackgroundStartColor;
                        regionais[index].BackgroundEndColor = bgColor[index].BackgroundEndColor;
                        regionais[index].IsClickable = true;
                        try
                        {
                            List<ObjetoFuncionalModel> objetosFuncional = await apiService.GetObjetosFuncionalAsync(regionais[index].Site);
                            regionais[index].Localidades = objetosFuncional.FindAll(delegate (ObjetoFuncionalModel localidade) { return localidade.TipoDeObjeto.Contains("UNIDADE"); });
                            if (regionais[index].Localidades != null)
                            {
                                for (int i = 0; i < regionais[index].Localidades.Count; i++)
                                {
                                    //Console.WriteLine($"Localidades de {regionais[index].Nome}: {regionais[index].Localidades[i].Descricao}");
                                    //Prossiga pra atribuir itens de processo
                                    regionais[index].Localidades[i].Processos = objetosFuncional.FindAll(delegate (ObjetoFuncionalModel processo) { return (processo.TipoDeObjeto.Contains("LOCINS") && processo.Ligacao.Contains(regionais[index].Localidades[i].Codigo)); });
                                    if (regionais[index].Localidades[i].Processos != null)
                                    {
                                        regionais[index].Localidades[i].Processos.RemoveAll(p => p.Descricao.Contains("EEB") || p.Descricao.Contains("ETE") || p.Descricao.Contains("ESC") || p.Descricao.Contains("DESATIVADO"));
                                        for (int x = 0; x < regionais[index].Localidades[i].Processos.Count; x++)
                                        {
                                            string toRemove = string.Format("LOCINS " + regionais[index].Localidades[i].Processos[x].Codigo + " / ");
                                            string toRemove2 = string.Format("LOCIN " + regionais[index].Localidades[i].Processos[x].Codigo + " / ");
                                            if (regionais[index].Localidades[i].Processos[x].Descricao.Contains(toRemove))
                                            {
                                                regionais[index].Localidades[i].Processos[x].Descricao = regionais[index].Localidades[i].Processos[x].Descricao.RemoveStart(toRemove);
                                            }
                                            else if(regionais[index].Localidades[i].Processos[x].Descricao.Contains(toRemove2))
                                            {
                                                regionais[index].Localidades[i].Processos[x].Descricao = regionais[index].Localidades[i].Processos[x].Descricao.RemoveStart(toRemove2);
                                            }
                                            regionais[index].Localidades[i].Processos[x].BombaSubmersa = bombasSubmersas.FindAll(bomba => bomba.Ligacao.Contains(regionais[index].Localidades[i].Processos[x].Codigo));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nâo achou localidades!");
                            }
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                            regionais[index].BackgroundStartColor = "#636362";
                            regionais[index].BackgroundEndColor = "#636362";
                            regionais[index].IsClickable = false;
                        }
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
                var choice = false;
                var errorPopupPage = new ActionBox("Conexão indisponivel", "Não foi possível estabelecer uma conexão com o servidor. Verifique se está conectado a uma rede Sanesul.", "fail.json", "Tentar novamente", "Fechar aplicativo", Lottie.Forms.RepeatMode.Infinite, 0, 0);
                errorPopupPage.CallbackEvent += (c, arg) =>
                {
                    choice = arg;
                };
                errorPopupPage.Disappearing += async (c, d) =>
                {
                    if (choice)
                    {
                        await RetriveDataFromCloud();
                    }
                    else
                    {
                        Application.Current.Quit();
                    }
                };
                await PopupNavigation.Instance.PushAsync(errorPopupPage);
            }
            var popupPage = new MessageBox("Download completo", "Os dados foram baixados com sucesso!", "completed.json", "Continuar", Lottie.Forms.RepeatMode.Infinite, 0, 0);

            popupPage.Disappearing += (c, d) =>
            {
                ToNextPage();
            };
            await PopupNavigation.Instance.PushAsync(popupPage);
        }

        protected override void OnAppearingAnimationEnd()
        {
            CheckIfShouldUpdateDatabase();
        }
    }
}