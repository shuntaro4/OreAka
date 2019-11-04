using Moq;
using OreAka.WPF.Domain;
using OreAka.WPF.Infrastructure.Repositories;
using OreAka.WPF.Infrastructure.RunRegister;
using System.IO;
using System.Windows.Input;
using Xunit;

namespace OreAka.WPF.Test.Infrastructure.Repositories
{
    public class PreferencesRepositoryTest
    {
        private JsonSerializer jsonSerializer = new JsonSerializer();

        [Fact(DisplayName = "正：jsonファイルが存在する場合 true")]
        [Trait("PreferencesRepository", "Exists")]
        public void ExistsTrue1()
        {
            var path = "ExistsTrue1.json";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var target = new PreferencesRepository(path)
            {
                JsonSerializer = jsonSerializer
            };
            var actual = target.Exists();
            Assert.True(actual);
        }

        [Fact(DisplayName = "正：jsonファイルが存在しない場合 false")]
        [Trait("PreferencesRepository", "Exists")]
        public void ExistsTrue2()
        {
            var path = "ExistsTrue2.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var target = new PreferencesRepository(path)
            {
                JsonSerializer = jsonSerializer
            };
            var actual = target.Exists();
            Assert.False(actual);
        }

        [Fact(DisplayName = "正：新規で設定ファイルが生成される")]
        [Trait("PreferencesRepository", "New")]
        public void NewTrue1()
        {
            var path = "NewTrue1.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var target = new PreferencesRepository(path)
            {
                JsonSerializer = jsonSerializer
            };

            target.New();

            Assert.True(File.Exists(path));

            var actual = target.All();
            Assert.Equal(1, actual.Version);
            Assert.Equal(",", actual.Delimiter);
            Assert.NotStrictEqual(new GlobalShortcut(ModifierKeys.Control | ModifierKeys.Shift, Key.Space), actual.ShowHideShortcut);
        }

        [Fact(DisplayName = "正：設定ファイルが保存される")]
        [Trait("PreferencesRepository", "Save")]
        public void SaveTrue1()
        {

            var path = "SaveTrue1.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var runRegisterMoq = new Mock<IRunRegister>();
            runRegisterMoq.Setup(x => x.RegistKey(true));

            var target = new PreferencesRepository(path)
            {
                JsonSerializer = jsonSerializer,
                RunRegister = runRegisterMoq.Object
            };
            target.New();

            var preferences = new Preferences(":", new GlobalShortcut(ModifierKeys.Alt, Key.S), AppTheme.GenerateDarkTheme().ThemeName, true);
            target.Save(preferences);

            Assert.True(File.Exists(path));
            var actual = target.All();
            Assert.Equal(1, actual.Version);
            Assert.Equal(":", actual.Delimiter);
            Assert.NotStrictEqual(new GlobalShortcut(ModifierKeys.Alt, Key.S), actual.ShowHideShortcut);
            Assert.Equal("Dark.Steel", actual.ThemeName);
            Assert.True(actual.AutoLaunch);
        }
    }
}
