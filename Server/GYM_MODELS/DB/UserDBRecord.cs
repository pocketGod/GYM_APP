using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.DB
{
    public class UserDBRecord : BaseDBRecord
    {
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
