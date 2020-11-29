using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start TEST");

            

            Book book1 = new Book("book1", TypeOfBook.paper, "autor1", 100);
            Book book2 = new Book("book2", TypeOfBook.paper, "autor2", 100);
            Book book3 = new Book("book3", TypeOfBook.paper, "autor2", 100);
            Book book4 = new Book("book4", TypeOfBook.ebook, "autor2", 100);

            List<Book> Basket = new List<Book>();

            PercentSale percentSale = new PercentSale("%", 10);
            FreeDelivery freeDelivery = new FreeDelivery("freeDel");
            BookAsGift bookAsGift = new BookAsGift("bookAsGift",book2);
            MoneySale moneySale = new MoneySale("SsSS", 50);

            EbookFreeFor2PapaerBookThisAutor rule1 = new EbookFreeFor2PapaerBookThisAutor("autor2");

            Basket.Add(book2);
            Basket.Add(book3);
            Basket.Add(book4);

            List<IPromo> Promo = new List<IPromo>();
            Promo.Add(freeDelivery);

            List<IRule> Rules = new List<IRule>();

            Rules.Add(rule1);

            Order order1 = new Order(Basket, Promo, Rules);

                       
           
            Console.WriteLine(order1.CountTotalCost());

           
        }
    }
}
