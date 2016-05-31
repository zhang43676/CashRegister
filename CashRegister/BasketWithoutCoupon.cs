using System;

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
                var selectResult = StoreIamIn.SearchRegularPriceProductById(pair.Key);
                if (selectResult != null)
                {
                    Price = Price + selectResult.GetProductPrice()*pair.Value;
                }
                else
                {
                    var selectSaleResult = StoreIamIn.SearchSaleProductById(pair.Key);
                    if (selectSaleResult != null)
                    {
                        var discountValue = Math.Floor(pair.Value/selectSaleResult.GetTheshold())*
                                            selectSaleResult.GetDiscount();
                        Price = Price + selectSaleResult.GetProductPrice()*(pair.Value - discountValue);
                    }
                }
            }
        }
    }
}