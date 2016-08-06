using CefSharp;
using Microsoft.Win32;

namespace FacebookMessenger
{
    public class Downloader : IDownloadHandler
    {
        
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var save_dialog = new SaveFileDialog();
            save_dialog.FileName = downloadItem.SuggestedFileName;

            if (save_dialog.ShowDialog() ?? false)
            {
                callback.Continue(save_dialog.FileName, false);    
            }

        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            
        }
    }
}