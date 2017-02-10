using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

using Sloth.Interfaces;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Learn;
using Sloth.Learn;
using System;
using System.Reflection;

using System.Windows.Forms;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class EventListenerTest
    {
        private IApplicationAdapter m_ApplicationAdapter;
        private ILogger m_Logger;
        private IEventListener m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            m_ApplicationAdapter = MockRepository.GenerateMock<IApplicationAdapter>();
            m_Logger = MockRepository.GenerateMock <ILogger>();

            m_Target = new EventListener();
            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_ApplicationAdapter);
            m_Target.GetType().GetField("m_Logger", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_Logger);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_ApplicationAdapter = null;
            m_Logger = null;

            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target.GetType().GetField("m_Logger", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod()]
        public void GivenApplicationAdapter_WhenStart_ThenListenerIsAddedAsMessageFilter()
        { 
            IApplicationAdapter adapter = m_ApplicationAdapter;

            m_Target.Start();

            
            adapter.AssertWasCalled(x => x.AddEventListenerAsMessageFilter(m_Target));
        }

        [TestMethod()]
        public void GivenMessageFromControl_WhenPreFilterMessage_ThenListenerIsAddedAsMessageFilter()
        {
            Button b = new Button();
            Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
            string expectedMessage = Control.FromHandle(m.HWnd).Name + ";" + m.ToString();


            m_Target.PreFilterMessage(ref m);

            m_Logger.AssertWasCalled(x => x.Log(expectedMessage));
        }

        [TestMethod()]
        public void GivenMessageFromControl_WhenPreFilterMessage_ThenMessageContinueToNextFilter()
        {
            Button b = new Button();
            Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
            bool expected = false;

            bool actual = m_Target.PreFilterMessage(ref m);

            Assert.AreEqual(expected, actual);
        }

    }

}
