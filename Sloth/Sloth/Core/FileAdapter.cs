using Sloth.Interfaces.Core;
using System.IO;

namespace Sloth.Core
{

    public class FileAdapter : IFileAdapter
    { 
        public void AppendToFile(string filePath,string line)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(line);
                }
            }
            catch
            {
                // Do nothing because we don't want to compromise application for logging
            }
        }

        public string[] ReadAllLines(string filePath)
        { 
            return File.ReadAllLines(filePath);
        }
    }

}
