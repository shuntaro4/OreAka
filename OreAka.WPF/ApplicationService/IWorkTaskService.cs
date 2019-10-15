using OreAka.WPF.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OreAka.WPF.ApplicationService
{
    public interface IWorkTaskService
    {
        Task<WorkTask> RegistWorkTaskAsync(string inputString);

        Task<IEnumerable<string>> GetWorkTaskHistoriesAsync();
    }
}
