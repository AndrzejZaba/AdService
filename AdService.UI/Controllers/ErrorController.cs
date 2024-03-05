using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers;

public class ErrorController : Controller
{
    [HttpGet("/Error")]
    public IActionResult Index()
    {
        return View("Error");
    }
}
