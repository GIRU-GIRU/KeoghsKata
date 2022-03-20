using KeoghsKata.Models;
using KeoghsKata.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KeoghsKata.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketPromotionSvc _basketPromotionSvc;
        private readonly ISession _session;
        public BasketViewComponent(IBasketPromotionSvc basketPromotionSvc, IHttpContextAccessor httpContextAccessor)
        {
            _basketPromotionSvc = basketPromotionSvc;
            _session = httpContextAccessor.HttpContext.Session;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketModel> basketModels = new();

            var currentBasketStr = _session.GetString("Basket");

            if (!string.IsNullOrEmpty(currentBasketStr))
            {
               var currentItemsInBasket = JsonConvert.DeserializeObject<List<StoreKeepingUnit>>(currentBasketStr);

                if (currentItemsInBasket != null && currentItemsInBasket.Count > 0)
                {
                    basketModels = await CreatePageModel(currentItemsInBasket);
                }
            }

            return View(basketModels);

        }


        private async Task<List<BasketModel>> CreatePageModel(List<StoreKeepingUnit> storeKeepingUnits)
        {

            List<BasketModel> basketModels = new();

            var test = storeKeepingUnits.GroupBy(x => x.Id);

            foreach (var item in test)
            {
                decimal totalPrice = 0m;
                int promotionCount = 0;

                (totalPrice, promotionCount) = await _basketPromotionSvc.ApplySameProductDiscount(item.First(), item.Count());

                basketModels.Add(new BasketModel()
                {
                    Quantity = item.Count(),
                    StoreKeepingUnit = item.First(),
                    TotalPrice = totalPrice,
                    PromotionCount = promotionCount,
                });
            }

            return basketModels;
        }
    }
}
