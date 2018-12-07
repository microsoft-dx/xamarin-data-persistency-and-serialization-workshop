using DataTransferObjects.Users;
using System.Collections.Generic;

namespace WorkingWithData.Utilities
{
    public static class Authentication
    {
        public static KeyValuePair<string, User> AuthenTicateWithServer(string userName, string passWord)
        {
            // TO DO: Create The Method that Authenticates a user with the Server
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }

        public static KeyValuePair<string, User> AuthenTicateUserLocally(string userName, string passWord)
        {
            // TO DO: Create The Method that Authenticates a user Locally
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }

        public static KeyValuePair<string, User> AuthenTicateUser(string userName, string passWord)
        {
            // TO DO: Create a method that combines both
            return new KeyValuePair<string, User>("MethodNotImplemented", null);
        }

        public static void LogOffUser()
        {
            // TO DO: Remove the user info from all required locations in order to make sure he is logged out
        }

        public static void RegisterUser(string userName, string passWord)
        {

        }
    }
}
