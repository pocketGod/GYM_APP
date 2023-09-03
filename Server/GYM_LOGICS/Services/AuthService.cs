
using GYM_MODELS.DB;
using GYM_MODELS.Settings;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;

namespace GYM_LOGICS.Services
{
    public class AuthService
    {
        private readonly JWTService _jwtService;
        private readonly IMongoDatabase _databaseRef;
        private readonly string _collectionName = "Users";

        public AuthService(JWTService jwtService, IMongoDatabase databaseRef)
        {
            _jwtService = jwtService;
            _databaseRef = databaseRef;
        }

        public LoginResult Login(LoginModel loginForm)
        {
            var result = new LoginResult();

            var userCollectionRef = _databaseRef.GetCollection<UserDBRecord>(_collectionName);
            var filter = Builders<UserDBRecord>.Filter.Eq(u => u.User, loginForm.Username);
            var userRecord = userCollectionRef.Find(filter).FirstOrDefault();

            if (userRecord == null)
            {
                result.Error = "User not found";
                return result;
            }


            if (!ValidatePassword(loginForm.Password, userRecord.Pass))
            {
                result.Error = "Invalid credentials";
                return result;
            }

            result.Token = _jwtService.GenerateJwtToken(userRecord._id);

            return result;
        }

        private bool ValidatePassword(string inputPassword, string storedHash)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            /* Compute the hash on the password the user is trying to login with */
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private string EncryptPassword(string password)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[16];
            rng.GetBytes(saltBytes);

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(saltBytes, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }

}
