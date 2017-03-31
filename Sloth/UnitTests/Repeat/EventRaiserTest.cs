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
        private IWinUtilities winUtilities;
        private IEventRaiser target; 

        [TestInitialize]
        public void TestInitialize()
        {
           winUtilities = MockRepository.GenerateMock<IWinUtilities>();

            target = new EventRaiser();
            target.GetType().GetField("m_WinUtilities", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, winUtilities);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            winUtilities = null;

            target.GetType().GetField("m_WinUtilities", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target = null;
        }

        [TestMethod(),ExpectedException(typeof(ArgumentNullException))]
        public void GivenNoSlothEvent_WhenRaiseSlothEvent_ThenArgumentNullExceptionIsThrown()
        {
            target.PublishSlothEvent(null);
        }

        [TestMethod()]
        public void GivenSlothEventWithClassNameAndWindowsName_WhenRaiseSlothEvent_ThenWindowsHandleIsFound()
        {
            string className = null;
            string windowsName = "MyWindows";
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.Expect(x => x.WindowsName).Return(windowsName);

            target.PublishSlothEvent(slothEvent);

            winUtilities.AssertWasCalled(x => x.FindWindowsHandle(className,windowsName));
        }

        [TestMethod()]
        public void GivenWindowsHandleAndSlothEventWithControlName_WhenRaiseSlothEvent_ThenControlHandleIsFound()
        {
            string controlName = "MyControl";
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.Expect(x => x.ControlName).Return(controlName);
            IntPtr windowsHandle = new IntPtr(666);
            winUtilities.Expect(x => x.FindWindowsHandle(null,slothEvent.WindowsName)).Return(windowsHandle);

            target.PublishSlothEvent(slothEvent);

            winUtilities.AssertWasCalled(x => x.FindControlHandle(windowsHandle, controlName));
        }

        [TestMethod()]
        public void GivenWindowsHandleAndControlHandleAndSlothEvent_WhenRaiseSlothEvent_ThenSlothEventIsRaiseByMessage()
        {
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            IntPtr windowsHandle = new IntPtr(666);
            winUtilities.Expect(x => x.FindWindowsHandle(null, slothEvent.WindowsName)).Return(windowsHandle);
            IntPtr controlHandle = new IntPtr(777);
            winUtilities.Expect(x => x.FindControlHandle(windowsHandle, slothEvent.ControlName)).Return(controlHandle);

            target.PublishSlothEvent(slothEvent);

            winUtilities.AssertWasCalled(x => x.SendMessage(windowsHandle, controlHandle,slothEvent));
        }

    }

}
