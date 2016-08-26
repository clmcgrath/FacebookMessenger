using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WixSharp;
using WixSharp.Bootstrapper;

namespace FacebookMessenger.Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new Project("Facebook Messenger",
                new Dir(@"%ProgramFiles%\Digital Paradox\Facebook Messenger"
                    //new File(@"Files\Docs\Manual.txt"),
                    //new File(@"Files\Bin\MyApp.exe")
                    ))
            { GUID = new Guid("6f330b47-2577-43ad-9095-1861ba25889b") };

            ;

            ChainItem flashPlayer = new ExePackage(@"Packages\install_flash_player_ppapi.exe");
            flashPlayer.Vital = true;
            flashPlayer.Id = "FLASHPLAYER_INSTALL";


            ChainItem vcredistx86 = new ExePackage(@"Packages\vc_redist.x86.exe");
            vcredistx86.Vital = true;
            vcredistx86.Id = "VCREDISTX86";


            ChainItem vcredistx64 = new ExePackage(@"Packages\vc_redist.x64.exe");
            vcredistx64.Vital = true;
            vcredistx64.Id = "VCREDISTX64";


            Compiler.BuildMsi(project);
        }
    }
}
