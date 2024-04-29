using Newtonsoft.Json;
using System.Text.Json.Serialization;
using VersOne.Epub;
using System.Text;
using HtmlAgilityPack;
using System.Diagnostics;

namespace MauiApp1;

public partial class BookCards : ContentView
{
    public static readonly BindableProperty BookTitleProperty = BindableProperty.Create(nameof(BookTitle), typeof(string), typeof(BookCards), string.Empty);
    public static readonly BindableProperty BookImagePathProperty = BindableProperty.Create(nameof(BookImagePath), typeof(string), typeof(BookCards), string.Empty);
    public static readonly BindableProperty BookAuthorProperty = BindableProperty.Create(nameof(BookAuthorProperty), typeof(string), typeof(BookCards), string.Empty);
    //boruto.jpg

    public string BookTitle
    {
        get => (string)GetValue(BookCards.BookTitleProperty);
        set => SetValue(BookCards.BookTitleProperty, value);
    }
    public string BookImagePath
    {
        get => (string)GetValue(BookCards.BookImagePathProperty);
        set => SetValue(BookCards.BookImagePathProperty, value);
    }

    public string BookAuthor
    {
        get => (string)GetValue(BookCards.BookAuthorProperty);
        set => SetValue(BookCards.BookAuthorProperty, value);
    }


    public BookCards()
    { 
		InitializeComponent();
	}

    private async void sayHello(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookText(_title.Text));
        Debug.WriteLine("CLICKED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!   " + _title.Text);
    }
}