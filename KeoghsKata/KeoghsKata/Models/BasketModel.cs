namespace KeoghsKata.Models
{
    public class BasketModel
    {
        public StoreKeepingUnit StoreKeepingUnit { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int PromotionCount { get; set; }
    }
}
