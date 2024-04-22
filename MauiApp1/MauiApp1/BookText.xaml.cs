namespace MauiApp1;

public partial class BookText : ContentPage
{
    public static readonly BindableProperty BookTitleProperty = BindableProperty.Create(nameof(BookTitle), typeof(string), typeof(BookText), string.Empty);
    //boruto.jpg

    public string BookTitle
    {
        get => (string)GetValue(BookText.BookTitleProperty);
        set => SetValue(BookText.BookTitleProperty, value);
    }
    public BookText(string title)
	{
		InitializeComponent();
        contentPage.Title = title;
        _title.Text = title;
	}
}