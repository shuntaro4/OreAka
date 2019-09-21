using System.IO;
using System.Threading.Tasks;
using OreAka.WPF.Domain;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public class WorkTaskRepository : IWorkTaskRepository
    {
        public async Task SaveAsync(WorkTask workTask)
        {
            var outputFolderPath = AppFolder.CreateOutputFolder();

            var record = $"{workTask.CreratedAt.ToString("yyyy-MM-dd HH:mm:ss")}, {workTask.Id}, {workTask.Title}, {workTask.Minutes}\r\n";
            var outputFile = Path.Combine(outputFolderPath, "workTask.txt");

            await File.AppendAllTextAsync(outputFile, record);
        }
    }
}
