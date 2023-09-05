using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public bool IsAuthenticationActive { get; set; }
    }
}
