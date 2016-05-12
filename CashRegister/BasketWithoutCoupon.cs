using System;
using System.Linq;

namespace CashRegister
{
    public class BasketWithoutCoupon : BasketBase
        /*  Basket without coupon will be checkout without coupon 
            Put all of items out of shopping cart, and check it is on sale in store or not
            Regular price items will be multiple number of items by item price
            on sale items will use number of items divided by theshold of bulk, and multiple discount value to find how many items don't need to pay
            then use number of items sub number of free item, mutiple item price to find total of discount item price      
        */

    {
        public void CheckOut()
        {
            foreach (var pair in ShoppingCart)
            {
                var selectResult = StoreIamIn.RegularPriceProductList.Where(i => i.ProductId == pair.Key).ToList();
                if (selectResult.Count != 0)
                {
                    Price = Price + selectResult[0].ProductPrice*pair.Value;
                }
                else
                {
                    var reSelectResult = StoreIamIn.SaleProductList.Where(i => i.ProductId == pair.Key).ToList();
                    if (reSelectResult.Count != 0)
                    {
                        var discountValue = Math.Floor(pair.Value/reSelectResult[0].Theshold)*
                                            reSelectResult[0].Discount;
                        Price = Price + reSelectResult[0].ProductPrice*(pair.Value - discountValue);
                    }
                }
            }
        }
    }
}