﻿using System.Threading.Tasks;

namespace WhatsApp.WPF.ApplicationService
{
    public class WorkTaskService : IWorkTaskService
    {
        public WorkTaskService()
        {
        }

        public async Task<bool> RegistWorkTask(string inputString)
        {
            return true;
        }
    }
}
