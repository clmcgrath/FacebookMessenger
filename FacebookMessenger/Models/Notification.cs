using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace FacebookMessenger.Models
{
    public class Notification<T>
    {
        public object Vibrate { get; set; } = new {};
        public string Icon { get; set; }
        public string Body { get; set; }
        public string Sound { get; set; }
        public bool Sticky { get; set; } = false;
        public bool Renotify { get; set; } = false;
        public bool NoScreen { get; set; } = true;
        public Action<T[]> OnClick { get; set; } = obj => { };
        public Action<T[]> OnError { get; set; } = obj => { };
        public string Permission { get; set; } = "default";
        public void Show()
        {
            
        }
        public void Close()
        {
            
        }
    }
}
