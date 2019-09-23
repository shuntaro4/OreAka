using OreAka.WPF.Domain;
using OreAka.WPF.Infrastructure.Repositories;
using System.Windows.Input;
using Unity.Attributes;

namespace OreAka.WPF.ApplicationService
{
    public class PreferencesService : IPreferencesService
    {
        [Dependency]
        public IPreferencesRepository PreferencesRepository { get; set; }

        [Dependency]
        public ILogService LogService { get; set; }

        public Preferences GetPreferences()
        {
            if (!PreferencesRepository.Exists())
            {
                PreferencesRepository.New();
            }

            var preferences = PreferencesRepository.All();
            return preferences;
        }

        public Preferences GetDefaultPreferences()
        {
            return Preferences.GenerateDefault();
        }

        public void SavePreferences(
            string delimiter,
            ModifierKeys showHideModifierKeys, Key showHideKey)
        {
            var showHideGlobalShortcut = new GlobalShortcut(showHideModifierKeys, showHideKey);
            var preferences = new Preferences(delimiter, showHideGlobalShortcut);
            PreferencesRepository.Save(preferences);
        }
    }
}
