using OreAka.WPF.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        public async Task<IEnumerable<string>> GetHistoriesAsync()
        {
            var inputFile = Path.Combine(AppFolder.OutputFolder, "workTask.txt");
            var list = (await File.ReadAllLinesAsync(inputFile)).Reverse();
            return list.Select(x =>
            {
                var regex = new Regex("^.*,.*, (?<title>.*),.*$");
                var match = regex.Match(x);
                if (match.Success)
                {
                    return match.Groups["title"].Value.ToLower();
                }
                return null;
            }).Distinct();
        }
    }
}
