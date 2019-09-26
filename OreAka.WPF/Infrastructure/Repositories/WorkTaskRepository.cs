using OreAka.WPF.Domain;
using System.IO;
using System.Threading.Tasks;
using Unity.Attributes;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public class WorkTaskRepository : IWorkTaskRepository
    {
        [Dependency]
        public AppFolder AppFolder { get; set; }

        public async Task SaveAsync(WorkTask workTask)
        {
            AppFolder.CreateOutputFolder();

            var record = $"{workTask.CreratedAt.ToString("yyyy-MM-dd HH:mm:ss")}, {workTask.Id}, {workTask.Title}, {workTask.Minutes}\r\n";
            var outputFile = Path.Combine(AppFolder.OutputFolder, "workTask.txt");

            await File.AppendAllTextAsync(outputFile, record);
        }
    }
}
