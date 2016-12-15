using System;
using System.IO;

namespace FacebookMessenger
{
    public class AppSettings : ISettings
    {
        public bool EnableDebugMenu { get; set; } = true;
        public bool MinimizeToTray { get; set; } = true;
        public bool CloseToTray { get; set; } = true;
        public bool EnableTrayIcon { get; set; } = true;
        public string MessageNotification { get; set; } = "fb-message.wav";
        public bool StartMinimized { get; set; } = false;
        public string MessengerBaseUrl { get; set; } = "https://www.messenger.com";
        public string CachePath { get; set; } =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"dp-facebook-messenger", "CEF_Cache");

    }
}