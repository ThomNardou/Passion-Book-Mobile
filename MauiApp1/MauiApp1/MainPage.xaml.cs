using Newtonsoft.Json;
using System.Text.Json.Serialization;
using VersOne.Epub;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Nancy.Json;
using Nancy;
using MauiApp1.Services;


namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            var vm = this.BindingContext as ViewModel.ViewModel;
            
            new Timer((_) => vm.getBooks(), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            
        }

        public async void GetBookAPI()
        {
            
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
