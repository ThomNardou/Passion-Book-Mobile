namespace MauiApp1;

public partial class BookCards : ContentView
{
	public static readonly BindableProperty BookTitleProperty = BindableProperty.Create(nameof(BookTitle), typeof(string), typeof(BookCards), string.Empty);
	public string BookTitle
	{
		get => (string)GetValue(BookCards.BookTitleProperty);
		set => SetValue(BookCards.BookTitleProperty, value);
	} 
	public BookCards()
	{
		InitializeComponent();
	}
}