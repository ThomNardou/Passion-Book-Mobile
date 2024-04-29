using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ApiResults
    {
        public string message { get; set; }
        public List<Books> data { get; set; }
    }
}
