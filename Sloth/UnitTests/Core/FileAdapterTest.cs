using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System;
using System.IO;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class FileAdapterTest
    {

        private const string STR_FilePath = "fileAdapterTest.txt";

        private IFileAdapter m_Target;

        [TestInitialize]
        public void TestInitialize()
        { 
            File.WriteAllLines(STR_FilePath, new string[] { "MyButton;Click", "Menu1;Click"});

            m_Target = new FileAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                File.Delete(STR_FilePath);
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
            string[] expected = File.ReadAllLines(STR_FilePath);

            string[] actual = m_Target.ReadAllLines(STR_FilePath);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

    }

}
