using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Interfaces.Core;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class WinUtilitiesTest
    {
        private bool buttonClick;
        private IWinUtilities m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            buttonClick = false;
            m_Target = new WinUtilities();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_Target = null;
        }

        [TestMethod()]
        public void GivenWindowsHandleAndControlName_WhenFindControlHandle_ThenControlHandleIsFound()
        {
            Form form = new Form();
            Button button = new Button();
            form.Controls.Add(button);

            IntPtr windowsHandle = form.Handle;
            string controlName = button.Name;
            IntPtr expected = button.Handle;

            IntPtr actual = m_Target.FindControlHandle(windowsHandle, controlName);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenNoWindowsHandleAndControlName_WhenFindControlHandle_ThenControlHandleIsFound()
        {
            IntPtr expected = IntPtr.Zero;

            IntPtr actual = m_Target.FindControlHandle(IntPtr.Zero, "MyControl");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenClassNameAndWindowsName_WhenFindWindowsHandle_ThenWindowsHandleIsFound()
        {
            Form form = new Form();
            form.Text = "Test";
            
            string className = null;
            string windowsName = form.Text;
            IntPtr expected = form.Handle;

            IntPtr actual = m_Target.FindWindowsHandle(className, windowsName);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenWindowsHandle_WhenGetWindowText_ThenWindowsTextIsFound()
        {
            Form form = new Form();
            form.Text = "Test";
            IntPtr windowsHandle = form.Handle;
            string expected = form.Text;

            string actual = m_Target.GetWindowText(windowsHandle);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }
        
        [TestMethod()]
        public void GivenWindowsAndControlHandleWithSlothEvent_WhenSendMessage_ThenControlReceiveMessage()
        {
            MessageOnlyWindow windows = new MessageOnlyWindow();
            IntPtr windowsHandle = windows.Handle;
            IntPtr controlHandle = windows.Handle;
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.ControlName = windows.Name;
            slothEvent.WindowsName = windows.Name;
            slothEvent.Message = 0x0;
            
            m_Target.SendMessage(windowsHandle,controlHandle,slothEvent);

            SpinWait.SpinUntil(() => windows.NullEventReceived, 30000);
            Assert.IsTrue(windows.NullEventReceived);
        }
    }

}
