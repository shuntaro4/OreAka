using System;
using System.IO;
using WhatsApp.WPF.Domain;
using Xunit;

namespace WhatsApp.WPF.Test.Domain
{
    public class AppFolderTest
    {
        [Fact(DisplayName = "正：フォルダが存在しない場合、フォルダが作成される")]
        [Trait("AppFolder", "CreateOutputFolder")]
        public void CreateOutputFolderTrue1()
        {
            var expected = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatsApp");
            if (Directory.Exists(expected))
            {
                Directory.Delete(expected, true);
            }
            Assert.False(Directory.Exists(expected));

            var actual = AppFolder.CreateOutputFolder();
            Assert.Equal(expected, actual);
            Assert.True(Directory.Exists(actual));
        }

        [Fact(DisplayName = "正：フォルダが存在する場合、何もしない")]
        [Trait("AppFolder", "CreateOutputFolder")]
        public void CreateOutputFolderTrue2()
        {
            var expected = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WhatsApp");
            if (!Directory.Exists(expected))
            {
                Directory.CreateDirectory(expected);
            }
            Assert.True(Directory.Exists(expected));

            var actual = AppFolder.CreateOutputFolder();
            Assert.Equal(expected, actual);
            Assert.True(Directory.Exists(actual));
        }
    }
}
