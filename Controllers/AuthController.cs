using CookieBasedAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookieBasedAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            HttpContext.Session.SetString("Mykey", "Aman Gaur");
            string data = HttpContext.Session.GetString("MyKey");
            Console.WriteLine(data);
            bool res=await _authService.Login();
            return Ok(new {Message="login success"});
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            
            return Ok(new { Message = "data" });
        }
    }
}
