using System;

namespace WhatsApp.WPF.Domain
{
    public class WorkTask
    {
        public string Title { get; }

        public int Minutes { get; }

        public DateTime CreratedAt { get; } = DateTime.Now;

        public WorkTask(string answer)
        {
            // todo parse string
        }
    }
}
