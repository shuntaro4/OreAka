using MahApps.Metro.Controls;
using System.Windows;

namespace OreAka.WPF.Presentation.Views
{
    public class WindowEx : MetroWindow
    {
        public WindowEx()
        {
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AllowsTransparency = true;
            ResizeMode = ResizeMode.NoResize;
            TitleBarHeight = 0;
            WindowTransitionsEnabled = false;
        }
    }
}
