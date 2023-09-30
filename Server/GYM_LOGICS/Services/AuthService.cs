
using GYM_DB.Repositories;
using GYM_MODELS.DB;
using GYM_MODELS.Settings;
using System.Security.Cryptography;

namespace GYM_LOGICS.Services
{
    public class AuthService
    {
        private readonly JWTService _jwtService;
        private readonly IUserRepository _userRepository;

        public AuthService(JWTService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public LoginResult Login(LoginModel loginForm)
        {
            LoginResult result = new();

            UserDBRecord? userRecord = _userRepository.FindUserByUsername(loginForm.Username);

            if (userRecord == null)
            {
                result.Error = "User not found";
                return result;
            }


            if (!UnhashAndValidatePassword(loginForm.Password, userRecord.Pass))
            {
                result.Error = "Invalid credentials";
                return result;
            }

            result.Token = _jwtService.GenerateJwtToken(userRecord._id);


            return result;
        }

        public LoginResult Register(RegisterModel registerModel)
        {
            LoginResult result = new LoginResult();

            // Validate the password
            if (!IsChosenPasswordValid(registerModel.Password))
            {
                result.Error = "Invalid password. It must be at least 6 characters long and include at least 1 letter and 1 number.";
                return result;
            }

            UserDBRecord? existingUser = _userRepository.FindUserByUsername(registerModel.Username);

            if (existingUser != null)
            {
                result.Error = "User already exists";
                return result;
            }

            string encryptedPassword = EncryptPassword(registerModel.Password);

            UserDBRecord newUser = new UserDBRecord
            {
                User = registerModel.Username,
                Pass = encryptedPassword
            };

            _userRepository.InsertUser(newUser);

            // Generate a token for the new user
            result.Token = _jwtService.GenerateJwtToken(newUser._id);

            return result;
        }



        private bool UnhashAndValidatePassword(string inputPassword, string storedHash)
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

        private bool IsChosenPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (password.Length < 6)
            {
                return false;
            }

            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }

                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasLetter && hasDigit)
                {
                    return true;
                }
            }

            return false;
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
