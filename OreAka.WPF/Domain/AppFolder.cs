using System;
using System.IO;

namespace OreAka.WPF.Domain
{
    public class AppFolder
    {
        public static string CreateOutputFolder()
        {
            var outputFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "OreAka");

            if (Directory.Exists(outputFolderPath))
            {
                return outputFolderPath;
            }

            var result = Directory.CreateDirectory(outputFolderPath);
            return result.FullName;
        }
    }
}
