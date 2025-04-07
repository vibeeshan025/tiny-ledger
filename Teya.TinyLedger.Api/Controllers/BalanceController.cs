using Microsoft.AspNetCore.Mvc;

namespace Teya.TinyLedger.Api.Controllers;

public class BalanceController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}