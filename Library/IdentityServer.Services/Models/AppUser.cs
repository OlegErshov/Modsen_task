using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services.Models
{
    public class AppUser : IdentityUser 
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
