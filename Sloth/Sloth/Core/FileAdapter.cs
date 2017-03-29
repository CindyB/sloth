using Sloth.Core;
using System;
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
            catch (IOException e)
            {
                // Do nothing because we don't want to compromise application for logging
                Console.WriteLine(e.ToString());
            }
            catch (UnauthorizedAccessException e)
            {
                // Do nothing because we don't want to compromise application for logging
                Console.WriteLine(e.ToString());
            }
        }

        public string[] ReadAllLines(string filePath)
        { 
            return File.ReadAllLines(filePath);
        }
    }

}
