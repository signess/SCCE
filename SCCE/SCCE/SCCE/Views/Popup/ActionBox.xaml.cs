using Lottie.Forms;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace SCCE.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionBox : PopupPage
    {
        public event EventHandler<bool> CallbackEvent;

        public ActionBox(string title, string description, string animation, string confirmation = "Sim", string cancel = "Não", RepeatMode repeatMode = RepeatMode.Restart, int repeatCount = 100, int margin = -100)
        {
            InitializeComponent();
            this.title.Text = title;
            this.description.Text = description;
            this.animation.Animation = animation;
            this.animation.RepeatMode = repeatMode;
            this.animation.RepeatCount = repeatCount;
            this.animation.Margin = margin;
            confirmationButton.Text = confirmation;
            cancelButton.Text = cancel;
        }

        private void Confirmation_Clicked(object sender, EventArgs e)
        {
            CallbackEvent?.Invoke(this, true);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            CallbackEvent?.Invoke(this, false);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}