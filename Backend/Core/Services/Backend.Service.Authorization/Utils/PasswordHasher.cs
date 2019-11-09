using System;
using System.Security.Cryptography;
using System.Text;
using Backend.Service.Authorization.Interfaces;

namespace Backend.Service.Authorization.Utils
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Generates hashed password
        /// </summary>
        public static string GetPasswordHash(string password)
        {
            // SHA512 is disposable by inheritance.  
            using var sha256 = SHA256.Create();
            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
