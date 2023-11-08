using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Models;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityServer.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;

        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appSettings = options.Value;
        }

        public async Task<Response> LogInAsync(UserCredentials userCredentials)
        {
            ArgumentNullException.ThrowIfNull(nameof(userCredentials));
            var user = await _userManager.FindByNameAsync(userCredentials.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, userCredentials.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var authClaims = GenerateClaims(roles);
                var token = GetToken(authClaims);
                return new Response(true, "User authorized successfully!", token);
            }

            return new Response("Invalid login or password");
        }

        public async Task<Response> RegisterAsync(RegistrationModel user)
        {
            ArgumentNullException.ThrowIfNull(nameof(user));
            var userExists = await _userManager.FindByNameAsync(user.UserName);
            if (userExists != null)
            {
                return new Response("There are user with the same login");
            }

            foreach (var role in user.Roles)
            {
                role.ToLower();
            }

            AppUser applicationUser = new AppUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = user.UserName,
                FirstName = user.FirstName,
                Surname = user.Surname,
                
            };

            if (!await ValidateRoles(user.Roles))
            {
                return new Response("Invalid role");
            }
           

            var result = await _userManager.CreateAsync(applicationUser, user.Password);

            if (!result.Succeeded)
            {
                return new Response("Cannot register user");
            }

            await _userManager.AddToRolesAsync(applicationUser, user.Roles);


            var authClaims = GenerateClaims(user.Roles);
            var token = GetToken(authClaims);

            return new Response(true, "User registered successfully!", token);
        }

        private async Task<bool> ValidateRoles(IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    return false;
                }
            }

            return true;
        }

        private string GetToken(IEnumerable<Claim> claims)
        {
            const int expiringDays = 21;
            byte[] securityKey = Encoding.UTF8.GetBytes(_appSettings.EncryptionKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var securityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddDays(expiringDays),
                claims: claims,
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature),
                issuer: _appSettings.ValidIssuer,
                audience: _appSettings.ValidAudience
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

        private List<Claim> GenerateClaims(IEnumerable<string> roles)
        {
            var authClaims = new List<Claim>();
            foreach (var userRole in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }
    }
}
