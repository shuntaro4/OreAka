using System.Windows;

namespace OreAka.WPF.Presentation.Views
{
    public class WindowEx : Window
    {
        public WindowEx()
        {
            WindowStyle = WindowStyle.None;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AllowsTransparency = true;
        }
    }
}
