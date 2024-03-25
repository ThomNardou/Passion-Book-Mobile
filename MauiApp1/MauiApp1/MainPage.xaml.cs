using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private HttpClient client;

        public MainPage()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await DisplayAlert("fnsepgsrh", "bsrhsrhsrh", "ok");
        }
    }

}
