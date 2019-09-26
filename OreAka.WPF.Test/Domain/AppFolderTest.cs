using OreAka.WPF.Domain;
using System;
using System.IO;
using Xunit;

namespace OreAka.WPF.Test.Domain
{
    public class AppFolderTest : IDisposable
    {
        private AppFolder target = new AppFolder("../AppFolder");

        public void Dispose()
        {
            if (Directory.Exists(target.OutputFolder))
            {
                Directory.Delete(target.OutputFolder);
            }
        }

        [Fact(DisplayName = "正：フォルダが存在しない場合、フォルダが作成される")]
        [Trait("AppFolder", "CreateOutputFolder")]
        public void CreateOutputFolderTrue1()
        {
            var outputFolder = target.OutputFolder;

            Assert.False(Directory.Exists(outputFolder));
            target.CreateOutputFolder();
            Assert.True(Directory.Exists(outputFolder));
        }

        [Fact(DisplayName = "正：フォルダが存在する場合、何もしない")]
        [Trait("AppFolder", "CreateOutputFolder")]
        public void CreateOutputFolderTrue2()
        {
            var outputFolder = target.OutputFolder;

            Assert.False(Directory.Exists(outputFolder));
            target.CreateOutputFolder();

            Assert.True(Directory.Exists(outputFolder));
            target.CreateOutputFolder();
            Assert.True(Directory.Exists(outputFolder));
        }
    }
}
