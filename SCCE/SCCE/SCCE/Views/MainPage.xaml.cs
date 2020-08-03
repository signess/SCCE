using Plugin.SharedTransitions;
using SCCE.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<HomeMenuItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<HomeMenuItem>();
            // incluindo items de menu e definindo : title ,page and icon
            menuList.Add(new HomeMenuItem()
            {
                Title = "Bombas Submersas",
                Icon = "home.png",
                TargetType = typeof(RegionalMapView)
            });
            menuList.Add(new HomeMenuItem()
            {
                Title = "About",
                Icon = "settings.png",
                TargetType = typeof(AboutPage)
            });
            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            paginaMestreList.ItemsSource = menuList;
            // navegação inicial
            Detail = new SharedTransitionNavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));

        }
        // Evento para a seleção de item no menu
        // trata a seleção do usuário no ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (HomeMenuItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new SharedTransitionNavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
        
}