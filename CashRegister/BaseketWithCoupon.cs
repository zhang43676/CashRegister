using System;
using System.Linq;

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
            if (_MyCoupons.Threhold <= Price)
            {
                Price = Price - _MyCoupons.Discount;
            }
        }
    }
}