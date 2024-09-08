using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WypozyczalniaGier.Models;

public class GameController : Controller
{
    // Lista dostępnych gier - dostępna dla wszystkich
    public IActionResult Index()
    {
        var games = new List<Game>
        {
            new Game { Id = 1, Title = "Dixit", IsAvailable = true },
            new Game { Id = 2, Title = "Catan", IsAvailable = false },
            new Game { Id = 3, Title = "Carcassonne", IsAvailable = true }
        };

        return View(games);
    }
}
