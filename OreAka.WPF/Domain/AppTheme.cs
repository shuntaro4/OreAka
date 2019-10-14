namespace OreAka.WPF.Domain
{
    public class AppTheme
    {
        private static readonly string darkThemeName = "Dark.Steel";

        private static readonly string lightThemeName = "Light.Steel";

        public string ThemeName { get; private set; }

        public bool IsDarkTheme => ThemeName == darkThemeName;

        public bool IsLightTheme => ThemeName == lightThemeName;

        private AppTheme(string themeName)
        {
            ThemeName = themeName;
        }

        public static AppTheme GenerateDefault()
        {
            return new AppTheme(darkThemeName);
        }

        public static AppTheme GenerateNew(string themeName)
        {
            return new AppTheme(themeName);
        }

        public static AppTheme GenerateDarkTheme()
        {
            return new AppTheme(darkThemeName);
        }

        public static AppTheme GenerateLightTheme()
        {
            return new AppTheme(lightThemeName);
        }
    }
}
