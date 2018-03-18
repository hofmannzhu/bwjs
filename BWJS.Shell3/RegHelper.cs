using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace BWJS.Shell3
{
    public static class RegHelper
    {
        public static void RegEdit()
        {
            string MachineName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            RegistryKey key = Registry.LocalMachine;
            const string registryPath = "SOFTWARE\\Microsoft";
            //string Version = key.OpenSubKey(registryPath + "\\Internet Explorer").GetValue("svcVersion").ToString();
            RegistryKey software = key.OpenSubKey(registryPath + "\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

            object V = software.GetValue(MachineName);
            if (V == null)
            {
                RegistryKey keyAdmin = Registry.LocalMachine;
                var registryKey = keyAdmin.OpenSubKey(registryPath + "\\Internet Explorer");

                var ieVersionStr = registryKey.GetValue("svcVersion");
                if (ieVersionStr == null)
                    ieVersionStr = registryKey.GetValue("Version");
                Version ieVersion = Version.Parse((string)ieVersionStr);
                software.SetValue(MachineName, ieVersion.Major * 1000, RegistryValueKind.DWord);
            }

            //#不检查服务器证书吊销
            //[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings]
            //"CertificateRevocation"=dword:00000000
            RegistryKey internetSettingsKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            var state = internetSettingsKey.GetValue("CertificateRevocation");
            if ((int)state != 0 || state == null)
            {
                internetSettingsKey.SetValue("CertificateRevocation", 0, RegistryValueKind.DWord);
            }
        }

        static bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }


//# 不检查发行商的证书是否吊销
//        [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\WinTrust\Trust Providers\Software Publishing]
//"State"=dword:00023e00


    }
}
