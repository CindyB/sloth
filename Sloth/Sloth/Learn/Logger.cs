using Sloth.Core;
using System;
using System.IO;

namespace Sloth.Learn
{
    public class Logger : ILogger
    {
        private IFileAdapter fileAdapter;
        private string filePath;

        public Logger()
        {
            fileAdapter = new FileAdapter();
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth";
            if (!Directory.Exists(Path.GetDirectoryName(filePath))) Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        public void Log(string line)
        { 
            if (line == null) throw new ArgumentNullException("line");
            fileAdapter.AppendToFile(filePath, line);
        }
    }

}
