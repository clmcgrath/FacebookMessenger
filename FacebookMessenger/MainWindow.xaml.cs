using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            
            Browser.Load("http://www.messenger.com/t/");

        }

    }

    
}
