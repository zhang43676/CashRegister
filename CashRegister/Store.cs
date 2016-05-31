using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public class Store
        /*
         * A store two lists : on sale product list and regular product list
         * regular product list are items that are regular price
         * on sale product list are items that on sale now
         */

    {
        private readonly List<RegularPriceProduct> RegularPriceProductList;
        private readonly List<SaleProduct> SaleProductList;

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

        public List<RegularPriceProduct> GetRegularPriceProducts()
        {
            return RegularPriceProductList;
        }

        public List<SaleProduct> GetSalePriceProducts()
        {
            return SaleProductList;
        }


        public RegularPriceProduct SearchRegularPriceProductById(int productId)
        {
            var selectResult = RegularPriceProductList.Where(i => i.GetProductId() == productId).ToList();
            if (selectResult.Count != 0)
            {
                return selectResult[0];
            }
            return null;
        }

        public SaleProduct SearchSaleProductById(int productId)
        {
            var selectResult = SaleProductList.Where(i => i.GetProductId() == productId).ToList();
            if (selectResult.Count != 0)
            {
                return selectResult[0];
            }
            return null;
        }
    }
}