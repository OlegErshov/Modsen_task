using IdentityServer.Domain.Models;

namespace IdentityServer.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<Response> LogInAsync(UserCredentials userCredentials);
        Task<Response> RegisterAsync(RegistrationModel user);
    }
}
