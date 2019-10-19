using OreAka.WPF.Domain;
using OreAka.WPF.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Attributes;

namespace OreAka.WPF.ApplicationService
{
    public class WorkTaskService : IWorkTaskService
    {
        [Dependency]
        public IWorkTaskRepository WorkTaskRepository { get; set; }

        [Dependency]
        public ILogService LogService { get; set; }

        public async Task<WorkTask> RegistWorkTaskAsync(string inputString)
        {
            try
            {
                var workTask = new WorkTask(inputString);
                await WorkTaskRepository.SaveAsync(workTask);
                return workTask;
            }
            catch (Exception ex)
            {
                LogService.Error(ex.ToString());
                throw ex;
            }
        }

        public async Task<IEnumerable<string>> GetWorkTaskHistoriesAsync()
        {
            try
            {
                return await WorkTaskRepository.GetHistoriesAsync();
            }
            catch (Exception ex)
            {
                LogService.Error(ex.ToString());
                return new List<string>();
            }
        }
    }
}
