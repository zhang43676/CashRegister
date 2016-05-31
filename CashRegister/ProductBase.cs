namespace CashRegister
{
    public abstract class ProductBase
        /* product basic information */
    {
        protected int ProductId { get; set; }
        protected string ProductName { get; set; }
        protected double ProductPrice { get; set; }
        protected bool IsWeightable { get; set; }

        public int GetProductId()
        {
            return ProductId;
        }

        public string GetProductName()
        {
            return ProductName;
        }

        public double GetProductPrice()
        {
            return ProductPrice;
        }

        public bool GetIsWeightable()
        {
            return IsWeightable;
        }
    }
}