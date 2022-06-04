using Microsoft.AspNetCore.Mvc;

namespace DPAT_eindopdracht.Controllers;

[ApiController]
[Route("/game   ")]
public class GameController : Controller
{
    [HttpGet]
    public string Index()
    {
        return "okeh";
    }
}