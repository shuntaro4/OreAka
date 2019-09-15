using System;
using System.IO;

namespace WhatsApp.WPF.Domain
{
    public class AppFolder
    {
        public static string CreateOutputFolder()
        {
            var outputFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "WhatsApp");

            if (Directory.Exists(outputFolderPath))
            {
                return outputFolderPath;
            }

            var result = Directory.CreateDirectory(outputFolderPath);
            return result.FullName;
        }
    }
}
