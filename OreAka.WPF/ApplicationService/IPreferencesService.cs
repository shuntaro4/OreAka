using OreAka.WPF.Domain;
using System.Windows.Input;

namespace OreAka.WPF.ApplicationService
{
    public interface IPreferencesService
    {
        Preferences GetPreferences();

        Preferences GetDefaultPreferences();

        void SavePreferences(
            string delimiter,
            ModifierKeys showHideModifierKeys, Key showHideKey,
            string themeName,
            bool autoLaunch);

        void SaveTheme(string themeName);
    }
}
