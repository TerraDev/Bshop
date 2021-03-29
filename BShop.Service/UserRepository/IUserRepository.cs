using BShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BShop.Service.UserRepository
{
    public interface IUserRepository
    {
        Task<AuthResult> LoginAsync(LoginViewModel LogonVM);

        Task<AuthResult> RegisterAsync(RegisterViewModel RVM);

        object ShowProfile();

        void Logout();
    }
}
