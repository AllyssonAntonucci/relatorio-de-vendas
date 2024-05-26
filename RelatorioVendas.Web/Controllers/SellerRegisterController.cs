using Microsoft.AspNetCore.Mvc;
using RelatorioVendas.Web.Services.IService;

namespace RelatorioVendas.Web.Controllers
{
    public class SellerRegisterController : Controller
    {
        private readonly ISellerRegisterService _register;
        public SellerRegisterController(ISellerRegisterService register)
        {
            _register = register;
        }
        public async Task<IActionResult> Register(string name, string state)
        {
            if(name != null && state != null)
            {
                string registerSeller = await _register.RegisterSellersAsync(name, state);

                ViewBag.RegisterMessage = registerSeller;
            }
           
            return View();
        }
    }
}
