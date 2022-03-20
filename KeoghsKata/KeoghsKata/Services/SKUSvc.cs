using KeoghsKata.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Reflection;

namespace KeoghsKata.Services
{
    public class SKUSvc : ServiceBase, ISKUSvc
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
                _logger.LogError($"Error occurred in {Utilities.GetCurrentMethodName()} - {ex.GetBaseException().Message}");
            }

            return res;
        }
    }
}
