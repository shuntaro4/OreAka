using OreAka.WPF.Domain;
using Xunit;

namespace OreAka.WPF.Test.Domain
{
    public class AppThemeTest
    {
        [Fact(DisplayName = "正：Theme=Dark.Steelの場合、True")]
        [Trait("AppTheme", "IsDarkTheme")]
        public void IsDarkThemeTrue1()
        {
            var target = AppTheme.GenerateDarkTheme();
            var actual = target.IsDarkTheme;
            Assert.True(actual);
        }

        [Fact(DisplayName = "正：Theme=Light.Steelの場合、False")]
        [Trait("AppTheme", "IsDarkTheme")]
        public void IsDarkThemeTrue2()
        {
            var target = AppTheme.GenerateLightTheme();
            var actual = target.IsDarkTheme;
            Assert.False(actual);
        }

        [Fact(DisplayName = "正：Theme=hogeの場合、False")]
        [Trait("AppTheme", "IsDarkTheme")]
        public void IsDarkThemeFalse1()
        {
            var target = AppTheme.GenerateNew("hoge");
            var actual = target.IsDarkTheme;
            Assert.False(actual);
        }
    }
}
