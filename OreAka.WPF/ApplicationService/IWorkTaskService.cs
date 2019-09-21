using System.Threading.Tasks;

namespace OreAka.WPF.ApplicationService
{
    public interface IWorkTaskService
    {
        Task<bool> RegistWorkTaskAsync(string inputString);
    }
}
