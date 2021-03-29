﻿using BShop.Model;
using BShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BShop.Service.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private UserManager<ApplicationUser> userManager;
        private JWTConfig jwtsettings;

        public UserRepository(UserManager<ApplicationUser> _userManager, IOptions<JWTConfig> _jwtsettings /*, SignInManager<ApplicationUser> _signInManager*/)
        {
            userManager = _userManager;
            //signInManager = _signInManager;
            jwtsettings = _jwtsettings.Value;
        }


        public async Task<AuthResult> LoginAsync(LoginViewModel LVM)
        {
            var existingUser = await userManager.FindByEmailAsync(LVM.Email);

            if (existingUser == null)
            {
                return new AuthResult()
                {
                    Errors = new List<string>() {
                                "Invalid Email. User does not exist"
                    },
                    IsSuccessful = false
                };
            }

            var isCorrect = await userManager.CheckPasswordAsync(existingUser, LVM.Password);

            if (!isCorrect)
            {
                return new AuthResult()
                {
                    Errors = new List<string>() {
                                "Password is incorrect"
                            },
                    IsSuccessful = false
                };
            }

            var jwtToken = GenerateJWTToken(existingUser);

            return new AuthResult()
            {
                IsSuccessful = true,
                Token = jwtToken
            };
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }


        public async Task<AuthResult> RegisterAsync(RegisterViewModel RVM)
        {
            AuthResult authResult = new AuthResult() { IsSuccessful = true, Errors = new List<string>()};
            
            var ExistingUserEmail = await userManager.FindByEmailAsync(RVM.Email);
            if (ExistingUserEmail != null)
            {
                authResult.IsSuccessful = false;
                authResult.Errors.Add("Email Already exists");
            }

            var ExistingUserName = await userManager.FindByNameAsync(RVM.Username);
            if (ExistingUserName != null)
            {
                authResult.IsSuccessful = false;
                authResult.Errors.Add("Username Already exists");
            }

            if (RVM.ConfirmPassword != RVM.Password)
            {
                authResult.IsSuccessful = false;
                authResult.Errors.Add("Password and confirm password do not match!");
            }
            
            if(authResult.IsSuccessful)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = RVM.Username,
                    Email = RVM.Email,
                };

                IdentityResult result = await userManager.CreateAsync(applicationUser, RVM.Password);
                if (result.Succeeded)
                {
                    authResult.Token = GenerateJWTToken(applicationUser);
                    authResult.IsSuccessful = true;
                }
                else
                {
                    authResult.IsSuccessful = false;
                    authResult.Errors.Add("Unable to create user");
                }
            }

            return authResult;
        }
        

        public object ShowProfile()
        {
            throw new NotImplementedException();
        }


        private string GenerateJWTToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(jwtsettings.JWT_Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
