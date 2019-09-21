using System.Threading.Tasks;
using OreAka.WPF.Domain;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public interface IWorkTaskRepository
    {
        Task SaveAsync(WorkTask workTask);
    }
}
