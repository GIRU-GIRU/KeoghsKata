using KeoghsKata.Database;
using KeoghsKata.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace KeoghsKata.Services
{
    public class BasketPromotionSvc : DatabaseServiceBase, IBasketPromotionSvc
    {
        private readonly ISKUSvc _skuSvc;
        public BasketPromotionSvc(IServiceScopeFactory scopeFactory, ILogger<NullLogger> logger, ISKUSvc skuSvc) : base(scopeFactory, logger)
        {
            _skuSvc = skuSvc;
        }

        private (decimal, int) CalculateThreeForFortyDiscount(StoreKeepingUnit storeKeepingUnit, int quantity)
        {
            decimal res = storeKeepingUnit.UnitPrice * quantity;
            int promotionCount = 0;


            if (quantity > 3)
            {
                res = (quantity / 3) * 40;
                res += (quantity % 3) * storeKeepingUnit.UnitPrice;

                promotionCount = quantity / 3;

            }

            return (res, promotionCount);
        }

        private (decimal, int) CalculateTwentyFivePrcntOffForEvery2(StoreKeepingUnit storeKeepingUnit, int quantity)
        {
            decimal res = storeKeepingUnit.UnitPrice * quantity;
            int promotionCount = 0;

            if (quantity > 2)
            {
                res = (quantity / 2) * (storeKeepingUnit.UnitPrice * 0.75m);
                res += (quantity % 2) * storeKeepingUnit.UnitPrice;

                promotionCount = quantity / 2;
            }

            return (res, promotionCount);
        }


        ///<inheritdoc/>
        public async Task<(decimal, int)> ApplySameProductDiscount(StoreKeepingUnit storeKeepingUnit, int quantity )
        {
            decimal res = 0m;
            int promotionCount = 0;

            if (storeKeepingUnit == null)
            {
                throw new ArgumentException("Invalid store keeping unit collection was provided");
            }
   
            //Usually would consider writing a unit test to test against this logic as i build it without a frontend
            //however didn't want take too long adding unit test project and setting all that up with DI etc.
            try
            {
                res = storeKeepingUnit.UnitPrice * quantity;

                //As the pricing changes frequently we pull from the database every time to ensure we're up to date with our discounts, rather than caching at startup
                var promotions = await _skuSvc.GetAllPromotions();

                if (promotions != null && promotions.Count() > 0)
                {

                    //This logic currently only supports only one promotion per unit, a grouping with loop would be required to extend - time constraints
                    var matchingPromotions = promotions.FirstOrDefault(x => x.StoreKeepingUnitId == storeKeepingUnit.Id);

                    if (matchingPromotions != null)
                    {
                        switch (matchingPromotions.PromotionType)
                        {
                            case PromotionType.None:
                                break;

                            case PromotionType.ThreeForForty:
                                (res, promotionCount) = CalculateThreeForFortyDiscount(storeKeepingUnit, quantity);
                                break;

                            case PromotionType.TwentyFivePrcntOffForEvery2:
                                (res, promotionCount) = CalculateTwentyFivePrcntOffForEvery2(storeKeepingUnit, quantity);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred applying discounts - {ex.GetBaseException().Message}", ex);
            }


            return (res, promotionCount);
        }

    }
}
