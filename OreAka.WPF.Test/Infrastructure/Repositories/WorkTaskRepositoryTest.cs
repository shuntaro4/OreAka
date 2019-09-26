using OreAka.WPF.Domain;
using OreAka.WPF.Infrastructure.Repositories;
using System;
using System.IO;
using Xunit;

namespace OreAka.WPF.Test.Infrastructure.Repositories
{
    public class WorkTaskRepositoryTest : IDisposable
    {
        private AppFolder appFolder = new AppFolder("../WorkTaskRepositoryTest");

        private WorkTaskRepository target = new WorkTaskRepository();

        public WorkTaskRepositoryTest()
        {
            appFolder.CreateOutputFolder();
            target.AppFolder = appFolder;
        }

        public void Dispose()
        {
            if (Directory.Exists(appFolder.OutputFolder))
            {
                Directory.Delete(appFolder.OutputFolder, true);
            }
        }

        [Fact(DisplayName = "正：ファイルが存在しない場合、ファイルが作成される")]
        [Trait("WorkTaskRepository", "SaveAsync")]
        public async void SaveAsyncTrue1()
        {
            var outputFile = Path.Combine(appFolder.OutputFolder, "workTask.txt");

            Assert.False(File.Exists(outputFile));

            var workTask = new WorkTask("c#,80");
            await target.SaveAsync(workTask);

            Assert.True(File.Exists(outputFile));

            using (var fileStream = new StreamReader(outputFile))
            {
                var expected = $"{workTask.CreratedAt.ToString("yyyy-MM-dd HH:mm:ss")}, {workTask.Id}, {workTask.Title}, {workTask.Minutes}\r\n";
                var actual = fileStream.ReadToEnd();
                Assert.Equal(expected, actual);
            }
        }

        [Fact(DisplayName = "正：ファイルが存在する場合、ファイルに追記される")]
        [Trait("WorkTaskRepository", "SaveAsync")]
        public async void SaveAsyncTrue2()
        {
            var outputFile = Path.Combine(appFolder.OutputFolder, "workTask.txt");

            Assert.False(File.Exists(outputFile));

            var workTask1 = new WorkTask("c#,80");
            await target.SaveAsync(workTask1);

            var workTask2 = new WorkTask("c#,90");
            await target.SaveAsync(workTask2);

            Assert.True(File.Exists(outputFile));

            using (var fileStream = new StreamReader(outputFile))
            {
                var expected = $"{workTask1.CreratedAt.ToString("yyyy-MM-dd HH:mm:ss")}, {workTask1.Id}, {workTask1.Title}, {workTask1.Minutes}\r\n"
                             + $"{workTask2.CreratedAt.ToString("yyyy-MM-dd HH:mm:ss")}, {workTask2.Id}, {workTask2.Title}, {workTask2.Minutes}\r\n";
                var actual = fileStream.ReadToEnd();
                Assert.Equal(expected, actual);
            }
        }
    }
}
