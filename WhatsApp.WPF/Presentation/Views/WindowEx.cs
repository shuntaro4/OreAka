using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WhatsApp.WPF.Presentation.Views
{
    public class WindowEx : MetroWindow
    {
        public WindowEx()
        {
            WindowTransitionsEnabled = false;
            TitleCharacterCasing = CharacterCasing.Normal;
            GlowBrush = new SolidColorBrush(Colors.Black);
            BorderThickness = new Thickness(0);
        }
    }
}
