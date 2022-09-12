using System.Security.Claims;
using System.Text;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Token
{
    public class TokenService
    {
        private readonly TokenManagement _tokeManager;
        private readonly UserService _serviceUser;
        public TokenService(IOptions<TokenManagement> tokeManager, UserService serviceUser)
        {
            _tokeManager = tokeManager.Value;
            _serviceUser = serviceUser;
        }

        public bool IsAuthenticated(LoginViewModel loginUser, out string token)
        {
            token = string.Empty;
            if(_serviceUser.ValidateUser(loginUser) is false) return false;

            var claim = new[]
            {
                new Claim("Email", loginUser.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokeManager.Secret));
            var credections = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = 
        }
    }
}
