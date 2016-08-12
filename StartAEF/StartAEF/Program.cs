using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartAEF
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new HZL1());

            string str1;
            String HZL1, HZL1sim;
            str1 = @"C:\Program Files\3S Software\CoDeSys V2.3\CoDeSysHMI\CoDeSysHMI.exe";
            HZL1 = @"D:\Francis\AEF\HZL1\HZL1\HZL1.pro  /target  /visudownload";
            HZL1sim = @"D:\Francis\AEF\HZL1\HZL1\HZL1.pro  /simulation /visudownload";
            Process.Start(str1, HZL1);
        }
    }
}
