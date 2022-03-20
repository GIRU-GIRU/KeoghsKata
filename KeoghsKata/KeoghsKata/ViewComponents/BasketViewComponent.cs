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


        public Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketModel> basketModels = new();

            var currentBasketStr = _session.GetString("Basket");

            if (!string.IsNullOrEmpty(currentBasketStr))
            {
               var currentItemsInBasket = JsonConvert.DeserializeObject<List<StoreKeepingUnit>>(currentBasketStr);

                if (currentItemsInBasket != null && currentItemsInBasket.Count > 0)
                {
                    basketModels = CreatePageModel(currentItemsInBasket);
                }
            }

            return Task.FromResult<IViewComponentResult>(View(basketModels));

        }


        private List<BasketModel> CreatePageModel(List<StoreKeepingUnit> storeKeepingUnits)
        {

            List<BasketModel> basketModels = new();

            var test = storeKeepingUnits.GroupBy(x => x.Id);

            foreach (var item in test)
            {
                basketModels.Add(new BasketModel()
                {
                    Quantity = item.Count(),
                    StoreKeepingUnit = item.First(),
                    TotalPrice = item.First().UnitPrice * item.Count(),
                });
            }

            return basketModels;
        }
    }
}
