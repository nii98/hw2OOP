using System;
using System.Collections.Generic;
using System.Text;

namespace bookshop2
{
    class Order
    {
        public List<Book> Basket;
        public decimal TotalSum;
        public decimal DeliveryCost;
        public decimal PercentSale;


        public Order(List<Book> basket, List<IPromo> codes = null, List<IRule> rules= null)
        {
            DeliveryCost = 200;
            //sumOfEbook = 0;
            //sumOfPbook = 0;
            //_codes = new List<IPromo>();
            
            this.Basket = basket;
            TotalSum = 0;
            PercentSale = 1;
            if (codes != null)
            {
                foreach (IPromo promo in codes)
                {
                    promo.UsePromoCode(this);
                }
            }


            if (rules != null)
            {
                foreach (IRule rule in rules)
                {
                    rule.SetRule(this);
                }
            }
        }

        

        private decimal CountCost ()
        {
            foreach (Book book in this.Basket)
            {
                TotalSum += book.Cost;

            }


            TotalSum = TotalSum*PercentSale ;    
    

            return TotalSum;
        }
        private bool OnlyEbookDetector()
        {
            foreach (Book book in this.Basket)
            {
                if (book.Type == TypeOfBook.paper)
                {
                    return false;
                }
            
            }
            return true;
        }

        private decimal CountDelivery()

        {
            if (this.OnlyEbookDetector() == true)
            {
                this.DeliveryCost = 0;

            }


            if (this.CountCost() > 1000)
            {
                this.DeliveryCost = 0;
            }

            return DeliveryCost;
        }
        

        public decimal CountTotalCost()
        {
            decimal Cost = this.CountCost() + this.CountDelivery();
            

            return Cost;
        }



    }
}
