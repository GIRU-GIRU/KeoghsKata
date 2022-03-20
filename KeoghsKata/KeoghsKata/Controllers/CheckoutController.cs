using KeoghsKata.Models;
using KeoghsKata.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KeoghsKata.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ISKUSvc _skuSvc;
        private readonly ISession _session;



        public CheckoutController(ILogger<CheckoutController> logger, ISKUSvc skuSvc, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _skuSvc = skuSvc;
            _session = httpContextAccessor.HttpContext.Session;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CheckoutPage()
        {
            List<StoreKeepingUnit> allStoreKeepingUnits = await _skuSvc.GetAllProducts();

            return View(allStoreKeepingUnits);
        }

        public async Task<IActionResult> Test(int Id)
        {
            List<StoreKeepingUnit> allStoreKeepingUnits = await _skuSvc.GetAllProducts();

            var itemToAddToBasket = allStoreKeepingUnits.FirstOrDefault(x => x.Id == Id);

            if (itemToAddToBasket != null)
            {
                List<StoreKeepingUnit> basketItems = new();

                var currentBasketStr = _session.GetString("Basket");

                if (!string.IsNullOrEmpty(currentBasketStr))
                {
                     var currentBasket = JsonConvert.DeserializeObject<List<StoreKeepingUnit>>(currentBasketStr);

                    if (currentBasket != null) basketItems = currentBasket;      
                }
           

                basketItems.Add(itemToAddToBasket);

                _session.SetString("Basket", JsonConvert.SerializeObject(basketItems));
            }


            return View("CheckoutPage", allStoreKeepingUnits);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}