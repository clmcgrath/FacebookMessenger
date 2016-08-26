using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;

namespace FacebookMessenger
{
    public static class ScriptHelpers
    {
        public static void RegisterScript(this IWpfWebBrowser browser, string path, params object[] p )
        {
            Contract.Assert(browser != null, nameof(browser) + " is null.");
            Contract.Assert(!string.IsNullOrEmpty(path), nameof(path) + " is null or empty.");
            var fi = new FileInfo(path);
            if (!fi.Exists)
            {
                throw new FileNotFoundException($"{path} was not found.");
            }
            var js = File.ReadAllText(path);
            
            browser.ExecuteScriptAsync(js, p);
        }

    }
}
