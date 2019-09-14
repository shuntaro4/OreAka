using System;
using System.Diagnostics;
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

        public async Task<bool> RegistWorkTaskAsync(string inputString)
        {
            try
            {
                await WorkTaskRepository.SaveAsync(new WorkTask(inputString));
            }
            catch (Exception ex)
            {
                // todo log 出力
                Trace.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
