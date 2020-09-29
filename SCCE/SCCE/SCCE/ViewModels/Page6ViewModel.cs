using Rg.Plugins.Popup.Services;
using SCCE.Views.Database;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SCCE.ViewModels
{
    public class Page6ViewModel : BaseViewModel
    {
        public ICommand DownloadDatabase { get; private set; }
        public Page6ViewModel()
        {
            DownloadDatabase = new Command(async () => await Download());
        }

        private async Task Download()
        {
            var dataPage = new DataPage();
            await PopupNavigation.Instance.PushAsync(dataPage);
        }
    }
}
