using Microsoft.AspNetCore.Mvc;
using RelatorioVendas.Web.Services.IService;

namespace RelatorioVendas.Web.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly IAnalysisService _analysis;

        public AnalysisController(IAnalysisService analysis)
        {
            _analysis = analysis;
        }
        public async Task<IActionResult> AnalysisBySeller(string month, int year)
        {
            try
            {
                if(month != null && year != 0)
                {
                    var sellersBySales = await _analysis.CompareSellers(month, year);

                    ViewBag.SellerSales = sellersBySales;
                    ViewBag.Month = month;
                    ViewBag.Year = year;

                    return View();
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao obter dados da planilha: { ex.Message}");
                return View("Error");
            }
            
        }
    }
}
