using Microsoft.AspNetCore.Mvc;
using WypozyczalniaGier.Models;
using System.Collections.Generic;

namespace WypozyczalniaGier.Controllers
{
    public class HomeController : Controller
    {
        // Akcja wyœwietlaj¹ca listê gier
        public IActionResult Index()
        {
            var games = new List<Game>
            {
                new Game { Id = 1, Title = "Dixit", IsAvailable = true },
                new Game { Id = 2, Title = "To Ja go tnê!", IsAvailable = true },
                new Game { Id = 3, Title = "Dark Souls The Board Game", IsAvailable = true },
                new Game { Id = 4, Title = "Monopoly", IsAvailable = true },
                new Game { Id = 5, Title = "Karty D¿entelmenów", IsAvailable = true },
                new Game { Id = 6, Title = "SpyGuy", IsAvailable = true },
                new Game { Id = 7, Title = "Talizman Magia i Miecz", IsAvailable = true },
                new Game { Id = 8, Title = "Ankh", IsAvailable = true },
                new Game { Id = 9, Title = "Mordercze Krewetki", IsAvailable = true },
            };

            return View(games);
        }

        // Akcja wyœwietlaj¹ca stronê kontaktow¹
        public IActionResult Contact()
        {
            return View();
        }
    }
}
