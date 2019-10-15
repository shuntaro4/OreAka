using OreAka.WPF.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public interface IWorkTaskRepository
    {
        Task SaveAsync(WorkTask workTask);

        Task<IEnumerable<string>> GetHistoriesAsync();
    }
}
