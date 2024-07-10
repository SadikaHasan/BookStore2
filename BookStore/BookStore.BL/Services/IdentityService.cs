using BookStore.BL.Interfaces;
using BookStore.Models.Configurations.Identity;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using IdentityUser = BookStore.Models.Models.Users.IdentityUser;
using AspNetCore.Identity.MongoDbCore.Models;

namespace BookStore.BL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(ILogger<IdentityService> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtSettings jwtSettings)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult>
            RegisterAsync(string userName, string password, string email)
        {
            var existingUser =
                await _userManager.FindByNameAsync(userName);

            if (existingUser != null)
            {
                _logger.LogWarning($"User already exist!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Errors = new string[] { $"User already exist!" },
                };
            }

            var user = new IdentityUser()
            {
                UserName = userName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                _logger.LogWarning($"Error registering user!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Errors = new string[] { $"Error registering user!" },
                };
            }

            return await GenerateAuthenticationResult(user);
        }

        public async Task<AuthenticationResult>
            LoginAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                _logger.LogWarning($"User {user} does not exist!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Errors = new string[] { $"User/Password combination is wrong!" }
                };
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!validPassword)
            {
                _logger.LogWarning($"User {user} wrong password!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Errors = new string[] { $"User/Password combination is wrong!" }
                };
            }

            return await GenerateAuthenticationResult(user);
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }


        private async Task<AuthenticationResult>
            GenerateAuthenticationResult(IdentityUser user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key =
                    Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(
                        new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("View", "View")
                        }
                    ),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                await _signInManager.SignInAsync(
                    user,
                    false);

                return new AuthenticationResult()
                {
                    IsSuccess = true,
                    Errors = new string[] { },
                    Token = tokenHandler.WriteToken(token)
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error generating token:{e.Message}-{e.StackTrace}");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Errors = new string[] {e.Message },
                };
            }
        }
    }
}
