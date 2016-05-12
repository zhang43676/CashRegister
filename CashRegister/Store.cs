using System.Collections.Generic;

namespace CashRegister
{
    public class Store
        /*
         * A store two lists : on sale product list and regular product list
         * regular product list are items that are regular price
         * on sale product list are items that on sale now
         */

    {
        public List<RegularPriceProduct> RegularPriceProductList;
        public List<SaleProduct> SaleProductList;

        public Store()
        {
            RegularPriceProductList = new List<RegularPriceProduct>();
            SaleProductList = new List<SaleProduct>();
        }

        public void AddRegularPriceProduct(RegularPriceProduct product)
            /* Call this method to add a regular price item to store
               
             */
        {
            RegularPriceProductList.Add(product);
        }

        public void AddSaleProduct(SaleProduct product)
            /* Call this method to add a sale item to store */
        {
            SaleProductList.Add(product);
        }
    }
}