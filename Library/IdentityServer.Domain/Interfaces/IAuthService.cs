using IdentityServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<Response> LogInAsync(UserCredentials userCredentials);
        Task<Response> RegisterAsync(RegistrationModel user);
    }
}
