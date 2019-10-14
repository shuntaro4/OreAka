using MahApps.Metro;
using OreAka.WPF.Domain;
using System.Windows;
using Unity.Attributes;

namespace OreAka.WPF.ApplicationService
{
    public class AppThemeService : IAppThemeService
    {
        [Dependency]
        public IPreferencesService PreferencesService { get; set; }

        public void LoadTheme()
        {
            var currentThemeName = PreferencesService?.GetPreferences()?.ThemeName;
            ThemeManager.ChangeTheme(Application.Current, currentThemeName);
        }

        public void ChangeTheme(string themeName)
        {
            ThemeManager.ChangeTheme(Application.Current, themeName);
        }

        public AppTheme SwitchTheme()
        {
            var currentThemeName = PreferencesService?.GetPreferences()?.ThemeName;
            var currentTheme = AppTheme.GenerateNew(currentThemeName);

            var theme = AppTheme.GenerateDefault();
            if (currentTheme.IsDarkTheme)
            {
                theme = AppTheme.GenerateLightTheme();
            }
            if (currentTheme.IsLightTheme)
            {
                theme = AppTheme.GenerateDarkTheme();
            }
            ThemeManager.ChangeTheme(Application.Current, theme.ThemeName);

            return theme;
        }
    }
}
