using Blog_App.Models;
using Blog_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly LoginService loginservice;

        public LoginController(LoginService loginservice)
        {
            this.loginservice = loginservice;
        }

        [HttpGet]
        public async Task<List<Login>> GetLogin()
        {
            return await loginservice.GetAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Post(Login newLogin)
        {
            await loginservice.CreateAsync(newLogin);

            return CreatedAtAction(nameof(GetLogin), new { id = newLogin.Id }, newLogin);
        }
    }
}
