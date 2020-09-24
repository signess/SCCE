using Newtonsoft.Json;
using Plugin.SharedTransitions;
using SCCE.Data;
using SCCE.Models;
using SCCE.Services;
using SCCE.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: ExportFont("NunitoSans-Regular.ttf", Alias = "ThemeFontRegular")]
[assembly: ExportFont("NunitoSans-Bold.ttf", Alias = "ThemeFontBold")]
[assembly: ExportFont("NunitoSans-SemiBold.ttf", Alias = "ThemeFontMedium")]

namespace SCCE
{
    public partial class App : Application
    {
        private readonly IDataRepository _dataRepository;
        public static List<RegionalModel> DataList = new List<RegionalModel>();

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IMessageService, MessageService>();
            _dataRepository = new DataRepository();
            OnAppStart();
        }

        private void OnAppStart()
        {
            var dataTable = _dataRepository.GetAllData();
            foreach (DataTable data in dataTable)
            {
                var dataConverted = JsonConvert.DeserializeObject<List<RegionalModel>>(data.DataString);
                DataList = new List<RegionalModel>(dataConverted);
            }
            if (DataList.Count > 0)
            {
                MainPage = new SharedTransitionNavigationPage(new WelcomePage(true));
            }
            else
            {
                MainPage = new SharedTransitionNavigationPage(new WelcomePage(false));
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}