using OreAka.WPF.Domain;
using Xunit;

namespace OreAka.WPF.Test.Domain
{
    public class GlobalShortcutTest
    {
        [Fact(DisplayName = "正：コンストラクタ")]
        [Trait("GrobalShortcut", "GrobalShortcut")]
        public void GlobalShortcutTrue1()
        {
            var actual = new GlobalShortcut(System.Windows.Input.ModifierKeys.Alt, System.Windows.Input.Key.A);

            Assert.NotNull(actual);
            Assert.Equal(System.Windows.Input.ModifierKeys.Alt, actual.ModifierKeys);
            Assert.Equal(System.Windows.Input.Key.A, actual.Key);
        }
    }
}
