using Newtonsoft.Json;
using System.Text;

namespace DataTransferObjects.Users
{
    public class User
    {
        public uint UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }

        public string UserName { get; set; }
        public byte[] AuthenticationToken { get; set; }

        public User() { }

        public User(string serializedUser)
        {
            // deserialize json string containing user data
            User deserializedUser = JsonConvert.DeserializeObject<User>(serializedUser);

            this.UserID = deserializedUser.UserID;
            this.FirstName = deserializedUser.FirstName;
            this.LastName = deserializedUser.LastName;
            this.IsMale = deserializedUser.IsMale;

            this.UserName = deserializedUser.UserName;
            this.AuthenticationToken = deserializedUser.AuthenticationToken;
        }

        public static string HashPassword(string plainTextPassword)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder(64); // sha256 hash length in hexadecimal is 64 characters (256 bits / 4 bits per character = 64 characters)
                                              // create StringBuilder with preallocated size of 64
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword)); // compute hash of password as array of bytes

            // construct hash string from array of bytes
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2")); // append hexadecimal representation of byte to hash
            }

            return hash.ToString();
        }

        public static byte[] HashPasswordBytes(string plainTextPassword)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();

            return crypt.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
        }
    }
}
