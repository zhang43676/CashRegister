using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegisterTest
{
    [TestClass]
    public class CheckoutWithoutCouponTest
        /* This is used for test customer checkout without coupon 
         a dude walk in safeway and buy a lot of thing
         safeway only has banana, canada dry, peach, and burger
         banan and peach are weightable, canada dry and burger are not weightable
         banana is $2 per pound, not on sale
         canada is $1.5 per can, not on sale
         peach is $1 per pound, when you buy 4 pounds, you get 1 pound free
         burger is $2 per burger, when you buy 5 buergers, you get 2 free. 

        */
    {
        private BasketWithoutCoupon _bob;
        private Store _safeway;
        private double _total;

        [TestCleanup]
        public void TestClean()
        {
            _safeway = null;
            _bob = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            _safeway = new Store();
            _total = 0;
            var banana = new RegularPriceProduct(1, "Banana", 2, true);
            var canadadry = new RegularPriceProduct(2, "Canada Dry", 1.5, false);
            var peach = new SaleProduct(3, "Peach", 1, true, 4, 1);
            var burger = new SaleProduct(4, "Burger", 2, false, 5, 2);
            _safeway.AddRegularPriceProduct(banana);
            _safeway.AddRegularPriceProduct(canadadry);
            _safeway.AddSaleProduct(peach);
            _safeway.AddSaleProduct(burger);
            _bob = new BasketWithoutCoupon();
            _bob.SetStore(_safeway);
        }

        /* bob only buy one kind of regular price items, then checkout */

        [TestMethod]
        public void BuySingleRegularPriceItem()
        {
            _bob.BuyProduct(1, 10);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(20, _total);
        }

        /*bob buy multiple kinds of regular price items, then checkout */

        [TestMethod]
        public void BuyMultipleRegularPriceItem()
        {
            _bob.BuyProduct(1, 5);
            _bob.BuyProduct(2, 3);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(14.5, _total);
        }

        /* bob buy one kind of on sale item, then checkout */

        [TestMethod]
        public void BuySingleSaleItem()
        {
            _bob.BuyProduct(3, 4);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(3, _total);
        }

        /* bob buy multiple kind of on sale items, then checkout */

        [TestMethod]
        public void BuyMultipleSaleItem()
        {
            _bob.BuyProduct(3, 7);
            _bob.BuyProduct(4, 6);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(14, _total);
        }

        /* bob buy both regular and on sale items, then checkout */

        [TestMethod]
        public void BuyBothItem()
        {
            _bob.BuyProduct(1, 3);
            _bob.BuyProduct(2, 6);
            _bob.BuyProduct(3, 10);
            _bob.BuyProduct(4, 7);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(33, _total);
        }

        /* bob want to buy a item, but store doesn't have */

        [TestMethod]
        public void BuyItemOutOfStock()
        {
            _bob.BuyProduct(2, 5);
            _bob.BuyProduct(6, 5);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(7.5, _total);
        }


        /* bob buy a lot of things, but he give up his shopping cart. Then he bring a new shopping cart, and keep buy */

        [TestMethod]
        public void CleanShoppingCartThenBuy()
        {
            _bob.BuyProduct(1, 7);
            _bob.BuyProduct(2, 3);
            _bob.BuyProduct(3, 5);
            _bob.BuyProduct(4, 10);
            _bob.CleanShoppingCart();
            _bob.BuyProduct(1, 5);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(10, _total);
        }

        /*bob put some items in his shopping cart back to the shelf, then checkout */

        [TestMethod]
        public void PutSomeItemsBack()
        {
            _bob.BuyProduct(1, 6);
            _bob.BuyProduct(3, 5);
            _bob.PutBack(3, 2);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(15, _total);
        }

        /* bob put some items that not in his shopping cart back to the shelf, such as his cellphone */

        [TestMethod]
        public void PutSomeItemBackThatNoInCart()
        {
            _bob.BuyProduct(1, 5);
            _bob.PutBack(2, 2);
            _bob.CheckOut();
            _total = _bob.ShowPrice();
            Assert.AreEqual(10, _total);
        }
    }
}