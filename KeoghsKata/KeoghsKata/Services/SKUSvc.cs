using KeoghsKata.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Reflection;

namespace KeoghsKata.Services
{
    public class SKUSvc : DatabaseServiceBase, ISKUSvc
    {
    
       public SKUSvc(IServiceScopeFactory scopeFactory, ILogger<NullLogger> logger) : base(scopeFactory, logger)
       {
       }

        public async Task<List<StoreKeepingUnit>> GetAllProducts()
        {
            List<StoreKeepingUnit> res = new();

            try
            {
                var db = GetContext();

                res = await db.StoreKeepingUnits.ToListAsync(); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Utilities.GetCurrentMethodName()} - {ex.GetBaseException().Message}", ex);
            }

            return res;
        }

        public async Task<List<PromotionStoreKeepingUnit>> GetAllPromotions()
        {
            List<PromotionStoreKeepingUnit> res = new();

            try
            {
                var db = GetContext();

                res = await db.PromotionStoreKeepingUnits
                     .Include(x => x.StoreKeepingUnit)
                         .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Utilities.GetCurrentMethodName()} - {ex.GetBaseException().Message}", ex);
            }

            return res;
        }
    }
}
