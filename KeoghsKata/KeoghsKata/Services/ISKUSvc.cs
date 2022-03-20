using KeoghsKata.Models;

namespace KeoghsKata.Services
{
    public interface ISKUSvc
    {
        /// <summary>
        /// Queries the database for a list of products
        /// </summary>
        /// <returns>A list of StoreKeepingUnits with associated models</returns>
        public Task<List<StoreKeepingUnit>> GetAllProducts();
    }
}
