using System.IO;

namespace OreAka.WPF.Domain
{
    public class AppFolder
    {
        private readonly string outputBaseFolder;

        public AppFolder(string outputBaseFolder)
        {
            this.outputBaseFolder = outputBaseFolder;
        }

        public string CreateOutputFolder()
        {
            var outputFolderPath = Path.Combine(outputBaseFolder, "OreAka");

            if (Directory.Exists(outputFolderPath))
            {
                return outputFolderPath;
            }

            var result = Directory.CreateDirectory(outputFolderPath);
            return result.FullName;
        }
    }
}
