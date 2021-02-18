using System;
using System.Security.Cryptography;

namespace EducationPortalADO.DAL.Infrastructure
{
    public class PasswordHasher
    {
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 20;
        private const int DEFAULT_ITERATIONS_COUNT = 10000;
        private const string HASH_V1 = "EP|PH|V1";

        public static string HashPassword(string password, int iterations = DEFAULT_ITERATIONS_COUNT)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                rng.GetBytes(salt = new byte[SALT_SIZE]);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(HASH_SIZE);
                    // Combine salt and hash
                    var hashBytes = new byte[SALT_SIZE + HASH_SIZE];
                    Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
                    Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);
                    // Convert to base64
                    var base64Hash = Convert.ToBase64String(hashBytes);

                    // Format hash
                    return $"{HASH_V1}${iterations}${base64Hash}";
                }
            }
        }
        
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains(HASH_V1);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace(HASH_V1, "").Split('$');
            var iterations = int.Parse(splittedHashString[1]);
            var base64Hash = splittedHashString[2];

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            // Get salt
            var salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            // Create hash with given salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

                // Get result
                for (var i = 0; i < HASH_SIZE; i++)
                {
                    if (hashBytes[i + SALT_SIZE] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
