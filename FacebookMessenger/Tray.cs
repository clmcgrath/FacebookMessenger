using System;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace FacebookMessenger
{
    public static class Tray 
    {
        public static NotifyIcon CreateNotifyIcon(Application app, MenuItem[] menuItems, ISettings settings)
        {
            var icon = new NotifyIcon
            {
                Icon = Properties.Resources.messenger,
                ContextMenuStrip = new ContextMenuStrip(),
                ContextMenu = new ContextMenu(menuItems)
            };
            
            icon.DoubleClick += delegate
            {
                app.MainWindow.Show();
                app.MainWindow.WindowState = System.Windows.WindowState.Normal;

            };

            if (settings.CloseToTray)
            {
                app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                app.MainWindow.Closing += (sender, args) =>
                {
                    args.Cancel = true;
                    app.MainWindow.Hide();
                };
            }
            if (settings.MinimizeToTray)
            {
                app.MainWindow.Deactivated += (sender, args) =>
                {
                    var window = sender as MainWindow;

                    if (window?.WindowState != WindowState.Minimized) return;

                    window.Hide();
                };
            }

            return icon;
            
        }

    }
}