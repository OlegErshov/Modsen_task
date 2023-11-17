
namespace IdentityServer.Domain.Models
{
    public class AppSettings
    {
        public string EncryptionKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
