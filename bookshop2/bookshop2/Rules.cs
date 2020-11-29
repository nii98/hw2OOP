using System;
using System.Collections.Generic;
using System.Text;

namespace bookshop2
{
    interface IRule 
    
    {
       
        decimal SetRule(Order order);

    }

    class EbookFreeFor2PapaerBookThisAutor : IRule
    {
        string Autor;
        public EbookFreeFor2PapaerBookThisAutor(string autor)

        {
            Autor = autor;
        }

        public decimal SetRule(Order order)
        {
            int BookCounter = 0;
            foreach (Book book in order.Basket)
                if (book.Autor == Autor && book.Type == TypeOfBook.paper)
                {
                    BookCounter += 1;
                
                }

            while (BookCounter >= 2)
            {
                foreach (Book book in order.Basket)
                    if (book.Autor == Autor && book.Type == TypeOfBook.ebook)
                    {
                        order.TotalSum -= book.Cost;
                        BookCounter -= 2;
                    }
            
            }

            BookCounter = 0;
            return order.TotalSum;
        }
    }

}
           
        
        
        
        
        
        



    

