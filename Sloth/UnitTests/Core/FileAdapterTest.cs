using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System;
using System.IO;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class FileAdapterTest
    {

        private const string FilePath = "fileAdapterTest.txt";

        private IFileAdapter m_Target;

        [TestInitialize]
        public void TestInitialize()
        { 
            File.WriteAllLines(FilePath, new string[] { "MyButton;Click", "Menu1;Click"});

            m_Target = new FileAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                File.Delete(FilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            m_Target = null;
        }

        [TestMethod()]
        public void GivenLineCannotBeAppend_WhenAppendToFile_ThenNoExceptionIsThrown()
        {
            m_Target.AppendToFile("Z:\\", "Test");
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadAllLines_TheAllLinesAreReturn()
        {
            string[] expected = File.ReadAllLines(FilePath);

            string[] actual = m_Target.ReadAllLines(FilePath);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

    }

}
