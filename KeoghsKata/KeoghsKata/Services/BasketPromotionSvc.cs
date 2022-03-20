using KeoghsKata.Database;
using KeoghsKata.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace KeoghsKata.Services
{
    public class BasketPromotionSvc : DatabaseServiceBase
    {
        private readonly ISKUSvc _skuSvc;
        public BasketPromotionSvc(IServiceScopeFactory scopeFactory, ILogger<NullLogger> logger, ISKUSvc skuSvc) : base(scopeFactory, logger)
        {
            _skuSvc = skuSvc;
        }

        private decimal CalculateThreeForFortyDiscount(List<StoreKeepingUnit> storeKeepingUnits)
        {
            decimal res = storeKeepingUnits.Select(x => x.UnitPrice).Sum();

            if (storeKeepingUnits.Count > 3)
            {
                res = (storeKeepingUnits.Count / 3) * 40;
                res += (storeKeepingUnits.Count % 3) * storeKeepingUnits.First().UnitPrice;
            }

            return res;
        }

        private decimal CalculateTwentyFivePrcntOffForEvery2(List<StoreKeepingUnit> storeKeepingUnits)
        {
            decimal res = storeKeepingUnits.Select(x => x.UnitPrice).Sum();

            if (storeKeepingUnits.Count > 2)
            {
                var sku = storeKeepingUnits.First();
                res = (storeKeepingUnits.Count / 2) * (sku.UnitPrice * 0.75m);
                res += (storeKeepingUnits.Count % 2) * sku.UnitPrice;
            }

            return res;
        }


        /// <summary>
        /// Takes a list of same store keeping unit types to calculate product discount
        /// </summary>
        /// <param name="storeKeepingUnits"></param>
        /// <returns>a decimal of the new calculated sum total of the list of products</returns>
        /// <exception cref="ArgumentException"></exception>
        private async Task<decimal> ApplySameProductDiscount(List<StoreKeepingUnit> storeKeepingUnits)
        {
            decimal res = 0m;

            if (storeKeepingUnits == null || storeKeepingUnits.Count == 0)
            {
                throw new ArgumentException("Invalid store keeping unit collection was provided");
            }
            if (storeKeepingUnits.Select(x => x.Id).Count() > 1)
            {
                throw new ArgumentException("Only a list of products of the same type can be provided");
            }

            //Usually would consider writing a unit test to test against this logic as i build it without a frontend
            //however didn't want take too long adding unit test project and setting all that up with DI etc.
            try
            {
                res = storeKeepingUnits.Select(x => x.UnitPrice).Sum();

                //As the pricing changes frequently we pull from the database every time to ensure we're up to date with our discounts, rather than caching at startup
                var promotions = await _skuSvc.GetAllPromotions();

                if (promotions != null && promotions.Count() > 0)
                {
                    var matchingPromotions = promotions.FirstOrDefault(x => x.StoreKeepingUnitId == storeKeepingUnits.First().Id);

                    if (matchingPromotions != null)
                    {
                        switch (matchingPromotions.PromotionType)
                        {
                            case PromotionType.None:
                                break;

                            case PromotionType.ThreeForForty:
                                res = CalculateThreeForFortyDiscount(storeKeepingUnits);
                                break;

                            case PromotionType.TwentyFivePrcntOffForEvery2:
                                res = CalculateTwentyFivePrcntOffForEvery2(storeKeepingUnits);
                                break;

                            default:
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred applying discounts - {ex.GetBaseException().Message}");
            }


            return res;
        }

    }
}
