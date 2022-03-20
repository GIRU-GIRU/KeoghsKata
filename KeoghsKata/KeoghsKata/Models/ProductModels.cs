using System.ComponentModel.DataAnnotations;

namespace KeoghsKata.Models
{
    //Usually i would keep these in seperate files but for the small scope of this kata they're all here
    public class StoreKeepingUnit
    {
        [Key]
        public int Id { get; set; }

        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedUTC { get; set; }
    }

    public class PromotionStoreKeepingUnit
    {
        [Key]

        public int Id { get; set; }

        public PromotionType PromotionType { get; set; }
        public int StoreKeepingUnitId { get; set; }
        public virtual StoreKeepingUnit? StoreKeepingUnit { get; set; }
        public DateTime CreatedUTC { get; set; }

    }

    public enum PromotionType
    {
        None,
        ThreeForForty,
        TwentyFivePrcntOffForEvery2,
    }
}
