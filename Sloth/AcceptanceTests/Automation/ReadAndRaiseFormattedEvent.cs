using System.IO
using System.Reflection
using Sloth.Sloth
using Sloth.Sloth.Automation
using Sloth.Sloth.Interfaces
using TestStack.BDDfy

namespace Sloth.AcceptanceTests.Automation

    <TestClass, Story(Title:="Read formatted user event and raise it",
                      AsA:="Developer",
           IWant:="To read a user event",
           SoThat:="Raise it")>
    public class ReadAndRaiseFormattedEvent

        private m_logFileName As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "TestUserEvent.sloth"
        private m_Logger As ILogger

        <TestInitialize>
        public void TestInitialize()
            m_Logger = new Logger()
            m_Logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Logger, m_logFileName)
        }

        <TestCleanup>
        public void TestCleanup()
            m_Logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Logger, Nothing)
            m_Logger = Nothing

            File.Delete(m_logFileName)
        }

        public void GivenUserEventLogFileWithUserEvent(eventLine As String)
            m_Logger.Log(eventLine)
        }

        public void WhenReadAndRaiseFirstEvent()
            Dim auto As IAutomaton = new Automaton()
            auto.RepeatBehavior(m_logFileName)
        }

        public void ThenFirstEventReadIsRaised()
            Throw new NotImplementedException()
        }

        <TestMethod>
        public void ReadEventRaised()
            Me.Given(void(x) x.GivenUserEventLogFileWithUserEvent("MyButton;Click"), "A user event log file with user event {0}") _
            .When(void(x) x.WhenReadAndRaiseFirstEvent(), "When read file and raise first event") _
                .Then(void(x) x.ThenFirstEventReadIsRaised(), "Then first user event read in file is raised") _
                .BDDfy()
        }

    }

}
