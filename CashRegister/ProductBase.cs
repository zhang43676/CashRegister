namespace CashRegister
{
    public abstract class ProductBase
        /* product basic information */
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public bool IsWeightable { get; set; }
    }
}