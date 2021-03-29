using System;
using System.Collections.Generic;
using System.Text;

namespace BShop.ViewModel
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}
