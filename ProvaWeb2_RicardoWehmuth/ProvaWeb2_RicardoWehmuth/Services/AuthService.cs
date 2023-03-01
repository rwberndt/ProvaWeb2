using Microsoft.IdentityModel.Tokens;
using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProvaWeb2_RicardoWehmuth.Services
{
    public class AuthService
    {
        private readonly ComandaContext _context;
        public AuthService(ComandaContext context)
        {
            _context = context;
        }

        public string CreateJWT(UserModel user)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY")); // NOTE: SAME KEY AS USED IN Startup.cs FILE
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, user.username), // this will be "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.username),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")) // this could the unique ID assigned to the user by a database
			};

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel? Authenticate(UserModel login)
        {
            var autenticado = _context.Users.Where(x => x.username == login.username && x.password == login.password).FirstOrDefault();
            return autenticado;
        }
    }
}
