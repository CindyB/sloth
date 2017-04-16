using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rhino.Mocks;
using Sloth.Core;
using Sloth.Learn;
using System;
using System.IO;

using System.Reflection;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class LoggerTest
    {
        private IFileAdapter fileAdapter;
        private ILogger target; 

        [TestInitialize]
        public void TestInitialize()
        {
            fileAdapter = MockRepository.GenerateMock<IFileAdapter>();

            target = new Logger();
            target.GetType().GetField("fileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, fileAdapter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            fileAdapter = null;

            target.GetType().GetField("fileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenLineIsNothing_WhenLog_ThenArgumentNullExceptionIsThrown()
        {
            target.Log(null);
        }

        [TestMethod()]
        public void GivenFilePathAndLineToAppend_WhenLog_ThenLineIsAppendToLogFile()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth";
            string line = "This is a test";

            target.Log(line);

            fileAdapter.AssertWasCalled(x => x.AppendToFile(filePath, line));
        }

    }

}
