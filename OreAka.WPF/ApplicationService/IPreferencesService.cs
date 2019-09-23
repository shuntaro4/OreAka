using OreAka.WPF.Domain;

namespace OreAka.WPF.ApplicationService
{
    public interface IPreferencesService
    {
        Preferences GetPreferences();

        Preferences GetDefaultPreferences();
    }
}
