using System.IO;

namespace OreAka.WPF.Domain
{
    public class AppFolder
    {
        public string OutputFolder => Path.Combine(outputBaseFolder, "OreAka");

        private readonly string outputBaseFolder;

        public AppFolder(string outputBaseFolder)
        {
            this.outputBaseFolder = outputBaseFolder;
        }

        public void CreateOutputFolder()
        {
            if (Directory.Exists(OutputFolder))
            {
                return;
            }
            Directory.CreateDirectory(OutputFolder);
        }
    }
}
