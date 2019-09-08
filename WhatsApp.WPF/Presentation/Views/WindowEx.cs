using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace WhatsApp.WPF.Presentation.Views
{
    public class WindowEx : MetroWindow
    {
        public WindowEx()
        {
            SaveWindowPosition = true;
            WindowTransitionsEnabled = false;
            TitleCharacterCasing = CharacterCasing.Normal;
        }
    }
}
