using System;

namespace OreAka.WPF.Domain
{
    public class WorkTask
    {
        public Guid Id { get; }

        public string Title { get; }

        public int Minutes { get; }

        public DateTime CreratedAt { get; } = DateTime.Now;

        public WorkTask(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                throw new ArgumentException("Answer value is null or empty.");
            }

            var chunk = answer.Split(",");

            for (var i = 0; i < chunk.Length; i++)
            {
                var value = chunk[i].Trim();
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
