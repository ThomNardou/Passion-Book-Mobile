using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class Books
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int numberPages { get; set; }
        public string? excerpt { get; set; }
        public string? summary { get; set; }
        public string? writer { get; set; }
        public string? editor { get; set; }
        public int releaseYear { get; set; }
        public float avgRating { get; set; }
        public string? coverImage { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int fk_category { get; set; }
        public int fk_user { get; set; }
    }
}
