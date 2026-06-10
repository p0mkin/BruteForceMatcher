using System;

namespace BruteForceMatcher
{
    public class PasswordManager
    {
        // REQUIREMENT 4b: Random password generation based on GUI selector length
        public static string GenerateRandomPassword(int length)
        {
            var random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!?@#£$%^&*()-=";
            var password = new char[length];
            
            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            
            return new string(password);
        }
    }
}