using System;
using Microsoft.AspNetCore.Identity;

namespace WypozyczalniaGier.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string GameTitle { get; set; }
        public string ClientId { get; set; }
        public IdentityUser Client { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
