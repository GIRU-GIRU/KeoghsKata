using KeoghsKata.Models;
using KeoghsKata.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KeoghsKata.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ISKUSvc _skuSvc;

        public CheckoutController(ILogger<CheckoutController> logger, ISKUSvc skuSvc)
        {
            _logger = logger;
            _skuSvc = skuSvc;
        }

        public  IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CheckoutPage()
        {
            List<StoreKeepingUnit> storekeepingUnits = await _skuSvc.GetAllProducts();

            return View(storekeepingUnits);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}