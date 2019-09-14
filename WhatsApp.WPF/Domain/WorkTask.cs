using System;

namespace WhatsApp.WPF.Domain
{
    public class WorkTask
    {
        public Guid Id { get; }

        public string Title { get; }

        public int Minutes { get; }

        public DateTime CreratedAt { get; } = DateTime.Now;

        public WorkTask(string answer)
        {
            // todo : split char is better comma than space.

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
                    Minutes = TypeParse.ToInt(value);
                    continue;
                }
            }

            Id = Guid.NewGuid();
        }
    }
}
