using Rg.Plugins.Popup.Services;
using SCCE.Views.Database;
using SCCE.Views.Tutorial;
using Xamanimation;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : IAnimatedView
    {
        public WelcomePage()
        {
            InitializeComponent();
            var dataPage = new DataPage();
            PopupNavigation.Instance.PushAsync(dataPage);
        }

        public void StartAnimation()
        {
            if (Resources["InfoPanelAnimation"] is StoryBoard animation)
            {
                animation.Begin();
            }
        }
    }
}