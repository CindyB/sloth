using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Repeat;
using System;
using System.Reflection;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventRaiserTest
    {
        private IWinUtilities m_WinUtilities;
        private IEventRaiser m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
           m_WinUtilities = MockRepository.GenerateMock<IWinUtilities>();

            m_Target = new EventRaiser();
            m_Target.GetType().GetField("m_WinUtilities", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_WinUtilities);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_WinUtilities = null;

            m_Target.GetType().GetField("m_WinUtilities", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod()]
        public void GivenSlothEventWithClassNameAndWindowsName_WhenRaiseSlothEvent_ThenWindowsHandleIsFound()
        {
            string className = null;
            string windowsName = "MyWindows";
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.Expect(x => x.WindowsName).Return(windowsName);

            m_Target.RaiseSlothEvent(slothEvent);

            m_WinUtilities.AssertWasCalled(x => x.FindWindowsHandle(className,windowsName));
        }

        [TestMethod()]
        public void GivenWindowsHandleAndSlothEventWithControlName_WhenRaiseSlothEvent_ThenControlHandleIsFound()
        {
            string controlName = "MyControl";
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.Expect(x => x.ControlName).Return(controlName);
            IntPtr windowsHandle = new IntPtr(666);
            m_WinUtilities.Expect(x => x.FindWindowsHandle(null,slothEvent.WindowsName)).Return(windowsHandle);

            m_Target.RaiseSlothEvent(slothEvent);

            m_WinUtilities.AssertWasCalled(x => x.FindControlHandle(windowsHandle, controlName));
        }

        [TestMethod()]
        public void GivenWindowsHandleAndControlHandleAndSlothEvent_WhenRaiseSlothEvent_ThenSlothEventIsRaiseByMessage()
        {
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            IntPtr windowsHandle = new IntPtr(666);
            m_WinUtilities.Expect(x => x.FindWindowsHandle(null, slothEvent.WindowsName)).Return(windowsHandle);
            IntPtr controlHandle = new IntPtr(777);
            m_WinUtilities.Expect(x => x.FindControlHandle(windowsHandle, slothEvent.ControlName)).Return(controlHandle);

            m_Target.RaiseSlothEvent(slothEvent);

            m_WinUtilities.AssertWasCalled(x => x.SendMessage(windowsHandle, controlHandle,slothEvent));
        }

    }

}
