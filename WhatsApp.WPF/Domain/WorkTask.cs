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
            var chunk = answer.Split(" ");

            for (var i = 0; i < chunk.Length; i++)
            {
                var value = chunk[i];
                if (i == 0)
                {
                    Title = value;
                    continue;
                }
                if (i == 1)
                {
                    Minutes = TypeParser.ToInt(value);
                    continue;
                }
            }
        }
    }
}
