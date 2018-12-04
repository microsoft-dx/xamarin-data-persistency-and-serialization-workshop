using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace WorkingWithData.Utilities
{
    public static class Authentication
    {
        // Create The Method that Authenticates a user with the Server
        public static KeyValuePair<string, User> AuthenTicateWithServer(string userName, string passWord)
        {
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }

        // Create The Method that Authenticates a user Locally
        public static KeyValuePair<string, User> AuthenTicateUseLocally(string userName, string passWord)
        {
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }

        public static KeyValuePair<string, User> AuthenTicateUse(string userName, string passWord)
        {
            // Create a method that combines both
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }
    }
}
