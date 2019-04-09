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

        public IActionResult SampleSize(NpsCalc nps)
        {
            int size = nps.SampleSize();
            NpsCalc sampleSize = new NpsCalc() { Customers = size };
            return View(nameof(Index), sampleSize);
        }

        public IActionResult CalcNps(NpsCalc nps)
        {
            nps.Customers = 0;
            return View(nameof(Index), nps);
        }
    }
}