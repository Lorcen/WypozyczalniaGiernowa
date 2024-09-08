using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaGier.Data;
using WypozyczalniaGier.Models;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Akcja wyświetla listę wypożyczeń, dostępna tylko dla adminów
    public IActionResult Rentals()
    {
        var rentals = _context.Rentals.Include(r => r.Client).ToList();
        return View(rentals);
    }
}
