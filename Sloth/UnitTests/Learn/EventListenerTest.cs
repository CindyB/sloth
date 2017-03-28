using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Learn;
using System;
using System.Reflection;
using System.Threading;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class EventListenerTest
    {
        private IApplicationAdapter applicationAdapter;
        private HookProc callbackDelegate;
        private IControlAdapter controlAdapter;
        private ILogger logger;
        private IWinUtilities winUtilities;
        private IEventListener target;

        [TestInitialize]
        public void TestInitialize()
        {
            applicationAdapter = MockRepository.GenerateMock<IApplicationAdapter>();
            controlAdapter = MockRepository.GenerateMock<IControlAdapter>();
            logger = MockRepository.GenerateMock <ILogger>();
            winUtilities = MockRepository.GenerateMock<IWinUtilities>();

            target = new EventListener(applicationAdapter,controlAdapter,logger,winUtilities);

            callbackDelegate = (HookProc)target.GetType().GetField("callbackDelegate", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            applicationAdapter = null;
            controlAdapter = null;
            logger = null;
            winUtilities = null;
            
            target = null;
        }

        [TestMethod()]
        public void GivenWinUtilities_WhenStart_WindowsIsHook()
        {
            target.Start();
            
            winUtilities.AssertWasCalled(x => x.SetWindowsHookEx(7, callbackDelegate, IntPtr.Zero, Thread.CurrentThread.ManagedThreadId));
        }

        //[TestMethod()]
        //public void GivenMessageWithControlHandle_WhenPreFilterMessage_ThenControlIsGet()
        //{
        //    Message m = Message.Create(IntPtr.Zero, 513, IntPtr.Zero, IntPtr.Zero);

        //    m_Target.PreFilterMessage(ref m);

        //    m_ControlAdapter.AssertWasCalled(x => x.FromHandle(m.HWnd));
        //}

        //[TestMethod()]
        //public void GivenNoControlHandleFoundFromMessage_WhenPreFilterMessage_ThenLoggingIsAborted()
        //{
        //    Message m = Message.Create(IntPtr.Zero, 513, IntPtr.Zero, IntPtr.Zero);

        //    m_Target.PreFilterMessage(ref m);
        //}

        //[TestMethod()]
        //public void GivenMessageFromControl_WhenPreFilterMessage_ThenFormHandleOfControlIsGet()
        //{
        //    IntPtr formHandle = new IntPtr(666);
        //    Form f = MockRepository.GenerateMock<Form>();
        //    f.Expect(x => x.Handle).Return(formHandle);

        //    Button b = MockRepository.GenerateMock<Button>();
        //    b.Expect(x => x.FindForm()).Return(f);

        //    Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
        //    m_ControlAdapter.Expect(x => x.FromHandle(m.HWnd)).Return(b);

        //    m_Target.PreFilterMessage(ref m);

        //    b.AssertWasCalled(x => x.FindForm().Handle);
        //}

        //[TestMethod()]
        //public void GivenFormHandleAndControl_WhenPreFilterMessage_ThenHandledMessageIsLog()
        //{
        //    IntPtr formHandle = new IntPtr(666);
        //    Form f = MockRepository.GenerateMock<Form>();
        //    f.Expect(x => x.Handle).Return(formHandle);

        //    Button b = MockRepository.GenerateMock<Button>();
        //    b.Expect(x => x.FindForm()).Return(f);

        //    Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
        //    m_ControlAdapter.Expect(x => x.FromHandle(m.HWnd)).Return(b);
        //    string expectedMessage =  m_WinUtilities.GetWindowText(formHandle) + ";" + m_ControlAdapter.FromHandle(m.HWnd).Name + ";" + m.Msg;

        //    m_Target.PreFilterMessage(ref m);

        //    m_Logger.AssertWasCalled(x => x.Log(expectedMessage));
        //}

        //[TestMethod()]
        //public void GivenMessageFromControl_WhenPreFilterMessage_ThenMessageContinueToNextFilter()
        //{
        //    Button b = new Button();
        //    Message m = Message.Create(b.Handle, 513, IntPtr.Zero, IntPtr.Zero);
        //    bool expected = false;

        //    bool actual = m_Target.PreFilterMessage(ref m);

        //    Assert.AreEqual(expected, actual);
        //}
    }

}
