namespace MauiApp1;

public partial class BookCards : ContentView
{
    public static readonly BindableProperty BookTitleProperty = BindableProperty.Create(nameof(BookTitle), typeof(string), typeof(BookCards), string.Empty);
    public static readonly BindableProperty BookImagePathProperty = BindableProperty.Create(nameof(BookImagePath), typeof(string), typeof(BookCards), string.Empty);
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


    public BookCards()
	{
		InitializeComponent();
	}
}