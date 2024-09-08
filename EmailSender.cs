using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System;

namespace WypozyczalniaGier // Upewnij się, że ta przestrzeń nazw jest zgodna z Twoim projektem
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Tymczasowa implementacja, logowanie do konsoli zamiast faktycznego wysyłania e-maila
            Console.WriteLine($"Sending email to {email}: {subject}");
            return Task.CompletedTask;
        }
    }
}
