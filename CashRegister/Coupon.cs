namespace CashRegister
{
    public class Coupon
    {
        public Coupon(double threhold, double discount)
        {
            Threhold = threhold;
            Discount = discount;
        }

        /* Coupon has two values: threhold and discount;
            threhold is the sum when a discount can apply
            discount is the cash value of discount when checkout
           */

        private double Threhold { get; }
        private double Discount { get; }

        public double GetThrehold()
        {
            return Threhold;
        }

        public double GetDiscount()
        {
            return Discount;
        }
    }
}