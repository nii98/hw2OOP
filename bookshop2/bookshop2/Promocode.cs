using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bookshop2
{
    interface IPromo
    { 
     string PromoCode { get; set; }
        decimal UsePromoCode(Order order);
    
    }

    class FreeDelivery :IPromo
    {
        public string PromoCode { get; set; }

        public FreeDelivery(string code)
        {
            this.PromoCode = code;
        }

        public decimal UsePromoCode(Order order)
        {
            if (order.DeliveryCost != 0)
            {

                order.DeliveryCost = 0;

                           
            }

            return order.DeliveryCost;

        }



    }


    class BookAsGift : IPromo
    {
        public string PromoCode { get; set; }
        private Book FreeBook;
        public BookAsGift(string code, Book book = null)
        {
            this.PromoCode = code;
            this.FreeBook = book;


        }


        public decimal UsePromoCode(Order order)
        {
            foreach (Book book in order.Basket)
            {
                if (book == FreeBook)
                {
                    order.TotalSum -=book.Cost;

                }       
            
                      
            
            }
            return order.TotalSum;
        }





    }


    class MoneySale : IPromo
    {

        public string PromoCode { get; set; }
        decimal Sale;
        public MoneySale(string code,  decimal sale)

        {
            this.Sale = sale;
            this.PromoCode = code;
        }

        public decimal UsePromoCode(Order order) 
        
        {
            order.TotalSum -= Sale;

            return order.TotalSum;
        }
    }



    class PercentSale
    {
        public string PromoCode { get; set; }
        decimal Percent;
        public PercentSale(string code, decimal percent)

        {
            this.Percent = percent;
            this.PromoCode = code;
        }

        public decimal UsePromoCode(Order order)

        {
            order.PercentSale =1-( Percent/100);

            return order.PercentSale;
        }


    }
}
