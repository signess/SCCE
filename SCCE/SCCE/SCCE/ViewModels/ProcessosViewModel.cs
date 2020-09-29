using SCCE.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class ProcessosViewModel : BaseViewModel
    {
        private LocalidadeModel localidade;
        public LocalidadeModel Localidade
        {
            get => localidade;
            private set => SetProperty(ref localidade, value);
        }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
        public ObservableCollection<ProcessosModel> ProcessosList => GetProperties();

        private ObservableCollection<ProcessosModel> GetProperties()
        {
            return new ObservableCollection<ProcessosModel>(Localidade.Processos);
        }

        public ProcessosViewModel(INavigation navigation, LocalidadeModel localidade, string startColor, string endColor)
        {
            Navigation = navigation;
            Localidade = localidade;
            BackgroundStartColor = startColor;
            BackgroundEndColor = endColor;
        }

    }
}
