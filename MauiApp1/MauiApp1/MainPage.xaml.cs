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
            client = new HttpClient();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var response = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please chose an epub file",
                FileTypes = null
            });
            Debug.WriteLine("=====================================================================");
            Debug.WriteLine(response);
            Debug.WriteLine("=====================================================================");
            if (response != null && response.FileName.EndsWith("epub", StringComparison.OrdinalIgnoreCase))
            {
                EpubBook book = EpubReader.ReadBook(response.FullPath);
                
                Debug.WriteLine("=====================================================================");
                Debug.WriteLine(book.Title);
                Debug.WriteLine(book.CoverImage);
                Debug.WriteLine("=====================================================================");
                await DisplayAlert("Merci pour votre séléction", "Vous avez choisi " + book.Title + " de " + book.Author, "OK");
            }

        }
    }

}
