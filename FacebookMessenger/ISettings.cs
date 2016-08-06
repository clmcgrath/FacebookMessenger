namespace FacebookMessenger
{
    public interface ISettings
    {
        bool EnableDebugMenu { get; set; }
        bool MinimizeToTray { get; set; }
        bool CloseToTray { get; set; }
        bool EnableTrayIcon { get; set; }
        string MessageNotification { get; set; }
        bool StartMinimized { get; set; }
    }
}