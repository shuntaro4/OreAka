using System;
using System.Threading.Tasks;
using Unity.Attributes;
using WhatsApp.WPF.Domain;
using WhatsApp.WPF.Infrastructure.Repositories;

namespace WhatsApp.WPF.ApplicationService
{
    public class WorkTaskService : IWorkTaskService
    {
        [Dependency]
        public IWorkTaskRepository WorkTaskRepository { get; set; }

        [Dependency]
        public ILogService LogService { get; set; }

        public async Task<bool> RegistWorkTaskAsync(string inputString)
        {
            try
            {
                await WorkTaskRepository.SaveAsync(new WorkTask(inputString));
            }
            catch (Exception ex)
            {
                LogService.Error(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
