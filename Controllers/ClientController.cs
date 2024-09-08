using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaGier.Data;
using WypozyczalniaGier.Models;

[Authorize(Roles = "Client")]
public class ClientController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ClientController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Akcja wyświetla listę wypożyczonych gier dla zalogowanego klienta
    public async Task<IActionResult> MyRentals()
    {
        var user = await _userManager.GetUserAsync(User);
        var rentals = _context.Rentals.Where(r => r.ClientId == user.Id).ToList();
        return View(rentals);
    }
}
