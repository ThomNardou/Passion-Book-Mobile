using Newtonsoft.Json;
using System.Text.Json.Serialization;
using VersOne.Epub;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        private HttpClient client;

        public MainPage()
        {
            InitializeComponent();
            GetBookAPI();
        }

        public async void GetBookAPI()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            //client.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://10.0.2.2:3000/api/books"),
                /*Headers =
                {
                    { "authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjEsImlhdCI6MTcxMzc4OTQ3MywiZXhwIjoxNzQ1MzQ3MDczfQ.AiconE00Rkxoz4mDxN09XP6Bqn2BV34aFtbIwNWxVog" },
                },*/
            };

            //client.SendAsync(request);

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(body);
            }
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var response = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please chose an epub file",
                FileTypes = null
            });
            if (response != null && response.FileName.EndsWith("epub", StringComparison.OrdinalIgnoreCase))
            {
                EpubBook book = EpubReader.ReadBook(response.FullPath);
                
                Debug.WriteLine("=====================================================================");
                Debug.WriteLine(response.FullPath);
                Debug.WriteLine("=====================================================================");
                
                BookCards bookCards = new BookCards();
                bookCards.BookTitle = book.Title;
                BookList.Children.Add(bookCards);

                await DisplayAlert("Merci pour votre séléction", "Vous avez choisi " + book.Title + " de " + book.Author, "OK");
            }

        }
    }

}
