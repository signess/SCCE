using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCCE.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await SCCE.App.Current.MainPage.DisplayAlert("Data", message, "OK");
        }

        public async Task ShowAsync(string title, string message, string text1)
        {
            await SCCE.App.Current.MainPage.DisplayAlert(title, message, text1);
        }

        public async Task ShowAsync(string title, string message, string text1, string text2)
        {
            await SCCE.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }

        public async Task<bool> ShowAsyncBool(string title, string message, string text1, string text2)
        {
            return await SCCE.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }
    }
}
