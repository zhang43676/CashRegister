using System.Collections.Generic;

namespace CashRegister
{
    public abstract class BasketBase
    {
        /* A base of basket has two forms: a basket with coupon and a basket without coupon 
            price is the total price of items in shopping cart when checkout
            shopping cart is customer's shopping cart. The key is product number(barcode in realistic), the value is the number of items in shopping cart
            store is the store customer current in.
            A basket can do following actions : set store, buy product, put product back, clean shopping cart, checkout, and ask for price 
             */

        protected double Price;
        protected Dictionary<int, int> ShoppingCart;
        protected Store StoreIamIn;


        protected BasketBase()
        {
            Price = 0;
            ShoppingCart = new Dictionary<int, int>();
        }

        public void SetStore(Store storeIamIn)
            /* go to a store for shopping */
        {
            StoreIamIn = storeIamIn;
        }

        public void BuyProduct(int productId, int productNum)
            /* put items in shopping cart. Need a product's Id(barcode) and the number of product */
        {
            if (ShoppingCart.ContainsKey(productId))
            {
                ShoppingCart[productId] = ShoppingCart[productId] + productNum;
            }
            else
            {
                ShoppingCart.Add(productId, productNum);
            }
        }

        public void PutBack(int productId, int productNum)
            /* put items back to shelf. Need a product's Id(barcode) and the number of product */

        {
            if (ShoppingCart.ContainsKey(productId))
            {
                if (ShoppingCart[productId] - productNum >= 0)
                {
                    ShoppingCart[productId] = ShoppingCart[productId] - productNum;
                }
            }
        }

        public void CleanShoppingCart()
            /* give up this shopping cart, pick a new shopping cart */
        {
            ShoppingCart = new Dictionary<int, int>();
        }

        public double ShowPrice()
            /* give the price of shopping cart after checkout */
        {
            return Price;
        }
    }
}