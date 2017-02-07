using System.IO
using System.Reflection
using Rhino.Mocks
using Sloth.Sloth.Automation
using Sloth.Sloth.Interfaces

namespace Sloth.UnitTests.Automation

    <TestClass()>
    public class AutomatonTest

        private m_EventRaiser As IEventRaiser
        private m_EventReader As IEventReader
        private m_Target As IAutomaton

        <TestInitialize>
        public void TestInitialize()
            m_EventRaiser = MockRepository.GenerateMock(Of IEventRaiser)()
            m_EventReader = MockRepository.GenerateMock(Of IEventReader)()

            m_Target = new Automaton()
            m_Target.GetType().GetField("m_EventRaiser", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_EventRaiser)
            m_Target.GetType().GetField("m_EventReader", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_EventReader)
        }

        <TestCleanup>
        public void TestCleanup()
            m_EventRaiser = Nothing
            m_EventReader = Nothing

            m_Target.GetType().GetField("m_EventRaiser", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target.GetType().GetField("m_EventReader", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target = Nothing
        }

        <TestMethod(), ExpectedException(GetType(ArgumentNullException))>
        public void GivenFilePathIsNothing_WhenRepeatBehavior_ThenArgumentNullExceptionIsThrown()
            m_Target.RepeatBehavior(Nothing)
        }

        <TestMethod(), ExpectedException(GetType(ArgumentException))>
        public void GivenFilePathIsEmpty_WhenRepeatBehavior_ThenArgumentExceptionIsThrown()
            m_Target.RepeatBehavior(String.Empty)
        }

        <TestMethod(), ExpectedException(GetType(FileNotFoundException))>
        public void GivenFilePathDoesntExists_WhenRepeatBehavior_ThenFileNotFoundExceptionIsThrown()
            m_Target.RepeatBehavior("Z:\\test.txt")
        }

        <TestMethod()>
        public void GivenFilePath_WhenRepeatBehavior_ThenEventsAreReadFromFile()
            Dim filePath As String = Me.GetType().Assembly.Location

            m_Target.RepeatBehavior(filePath)

            m_EventReader.AssertWasCalled(Function(x) x.ReadEvents(filePath))
        }

        <TestMethod()>
        public void GivenNoEventReadFromFile_WhenRepeatBehavior_ThenEventRaisingIsNotCalled()
            Dim filePath As String = Me.GetType().Assembly.Location

            m_Target.RepeatBehavior(filePath)

            m_EventRaiser.AssertWasNotCalled(void(x) x.RaiseSlothEvent(Arg(Of ISlothEvent).Is.Anything))
        }

        <TestMethod()>
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenEventIsRaised()
            Dim filePath As String = Me.GetType().Assembly.Location
            Dim eventSloth() As ISlothEvent = { MockRepository.GenerateMock(Of ISlothEvent) }
            m_EventReader.Expect(Function(x) x.ReadEvents(filePath)).Return(eventSloth)

            m_Target.RepeatBehavior(filePath)

            m_EventRaiser.AssertWasCalled(void(x) x.RaiseSlothEvent(eventSloth(0)))
        }

        <TestMethod()>
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenAllEventsAreRaised()
            Dim filePath As String = Me.GetType().Assembly.Location
            Dim eventSloth() As ISlothEvent = { MockRepository.GenerateMock(Of ISlothEvent), MockRepository.GenerateMock(Of ISlothEvent) }
            m_EventReader.Expect(Function(x) x.ReadEvents(filePath)).Return(eventSloth)

            m_Target.RepeatBehavior(filePath)

            m_EventRaiser.AssertWasCalled(void(x) x.RaiseSlothEvent(eventSloth(0)))
            m_EventRaiser.AssertWasCalled(void(x) x.RaiseSlothEvent(eventSloth(1)))
        }

    }

}
