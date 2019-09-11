using System.Threading.Tasks;

namespace WhatsApp.WPF.ApplicationService
{
    public interface IWorkTaskService
    {
        Task<bool> RegistWorkTask(string inputString);
    }
}
