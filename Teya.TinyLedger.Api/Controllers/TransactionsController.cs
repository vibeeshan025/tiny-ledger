using Microsoft.AspNetCore.Mvc;

namespace Teya.TinyLedger.Api.Controllers;

public class TransactionsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}