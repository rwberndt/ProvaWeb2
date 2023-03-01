using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProvaWeb2_RicardoWehmuth.Models;
using ProvaWeb2_RicardoWehmuth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProvaWeb2_RicardoWehmuth.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly AuthService _authService;

        public LoginController(AuthService tokenService)
        {
            _authService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel login)
        {
            return await Task.Run(() =>
            {
                IActionResult response = Unauthorized();

                var user = _authService.Authenticate(login);

                if (user != null)
                    response = Ok(new { token = _authService.CreateJWT(user) });

                return response;
            });
        }

        [HttpPost,Route("/cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UserModel login)
        {
            return await Task.Run(() =>
            {

                _authService.Cadastrar(login);

                
                return Ok();

            });
        }
    }
}
