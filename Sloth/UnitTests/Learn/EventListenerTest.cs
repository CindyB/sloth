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
        private IControlAdapter m_ControlAdapter;
        private ILogger m_Logger;
        private IWinUtilities m_WinUtilities;
        private IEventListener m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            m_ApplicationAdapter = MockRepository.GenerateMock<IApplicationAdapter>();
            m_ControlAdapter = MockRepository.GenerateMock<IControlAdapter>();
            m_Logger = MockRepository.GenerateMock <ILogger>();
            m_WinUtilities = MockRepository.GenerateMock<IWinUtilities>();

            m_Target = new EventListener(m_ApplicationAdapter,m_ControlAdapter,m_Logger,m_WinUtilities);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_ApplicationAdapter = null;
            m_ControlAdapter = null;
            m_Logger = null;
            m_WinUtilities = null;
            
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
        public void GivenMessageWithControlHandle_WhenPreFilterMessage_ThenControlIsGet()
        {
            Message m = Message.Create(IntPtr.Zero, 513, IntPtr.Zero, IntPtr.Zero);

            m_Target.PreFilterMessage(ref m);

            m_ControlAdapter.AssertWasCalled(x => x.FromHandle(m.HWnd));
        }

        [TestMethod()]
        public void GivenNoControlHandleFoundFromMessage_WhenPreFilterMessage_ThenLoggingIsAborted()
        {
            Message m = Message.Create(IntPtr.Zero, 513, IntPtr.Zero, IntPtr.Zero);

            m_Target.PreFilterMessage(ref m);
        }

        [TestMethod()]
        public void GivenMessageFromControl_WhenPreFilterMessage_ThenFormHandleOfControlIsGet()
        {
            IntPtr formHandle = new IntPtr(666);
            Form f = MockRepository.GenerateMock<Form>();
            f.Expect(x => x.Handle).Return(formHandle);

            Button b = MockRepository.GenerateMock<Button>();
            b.Expect(x => x.FindForm()).Return(f);

            Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
            m_ControlAdapter.Expect(x => x.FromHandle(m.HWnd)).Return(b);

            m_Target.PreFilterMessage(ref m);

            b.AssertWasCalled(x => x.FindForm().Handle);
        }

        [TestMethod()]
        public void GivenFormHandleAndControl_WhenPreFilterMessage_ThenHandledMessageIsLog()
        {
            IntPtr formHandle = new IntPtr(666);
            Form f = MockRepository.GenerateMock<Form>();
            f.Expect(x => x.Handle).Return(formHandle);

            Button b = MockRepository.GenerateMock<Button>();
            b.Expect(x => x.FindForm()).Return(f);

            Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
            m_ControlAdapter.Expect(x => x.FromHandle(m.HWnd)).Return(b);
            string expectedMessage =  m_WinUtilities.GetWindowText(formHandle) + ";" + m_ControlAdapter.FromHandle(m.HWnd).Name + ";" + m.Msg;

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
