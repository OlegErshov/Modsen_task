using System.ComponentModel.DataAnnotations;


namespace IdentityServer.Domain.Models
{
    public class UserCredentials
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
