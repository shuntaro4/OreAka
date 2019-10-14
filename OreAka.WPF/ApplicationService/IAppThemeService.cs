using OreAka.WPF.Domain;

namespace OreAka.WPF.ApplicationService
{
    public interface IAppThemeService
    {
        void LoadTheme();

        void ChangeTheme(string themeName);

        AppTheme SwitchTheme();

        AppTheme GetCurrentTheme();
    }
}