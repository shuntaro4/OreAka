using OreAka.WPF.Infrastructure.Repositories;
using System.IO;
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
    }
}
