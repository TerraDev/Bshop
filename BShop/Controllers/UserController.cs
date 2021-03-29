using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BShop.Model;
using BShop.Service;
using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BShop.Service.UserRepository;

namespace BShop.Controllers
{
    [Route("User/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository _UserRepository)
        {
            userRepository = _UserRepository;
        }

        [HttpPost("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<ActionResult<AuthResult>> RegisterUser(RegisterViewModel RVM)
        {
            if(ModelState.IsValid)
            {
                AuthResult result = await userRepository.RegisterAsync(RVM);
                if (result.IsSuccessful)
                    return Ok(result);
                else
                    return BadRequest(result);
            }

            return BadRequest( new AuthResult {
                IsSuccessful=false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        [HttpPost("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> LoginUser(LoginViewModel LVM)
        {
            if (ModelState.IsValid)
            {
                AuthResult result = await userRepository.LoginAsync(LVM);
                if (result.IsSuccessful)
                    return Ok(result);
                else
                    return BadRequest(result);
            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                IsSuccessful = false
            });
        }

        //[HttpGet("Profile")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        ////GET : /api/UserProfile
        //public async Task<Object> GetUserProfile() //probably should input the token also
        //{
        //    string userId = User.Claims.First(c => c.Type == "UserID").Value;
        //    ApplicationUser user = await userManager.FindByIdAsync(userId);
        //    return new
        //    {
        //        user.UserName,
        //        user.Email
        //    };
        //}

    }
}
