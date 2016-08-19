using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Wpf;

namespace FacebookMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CefPopupWindow : Window
    {
      
        public CefPopupWindow(ISettings settings, string address)
        {
            InitializeComponent();
            Browser = new ChromiumWebBrowser
            {
                DownloadHandler = new Downloader(),
                MenuHandler = new DeveloperContextMenuHandler(settings),
                Address = address
            };
            //Browser.Address = "https://www.mesenger.com/login";


            
            SizeChanged += OnSizeChanged;
        }

        void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (args.HeightChanged)
                Browser.Height = args.NewSize.Height - 45;
        }
    }

 
}
