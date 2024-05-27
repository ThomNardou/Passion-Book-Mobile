using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Buffers.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace MauiApp1.ViewModel
{
    public partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        private Books selectedItem;

        [ObservableProperty]
        private ObservableCollection<Books> listBooks = new ObservableCollection<Books>();

        [ObservableProperty]
        private ObservableCollection<XmlNode> chapters = new ObservableCollection<XmlNode>();

        [ObservableProperty]
        private int currentPage = 0;

        [ObservableProperty]
        private int totalPage = 0;

        [ObservableProperty]
        private Timer timer;

        

        public ViewModel()
        {
            //getBooks();

            
        }

        public async void getBooks()
        {
            Trace.WriteLine("hi");
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            //client.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://10.0.2.2:3000/api/books"),
                Headers =
                {
                    { "authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOjEsImlhdCI6MTcxMzc4OTQ3MywiZXhwIjoxNzQ1MzQ3MDczfQ.AiconE00Rkxoz4mDxN09XP6Bqn2BV34aFtbIwNWxVog" },
                },
            };

            //client.SendAsync(request);

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                ApiResults result = System.Text.Json.JsonSerializer.Deserialize<ApiResults>(body);

                foreach (var item in result.data) {
                    ListBooks.Add(item);

                }

            }
        }

        [RelayCommand]
        private void OnTappedItem(Books o)
        {
            Chapters.Clear();

            var byteArray = Convert.FromBase64String(o.epub);


            ZipArchive archive = new ZipArchive(new MemoryStream(byteArray));


            var contentString = new StreamReader(archive.GetEntry("OEBPS/content.opf").Open()).ReadToEnd();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(contentString);

            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsManager.AddNamespace("opf", "http://www.idpf.org/2007/opf");

            XmlNodeList ContentsNode = xmlDoc.SelectNodes("//opf:item", nsManager);

            foreach (XmlNode item in ContentsNode)
            {
                if (item.Attributes["media-type"].Value == "application/xhtml+xml")
                {
                    Chapters.Add(item);
                    TotalPage = Chapters.Count;
                }
            }
            
            CurrentBook.Archive = archive;
            CurrentBook.Chapters = Chapters;

            CurrentPage = 1;
            Shell.Current.Navigation.PushAsync(new BookText(Chapters.Count - 1, Chapters));
        }

        [RelayCommand]
        private async void GoNextPage()
        {
            if(CurrentPage < Chapters.Count - 1)
            {
                CurrentPage += 1;
            }
            else
            {
                await Shell.Current.DisplayAlert("Terminé", "Vous avez terminé votre livre. BRAVO !!!", "MERCI");
                await Shell.Current.Navigation.PopAsync();
            }
        }

        [RelayCommand]
        private async void GoPreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage -= 1;
            }
            else
            {
                await Shell.Current.DisplayAlert("OUPS", "Vous ne pouvez pas aller plus pas", "OK");
            }
        }


        [ObservableProperty]
        public string chContent;

        partial void OnCurrentPageChanged(int value)
        {
            ChContent = ChapterContent();
        }

        public string ChapterContent(){
            
                var currentChapterHref = CurrentBook.Chapters[CurrentPage].Attributes["href"].Value;
                string path = "OEBPS/" + currentChapterHref;
                string cleanPath = Uri.UnescapeDataString(path);
                var ccContent = CurrentBook.Archive.GetEntry(cleanPath);
                string sr = new StreamReader(ccContent.Open()).ReadToEnd();

                string result = Regex.Replace(sr, @"<[^>]*>", String.Empty);
                string realResult = Regex.Replace(result, @"&nbsp;", String.Empty);

                Debug.WriteLine(realResult);

                return realResult; 
            
            
        }


        public void ReadBook(Books book)
        {
            //book.epub
            var bytes = Convert.FromBase64String(book.epub);
            var contents = new StreamContent(new MemoryStream(bytes));
            var epub = new ZipArchive(contents.ReadAsStream());

        }
    }
}
