using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace WorkingWithData.Utilities
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        public const uint INVALID_USER_ID = 0;
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static uint AuthenticatedUserID
        {
            get
            {
                return Convert.ToUInt32(AppSettings.GetValueOrDefault("AUTHENTICATED_USER_ID", INVALID_USER_ID.ToString()));
            }
            set
            {
                AppSettings.AddOrUpdateValue("AUTHENTICATED_USER_ID", value.ToString());
            }
        }

    }
}