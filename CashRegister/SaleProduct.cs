namespace CashRegister
{
    public class SaleProduct : ProductBase
    {
        /* Sale Product has a theshold value and a discount value. When bulk number reached, discount will be apply 
         create a sale item should be item( item's id, item's name, item's price(by unit), is item can be weight or not, bulk's number, bulk's discount)
             */
        public double Discount;
        public double Theshold;

        public SaleProduct(int productId, string productName, double productPrice, bool isWeightable, double theshold,
            double discount)
        {
            ProductId = productId;
            ProductPrice = productPrice;
            IsWeightable = isWeightable;
            Theshold = theshold;
            Discount = discount;
        }
    }
}