using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Services
{
    public static class CurrentBook
    {
        public static ZipArchive Archive { get; set; }
        public static ObservableCollection<XmlNode> Chapters { get; set; }
    }
}
