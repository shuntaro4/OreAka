using Microsoft.Win32;
using OreAka.WPF.ApplicationService;
using System;
using System.Diagnostics;
using Unity.Attributes;

namespace OreAka.WPF.Infrastructure.RunRegister
{
    public class RunRegister : IRunRegister
    {
        [Dependency]
        public ILogService LogService { get; set; }

        private static string subKey = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private static string valueKey = "OreAka";

        public RunRegister()
        {
        }

        public void RegistKey(bool autoLaunch)
        {
            try
            {
                var registry = Registry.CurrentUser.OpenSubKey(subKey, true);
                if (autoLaunch)
                {
                    registry.SetValue(valueKey, Process.GetCurrentProcess().MainModule.FileName);
                }
                else
                {
                    registry.DeleteValue("OreAka");
                }
            }
            catch (Exception ex)
            {
                LogService.Error(ex.ToString());
            }
        }

        public void Dispose()
        {
            RegistKey(false);
            GC.SuppressFinalize(this);
        }
    }
}
