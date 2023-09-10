using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    struct Book
    {
        public string author;
        public string title;
        public int copyright;

        public Book(string a, string t, int c)
        {
            author = a;
            title = t;
            copyright = c;
        }
    }
}
