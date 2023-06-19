using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ArticPolar.Dev
{
    public class libLink
    {
        public static void OpenUrlInDefaultBrowser(string url)
        {
            try
            {
                string browserPath = GetDefaultBrowserPath().Replace("\"", "").Trim();
                Process.Start(browserPath, url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the default browser path: " + ex.Message);
                MessageBox.Show("BrowserPath: " + GetDefaultBrowserPath());
            }
        }
        static string GetDefaultBrowserPath()
        {
            string browserPath = string.Empty;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
            {
                if (userChoiceKey != null)
                {
                    object progIdValue = userChoiceKey.GetValue("Progid");
                    if (progIdValue != null)
                    {
                        string progId = progIdValue.ToString();
                        using (RegistryKey progIdKey = Registry.ClassesRoot.OpenSubKey(progId + @"\shell\open\command"))
                        {
                            object commandValue = progIdKey.GetValue(null);
                            if (commandValue != null)
                            {
                                string command = commandValue.ToString();
                                int exePathEndIndex = command.IndexOf(".exe", StringComparison.OrdinalIgnoreCase) + 4;
                                if (exePathEndIndex >= 4)
                                {
                                    browserPath = command.Substring(0, exePathEndIndex);
                                }
                            }
                        }
                    }
                }
            }
            return browserPath;
        }
    }
}
