using Sloth.Core;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using System;
using System.IO;

namespace Sloth.Learn
{
    public class Logger : ILogger
    {
        private IFileAdapter m_FileAdapter;
        private string m_FilePath;

        public Logger()
        {
            m_FileAdapter = new FileAdapter();
            m_FilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth";
            if (!Directory.Exists(Path.GetDirectoryName(m_FilePath))) Directory.CreateDirectory(Path.GetDirectoryName(m_FilePath));
        }

        public void Log(string line)
        { 
            if (line == null) throw new ArgumentNullException("line");
            m_FileAdapter.AppendToFile(m_FilePath, line);
        }
    }

}
