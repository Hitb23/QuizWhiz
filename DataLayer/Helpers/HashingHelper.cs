using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.Helpers
{
    public class HashingHelper
    {
        // Helper methods for password hashing and verification
        public string HashPassword(string password)
        {
            // Generate a 128-bit salt using a cryptographically strong random sequence of nonzero values.
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Derive a 256-bit subkey (use HMACSHA1 with 10000 iterations)
            byte[] subkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 20);

            // Combine the salt and subkey into a single byte array
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(subkey, 0, hashBytes, 16, 20);

            // Convert to base64
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Extract the bytes from the stored hash
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract the salt (first 16 bytes)
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Extract the stored subkey (next 20 bytes)
            byte[] storedSubkey = new byte[20];
            Array.Copy(hashBytes, 16, storedSubkey, 0, 20);

            // Hash the input password with the same salt
            byte[] subkey = KeyDerivation.Pbkdf2(
                password: inputPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 20);

            // Compare the computed subkey with the stored subkey
            return storedSubkey.SequenceEqual(subkey);
        }
    }
}
