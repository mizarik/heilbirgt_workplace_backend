using System.Security.Cryptography;
using System.Text;

namespace heilbrigt_workplace_backend_v01.Services
{
    public class GenerateHash
    {

        public static string ComputeSha512Hash(string rawData)
        {
            // Create a SHA-512 instance
            using (SHA512 sha512 = SHA512.Create())
            {
                // Compute the hash of the input string
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert the byte array to a hex string
                StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString("x2"));
                }

                return result.ToString();
            }
        }
    }
}
