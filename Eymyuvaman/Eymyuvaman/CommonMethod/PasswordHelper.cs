using System.Security.Cryptography;
using System.Text;

namespace Eymyuvaman.CommonMethod
{
    public static class PasswordHelper
    {

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static (string Hash, string Salt) HashPasswordWithSalt(string password)
        {
            // Generate random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // Combine password + salt
            string saltedPassword = password + salt;

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(bytes);

            return (Convert.ToBase64String(hash), salt);
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            string saltedPassword = password + storedSalt;

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(bytes);

            string newHash = Convert.ToBase64String(hash);

            return newHash == storedHash;
        }
    }
}
