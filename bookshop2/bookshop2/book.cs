using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using System.Threading.Tasks;

namespace bookshop2
{
    enum TypeOfBook {ebook,paper }
    class Book
    {
        public string Name { get; set; }
        public TypeOfBook Type { get; set; }
        public decimal Cost;
        public string Autor { get; set; }

        public Book(string name, TypeOfBook type, string autor, decimal cost )
        {
            this.Name = name;
            this.Type = type;
            this.Autor = autor;
            this.Cost = cost;
            
        }



        



    }
}
