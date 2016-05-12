namespace CashRegister
{
    public class Coupon
    {
        /* Coupon has two values: threhold and discount;
            threhold is the sum when a discount can apply
            discount is the cash value of discount when checkout
           */

        public Coupon(double threhold, double discount)
        {
            Threhold = threhold;
            Discount = discount;
        }

        public double Threhold { get; set; }
        public double Discount { get; set; }
    }
}