using System.Windows;

namespace WhatsApp.WPF.Presentation.Views
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
