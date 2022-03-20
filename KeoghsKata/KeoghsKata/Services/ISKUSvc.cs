using KeoghsKata.Models;

namespace KeoghsKata.Services
{
    /// <summary>
    /// Service for handling Store Keeping Units and promotions
    /// </summary>
    public interface ISKUSvc
    {
        /// <summary>
        /// Queries the database for a list of products
        /// </summary>
        /// <returns>A list of StoreKeepingUnits with associated models</returns>
        public Task<List<StoreKeepingUnit>> GetAllProducts();

        /// <summary>
        /// Queries the database for a list of promotions mapped to the SKU's
        /// </summary>
        /// <returns>A list of all promotions</returns>
        public Task<List<PromotionStoreKeepingUnit>> GetAllPromotions();
    }
}
