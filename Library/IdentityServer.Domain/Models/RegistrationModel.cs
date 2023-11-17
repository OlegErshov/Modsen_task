using System.ComponentModel.DataAnnotations;


namespace IdentityServer.Domain.Models
{
    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string> Roles { get; set; }
    }
}
