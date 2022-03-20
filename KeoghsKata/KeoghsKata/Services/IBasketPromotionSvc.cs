using KeoghsKata.Database;
using KeoghsKata.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace KeoghsKata.Services
{
    public interface IBasketPromotionSvc 
    {

        /// <summary>
        /// Takes a store keeping unit type and the quantities and applies a promotion
        /// </summary>
        /// <param name="storeKeepingUnits"></param>
        /// <param name="quantity"></param>
        /// <returns>the modified total price of the units with promotion applied as a decimal, and the amount of promotions applied</returns>
        public Task<(decimal, int)> ApplySameProductDiscount(StoreKeepingUnit storeKeepingUnits, int quantity);

    }
}
