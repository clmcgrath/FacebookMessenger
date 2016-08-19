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
    public partial class MainWindow : Window
    {
      
        public MainWindow(ISettings settings)
        {
            InitializeComponent();
            Browser.DownloadHandler = new Downloader();
            Browser.MenuHandler = new DeveloperContextMenuHandler(settings);
            //Browser.Address = "https://www.mesenger.com/login";
            Browser.LifeSpanHandler = new LSHandler(settings);
            Browser.Load("http://www.messenger.com/t/");

           // Browser.SetZoomLevel(100);
            SizeChanged += OnSizeChanged;
        }

        void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (args.HeightChanged)
                Browser.Height = args.NewSize.Height - 45;
        }
    }

    public class LSHandler : ILifeSpanHandler
    {
        readonly ISettings _settings;

        public LSHandler(ISettings settings)
        {
            _settings = settings;
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName,
            WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo,
            IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            if (targetUrl.Contains("messenger.com") || 
                targetFrameName.Contains("Video Call"))
            {
                var pop = new CefPopupWindow(_settings, targetUrl);
                pop.Show();
                newBrowser = pop.Browser;
                //((ChromiumWebBrowser) newBrowser).GetBrowser()?.CloseBrowser(true);
                return false;
            }

            //launch url in new browser if non messenger popup window 
            System.Diagnostics.Process.Start(targetUrl);
            newBrowser = null;
            
            return false;
            

        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}
