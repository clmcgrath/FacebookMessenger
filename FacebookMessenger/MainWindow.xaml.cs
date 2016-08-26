using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using CefSharp;
using CefSharp.Wpf;
using MahApps.Metro.Controls;

namespace FacebookMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
      
        public MainWindow(ISettings settings)
        {
            InitializeComponent();
            Browser.DownloadHandler = new Downloader();
            Browser.MenuHandler = new DeveloperContextMenuHandler(settings);
            Browser.LifeSpanHandler = new LifespanHandler(settings);

            

            Browser.Load("http://www.messenger.com/t/");
            Browser.Loaded += BrowserOnLoaded;
           // Browser.SetZoomLevel(100);
            SizeChanged += OnSizeChanged;
            
        }

        private void BrowserOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var browser = sender as IWpfWebBrowser;
            browser.RegisterScript("Resources\\Scripts\\notifications-polyfill.js");
        }


        ICommand OpenSettings { get; set; }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (args.HeightChanged)
                Browser.Height = args.NewSize.Height - 45;

        }
    }



    public class OpenSettingsCommand : ICommand
    {
        private readonly Window _window;

        public OpenSettingsCommand(Window window, ISettingsService settings)
        {
            _window = window;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }

        public event EventHandler CanExecuteChanged;
    }

    public interface ISettingsService
    {
        ISettings Load();
        void Save();
        void Save(string path);
    }
}
