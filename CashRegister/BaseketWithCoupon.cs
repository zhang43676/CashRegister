using System;

namespace CashRegister
{
    public class BaseketWithCoupon : BasketBase
        /* checkout with a coupon
            coupon will be checked for theshold and value of discount first
            if the sum of shopping cart value reach theshold of coupon, discount will be apply
            otherwise coupon will not be used when checkout
           */
    {
        private Coupon _MyCoupons;

        public void AddCoupon(Coupon c)
        {
            _MyCoupons = c;
        }

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
            if (_MyCoupons.GetThrehold() <= Price)
            {
                Price = Price - _MyCoupons.GetDiscount();
            }
        }
    }
}