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

        private IFileAdapter target;

        [TestInitialize]
        public void TestInitialize()
        { 
            File.WriteAllLines(FilePath, new string[] { "MyButton;Click", "Menu1;Click"});

            target = new FileAdapter();
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

            target = null;
        }

        [TestMethod()]
        public void GivenLineCannotBeAppend_WhenAppendToFile_ThenNoExceptionIsThrown()
        {
            target.AppendToFile("Z:\\", "Test");
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadAllLines_TheAllLinesAreReturn()
        {
            string[] expected = File.ReadAllLines(FilePath);

            string[] actual = target.ReadAllLines(FilePath);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

    }

}
