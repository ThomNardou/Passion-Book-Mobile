using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services;
using static System.Net.Mime.MediaTypeNames;

namespace MauiApp1;

public partial class BookText : ContentPage
{
	
    public BookText(int totalPage, ObservableCollection<XmlNode> chapters)
	{
		InitializeComponent();
		var vm = this.BindingContext as ViewModel.ViewModel;
		vm.TotalPage = totalPage;
		vm.Chapters = chapters;
    }
}