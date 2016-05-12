using CashRegister;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashRegisterTest
{
    [TestClass]
    public class CheckoutWithCouponTest
    {
        /* This is used for test customer checkout with coupon 
 a dude walk in costco and buy a lot of thing
 He has a coupon that is when you buy $100, you get $20 off
 costco only has wine, beef, CK underwear, and pear
 beef and pear are weightable, wine and CK underwear are not weightable
 wine is $5 per bottle, not on sale
 beef is $2.5 per pound, not on sale
 CK underwear is $20 each, when you buy 3, you get 1 underwear free
 pear is $1.5 per pound, when you buy 4 pounds, you get 1 pound free. 

*/
        private Coupon _bigdiscount;
        private Store _costco;
        private BaseketWithCoupon _steve;
        private double _total;

        [TestCleanup]
        public void TestClean()
        {
            _costco = null;
            _steve = null;
            _bigdiscount = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            _costco = new Store();
            _total = 0;
            var wine = new RegularPriceProduct(1, "Wine", 5, false);
            var beef = new RegularPriceProduct(2, "Beef", 2.5, true);
            var underwearCK = new SaleProduct(3, "underwearCK", 20, false, 3, 1);
            var pear = new SaleProduct(4, "pear", 1.5, false, 4, 1);
            _costco.AddRegularPriceProduct(wine);
            _costco.AddRegularPriceProduct(beef);
            _costco.AddSaleProduct(underwearCK);
            _costco.AddSaleProduct(pear);
            _steve = new BaseketWithCoupon();
            _bigdiscount = new Coupon(100, 20);
            _steve.SetStore(_costco);
            _steve.AddCoupon(_bigdiscount);
        }

        [TestMethod]
        /* steve buy only one kind of item, but he didn't meet the threhold of coupon when he checkout */
        public void BuySingleItemNotMeetCouponTheshold()
        {
            _steve.BuyProduct(1, 5);
            _steve.CheckOut();
            _total = _steve.ShowPrice();
            Assert.AreEqual(25, _total);
        }

        [TestMethod]
        /* steve buy many kind of items, but he didn't meet the threhold of coupon when he checkout */
        public void BuyMultipleItemNotMeetCouponTheshold()
        {
            _steve.BuyProduct(1, 2);
            _steve.BuyProduct(4, 4);
            _steve.CheckOut();
            _total = _steve.ShowPrice();
            Assert.AreEqual(14.5, _total);
        }

        [TestMethod]
        /* steve buy only one kind of item, he meet the threhold of coupon when he checkout. He get a discount */
        public void BuySingleItemMeetCouponTheshold()
        {
            _steve.BuyProduct(3, 10);
            _steve.CheckOut();
            _total = _steve.ShowPrice();
            Assert.AreEqual(120, _total);
        }

        [TestMethod]
        /* steve buy many kinds of items, he meet the threhold of coupon when he checkout. He get a discount */
        public void BuyMultipeItemMeetCouponTheshold()
        {
            _steve.BuyProduct(1, 10);
            _steve.BuyProduct(3, 4);
            _steve.CheckOut();
            _total = _steve.ShowPrice();
            Assert.AreEqual(90, _total);
        }
    }
}