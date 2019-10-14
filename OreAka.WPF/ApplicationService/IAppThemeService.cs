using OreAka.WPF.Domain;

namespace OreAka.WPF.ApplicationService
{
    public interface IAppThemeService
    {
        void LoadTheme();

        AppTheme SwitchTheme();
    }
}