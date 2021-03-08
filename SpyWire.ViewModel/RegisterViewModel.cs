using System;
using System.Collections.Generic;
using System.Text;

namespace BShop.ViewModel
{
    public class RegisterViewModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public String ConfirmPassword { get; set; }
    }
}
