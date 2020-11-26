using Lottie.Forms;
using Rg.Plugins.Popup.Pages;
using System;

namespace SCCE.Views.Popup
{
    public partial class MessageBox : PopupPage
    {
        public MessageBox(string title, string description, string animation, string cancel = "Ok", RepeatMode repeatMode = RepeatMode.Restart, int repeatCount = 100, int margin = -100)
        {
            InitializeComponent();
            this.title.Text = title;
            this.description.Text = description;
            this.animation.Animation = animation;
            this.animation.RepeatMode = repeatMode;
            this.animation.RepeatCount = repeatCount;
            this.animation.Margin = margin;
            button.Text = cancel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}