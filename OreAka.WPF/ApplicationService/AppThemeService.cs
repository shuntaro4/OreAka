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
            var currentTheme = GetCurrentTheme();
            var currentThemeName = currentTheme.ThemeName ?? AppTheme.GenerateDefault().ThemeName;
            ThemeManager.ChangeTheme(Application.Current, currentThemeName);
        }

        public void ChangeTheme(string themeName)
        {
            ThemeManager.ChangeTheme(Application.Current, themeName);
        }

        public AppTheme SwitchTheme()
        {
            var currentTheme = GetCurrentTheme();

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

        public AppTheme GetCurrentTheme()
        {
            var currentThemeName = PreferencesService?.GetPreferences()?.ThemeName;
            return AppTheme.GenerateNew(currentThemeName ?? AppTheme.GenerateDefault().ThemeName);
        }
    }
}
