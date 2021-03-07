using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpyWire.Model;
using SpyWire.Service;
using SpyWire.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpyWire.Controllers
{
    [Route("User/")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserManager<ApplicationUser> userManager;
        private AppSettings appSettings;

        //private SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> _userManager, IOptions<AppSettings> _appSettings /*, SignInManager<ApplicationUser> _signInManager*/)
        {
            userManager = _userManager;
            //signInManager = _signInManager;
            appSettings = _appSettings.Value;
        }

        [HttpPost("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<ActionResult<IdentityResult>> PostApplicationUser(RegisterViewModel RVM)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = RVM.Username,
                Email = RVM.Email,
            };

            //try
            //{
            if (RVM.ConfirmPassword == RVM.Password)
            {
                IdentityResult result = await userManager.CreateAsync(applicationUser, RVM.Password);
                return Ok(result);
            }
            else return BadRequest( new { message= "password and confirm password do not match" });
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        [HttpPost("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginViewModel LVM)
        {
            var user = await userManager.FindByNameAsync(LVM.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, LVM.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }


        [HttpGet("Profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.Email
            };
            /*
             or:
            return user
             */
        }
    }
}
