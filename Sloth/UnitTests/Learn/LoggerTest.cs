using System.IO
using System.Reflection
using System.Text
using Microsoft.VisualStudio.TestTools.UnitTesting
using Rhino.Mocks
using Sloth.Sloth
using Sloth.Sloth.Interfaces

namespace Sloth.UnitTests.Log

    <TestClass()>
    public class LoggerTest

        private m_FileAdapter As IFileAdapter

        private m_Target As ILogger

        <TestInitialize>
        public void TestInitialize()
            m_FileAdapter = MockRepository.GenerateMock(Of IFileAdapter)

            m_Target = new Logger()
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_FileAdapter)
        }

        <TestCleanup>
        public void TestCleanup()
            m_FileAdapter = Nothing

            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target = Nothing
        }

        <TestMethod(), ExpectedException(GetType(ArgumentNullException))>
        public void GivenLineIsNothing_WhenLog_ThenArgumentNullExceptionIsThrown()
            m_Target.Log(Nothing)
        }

        <TestMethod()>
        public void GivenFilePathAndLineToAppend_WhenLog_ThenLineIsAppendToLogFile()
            Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth"
            Dim line As String = "This is a test"

            m_Target.Log(line)

            m_FileAdapter.AssertWasCalled(void(x) x.AppendToFile(filePath, line))
        }

    }

}
