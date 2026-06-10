using System;
using System.Security.Cryptography;
using System.Text;

namespace BruteForceMatcher
{
    public class HashValidator
    {
        private const string StaticSalt = "Druska123"; 
        
        private readonly string _targetHash;
        public HashValidator(string targetHash)   // Save hash 
        {
            _targetHash = targetHash;
        }
        public bool CheckMatch(string attempt)
        {
            string attemptHash = GenerateHash(attempt);
            return attemptHash == _targetHash;
        }
        public static string GenerateHash(string input) // Applies salt and generates SHA256 hash
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input + StaticSalt));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}