using AutorisationApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutorisationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("singinIn/{userName}")]
        public ActionResult<string> SignIn(string userName)
        {
            return _tokenService.CreateToken(userName);
        }
    }
}