using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rhino.Mocks;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using Sloth.Learn;
using System;
using System.IO;

using System.Reflection;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class LoggerTest
    {
        private IFileAdapter m_FileAdapter;

        private ILogger m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
            m_FileAdapter = MockRepository.GenerateMock<IFileAdapter>();

            m_Target = new Logger();
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_FileAdapter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_FileAdapter = null;

            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenLineIsNothing_WhenLog_ThenArgumentNullExceptionIsThrown()
        {
            m_Target.Log(null);
        }

        [TestMethod()]
        public void GivenFilePathAndLineToAppend_WhenLog_ThenLineIsAppendToLogFile()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth";
            string line = "This is a test";

            m_Target.Log(line);

            m_FileAdapter.AssertWasCalled(x => x.AppendToFile(filePath, line));
        }

    }

}
