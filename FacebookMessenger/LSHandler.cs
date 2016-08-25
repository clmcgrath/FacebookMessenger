using CefSharp;

namespace FacebookMessenger
{
    public class LifespanHandler : ILifeSpanHandler
    {
        readonly ISettings _settings;

        public LifespanHandler(ISettings settings)
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