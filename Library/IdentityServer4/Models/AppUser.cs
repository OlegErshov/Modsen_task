using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class AppUser : IdentityUser 
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
