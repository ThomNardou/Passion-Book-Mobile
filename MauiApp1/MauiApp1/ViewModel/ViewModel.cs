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

namespace MauiApp1.ViewModel
{
    public partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        private Books selectedItem;

        [ObservableProperty]
        private ObservableCollection<Books> listBooks = new ObservableCollection<Books>();

        public ViewModel()
        {
            getBooks();
        }

        public async void getBooks()
        {
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

                Debug.WriteLine("=======================================");
                Debug.WriteLine(body);
                Debug.WriteLine("=======================================");

                ApiResults result = System.Text.Json.JsonSerializer.Deserialize<ApiResults>(body);

                foreach (var item in result.data) {
                    ListBooks.Add(item);
                    Debug.WriteLine("================================================");
                    Debug.WriteLine(item.writer);
                    Debug.WriteLine("================================================");

                }

            }
        }

        [RelayCommand]
        private void OnTappedItem(Books o)
        {

            
            Debug.WriteLine($"neiughuioegheuiogbio     mfgmkcgkcgkckcgkcdjk "+o.title);

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
