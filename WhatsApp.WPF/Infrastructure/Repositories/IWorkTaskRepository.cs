﻿using System.Threading.Tasks;
using WhatsApp.WPF.Domain;

namespace WhatsApp.WPF.Infrastructure.Repositories
{
    public interface IWorkTaskRepository
    {
        Task SaveAsync(WorkTask workTask);
    }
}
