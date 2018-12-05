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
        public string AuthentiCationToken { get; set; }

        public User() { }

        public User(string serializedUser)
        {
            User deserializedUser = JsonConvert.DeserializeObject<User>(serializedUser);

            this.UserID = deserializedUser.UserID;
            this.FirstName = deserializedUser.FirstName;
            this.LastName = deserializedUser.LastName;
            this.IsMale = deserializedUser.IsMale;

            this.UserName = deserializedUser.UserName;
            this.AuthentiCationToken = deserializedUser.UserName;
        }

        public static string HashPassword(string plainTextPassword)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
