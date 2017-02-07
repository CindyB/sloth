using System.Text
using Microsoft.VisualStudio.TestTools.UnitTesting
using Sloth.Sloth.Interfaces
using Sloth.Sloth.Log
using Rhino.Mocks
using System.IO

namespace Sloth.UnitTests.Log

    <TestClass()>
    public class FileAdapterTest

        private Const STR_FilePath As String = "fileAdapterTest.txt"

        private m_Target As IFileAdapter

        <TestInitialize>
        public void TestInitialize()
            File.WriteAllLines(STR_FilePath, {"MyButton;Click", "Menu1;Click"})

            m_Target = new FileAdapter()
        }

        <TestCleanup>
        public void TestCleanup()
            Try
                File.Delete(STR_FilePath)
            Catch ex As Exception

            End Try

            m_Target = Nothing
        }

        <TestMethod()>
        public void GivenLineCannotBeAppend_WhenAppendToFile_ThenNoExceptionIsThrown()
            m_Target.AppendToFile("Z:\\", "Test")
        }

        <TestMethod()>
        public void GivenFilePath_WhenReadAllLines_TheAllLinesAreReturn()
            Dim expected As String() = File.ReadAllLines(STR_FilePath)

            Dim actual As String() = m_Target.ReadAllLines(STR_FilePath)

            Assert.AreEqual(expected.Count, actual.Count)
            For i As Integer = 0 To expected.Count - 1
                Assert.AreEqual(expected(i), actual(i))
            Next
        }

    }

}
