using Microsoft.AspNetCore.Mvc;
using Nps.Models;

namespace Nps.Controllers
{
    public class NpsCalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Tamanho-da-amostra")]
        public IActionResult SampleSize(NpsCalc nps)
        {
            return View(nameof(Index), nps);
        }

        [HttpPost("/Valor-NPS")]
        public IActionResult CalcNps(NpsCalc nps)
        {
            nps.Customers = 0;
            return View(nameof(Index), nps);
        }
    }
}