namespace CashRegister
{
    public class RegularPriceProduct : ProductBase
    {
        /* This is just a regular price product, nothing special
         * create a regular price item should be item( item's id, item's name, item's price(by unit), is item can be weight or not)
         *  */

        public RegularPriceProduct(int productId, string productName, double productPrice, bool isWeightable)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            IsWeightable = IsWeightable;
        }
    }
}