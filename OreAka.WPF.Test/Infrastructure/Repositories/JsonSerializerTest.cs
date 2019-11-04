using OreAka.WPF.Domain;
using Xunit;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public class JsonSerializerTest
    {
        private JsonSerializer target = new JsonSerializer();

        [Fact(DisplayName = "正：Json文字列に正しくシリアライズできる")]
        [Trait("JsonSerializer", "Serialize")]
        public void SerializeTrue1()
        {
            var model = Preferences.GenerateDefault();
            var actual = target.Serialize(model);
            Assert.Equal(@"{""AutoLaunch"":false,""Delimiter"":"","",""ShowHideShortcut"":{""Key"":18,""ModifierKeys"":6},""ThemeName"":""Dark.Steel"",""Version"":1}", actual);
        }

        [Fact(DisplayName = "正：objectに正しくデシリアライズできる")]
        [Trait("JsonSerializer", "Desirialize")]
        public void DesirializeTrue1()
        {
            var expected = Preferences.GenerateDefault();
            var json = @"{""AutoLaunch"":false,""Delimiter"":"","",""ShowHideShortcut"":{""Key"":18,""ModifierKeys"":6},""ThemeName"":""Dark.Steel"",""Version"":1}";
            var actual = target.Desirialize<Preferences>(json);
            Assert.Equal(expected.Version, actual.Version);
            Assert.Equal(expected.Delimiter, actual.Delimiter);
            Assert.Equal(expected.ShowHideShortcut.ModifierKeys, actual.ShowHideShortcut.ModifierKeys);
            Assert.Equal(expected.ShowHideShortcut.Key, actual.ShowHideShortcut.Key);
            Assert.Equal(expected.ThemeName, actual.ThemeName);
            Assert.Equal(expected.AutoLaunch, actual.AutoLaunch);
        }
    }
}
