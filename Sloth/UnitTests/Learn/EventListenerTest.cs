using System.Reflection
using System.Windows.Forms
using Rhino.Mocks
using Sloth.Sloth.Interfaces
using Sloth.Sloth.Log

namespace Sloth.UnitTests.Log

    <TestClass()>
    public class EventListenerTest

        private m_ApplicationAdapter As IApplicationAdapter
        private m_Logger As ILogger
        private m_Target As IEventListener

        <TestInitialize>
        public void TestInitialize()
            m_ApplicationAdapter = MockRepository.GenerateMock(Of IApplicationAdapter)()
            m_Logger = MockRepository.GenerateMock(Of ILogger)()

            m_Target = new EventListener()
            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_ApplicationAdapter)
            m_Target.GetType().GetField("m_Logger", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_Logger)
        }

        <TestCleanup>
        public void TestCleanup()
            m_ApplicationAdapter = Nothing
            m_Logger = Nothing


            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target.GetType().GetField("m_Logger", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target = Nothing
        }

        <TestMethod()>
        public void GivenApplicationAdapter_WhenStart_ThenListenerIsAddedAsMessageFilter()
            Dim adapter As IApplicationAdapter = m_ApplicationAdapter

            m_Target.Start()

            adapter.AssertWasCalled(void(x) x.AddEventListenerAsMessageFilter(m_Target))
        }

        <TestMethod()>
        public void GivenMessageFromControl_WhenPreFilterMessage_ThenListenerIsAddedAsMessageFilter()
            Dim b As Button = new Button()
            Dim m As Message = Message.Create(b.Handle, 513, Nothing, Nothing)
            Dim expectedMessage As String = Control.FromHandle(m.HWnd).Name & ";" & m.ToString


            m_Target.PreFilterMessage(m)

            m_Logger.AssertWasCalled(void(x) x.Log(expectedMessage))
        }

        <TestMethod()>
        public void GivenMessageFromControl_WhenPreFilterMessage_ThenMessageContinueToNextFilter()
            Dim b As Button = new Button()
            Dim m As Message = Message.Create(b.Handle, 513, Nothing, Nothing)
            Dim expected As Boolean = False

            Dim actual As Boolean = m_Target.PreFilterMessage(m)

            Assert.AreEqual(expected, actual)
        }

    }

}
