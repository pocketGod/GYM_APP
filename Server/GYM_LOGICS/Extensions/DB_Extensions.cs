using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GYM_LOGICS.Extensions
{
    public static class DB_Extensions
    {
        public static bool IsValidMongoDBObjectId(this string str)
        {
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[0-9a-fA-F]{24}$");
        }
    }
}
