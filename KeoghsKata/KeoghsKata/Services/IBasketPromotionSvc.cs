using KeoghsKata.Database;
using KeoghsKata.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace KeoghsKata.Services
{
    public interface IBasketPromotionSvc 
    {

        /// <summary>
        /// Takes a list of same store keeping unit types to calculate product discount
        /// </summary>
        /// <param name="storeKeepingUnits"></param>
        /// <returns>a decimal of the new calculated sum total of the list of products</returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<decimal> ApplySameProductDiscount(List<StoreKeepingUnit> storeKeepingUnits);

    }
}
