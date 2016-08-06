using CefSharp;

namespace FacebookMessenger
{

    public class DeveloperContextMenuHandler :IContextMenuHandler
    {
        ISettings _settings;

        public DeveloperContextMenuHandler(ISettings settings)
        {
            _settings = settings;
        }

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters,
            IMenuModel model)
        {
            
            model.AddItem(CefMenuCommand.Reload, "Reload");
            model.AddItem(CefMenuCommand.CustomFirst, "Show Dev Tools");
            
            model.Remove(CefMenuCommand.Print);
            model.Remove(CefMenuCommand.ViewSource);
            
        }


        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters,
            CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            switch (commandId)
            {
                case CefMenuCommand.CustomFirst:
                    browser.ShowDevTools();
                    break;
                case CefMenuCommand.Reload:
                    browser.GoBack();
                    break;
            }
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters,
            IMenuModel model, IRunContextMenuCallback callback)
        {
            return !_settings.EnableDebugMenu;
        }
    }
}