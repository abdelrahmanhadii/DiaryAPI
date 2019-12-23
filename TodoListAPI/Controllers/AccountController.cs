using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Helpers;

namespace TodoListAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginDTO entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.UserName, entity.Password,  false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(entity.UserName);
                var roles = await _userManager.GetRolesAsync(user);
                return new { Token = Token.CreateToken(user.Id, roles) };
            }
            return 0;
        }

        [HttpPost("Register")]
        public async Task<object> Register([FromBody] RegisterDTO entity)
        {
            var user = new ApplicationUser { Email = entity.Email, UserName = entity.UserName };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return new { Token = Token.CreateToken(user.Id, roles) };
            }
            return 0;
        }
    }
}