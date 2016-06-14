using NativeWifi;
using System;
using System.Text;
using System.Windows.Forms;

namespace WifiExample
{
    class Program
    {
        /// <summary>
        /// Converts a 802.11 SSID to a string.
        /// </summary>
        //static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        //{
        //    return Encoding.ASCII.GetString( ssid.SSID, 0, (int) ssid.SSIDLength );
        //}

        static void Main( string[] args )
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
