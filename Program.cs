using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaGier.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using WypozyczalniaGier; // Dodaj tę linię, aby odwołać się do klasy EmailSender

var builder = WebApplication.CreateBuilder(args);

// Dodaj usługi do kontenera.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja Identity z obsługą ról
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Dodaj Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

// Rejestracja tymczasowej usługi EmailSender
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

// Tworzenie ról (Admin i Client) oraz domyślnego użytkownika Admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roleNames = { "Admin", "Client" };
    foreach (var roleName in roleNames)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Tworzenie domyślnego użytkownika Admin
    var adminEmail = "admin@wypozyczalnia.pl";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var createPowerUser = await userManager.CreateAsync(newAdminUser, "AdminPassword123!");
        if (createPowerUser.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdminUser, "Admin");
        }
    }
}

// Konfiguracja potoków HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
