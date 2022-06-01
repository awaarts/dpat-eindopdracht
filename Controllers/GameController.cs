using Microsoft.AspNetCore.Mvc;

namespace DPAT_eindopdracht.Controllers;

public class GameController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}