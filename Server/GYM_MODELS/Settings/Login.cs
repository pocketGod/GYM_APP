using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Settings
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginResult
    {
        public string Token { get; set; }
        public string Error { get; set; }
        public bool IsSuccess => !string.IsNullOrEmpty(Token);
    }
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
