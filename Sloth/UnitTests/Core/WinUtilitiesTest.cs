using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class WinUtilitiesTest : IDisposable
    {
        private Form form;
        private MessageOnlyWindow windows;
        private IWinUtilities target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new WinUtilities();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod()]
        public void GivenWindowsHandleAndControlName_WhenFindControlHandle_ThenControlHandleIsFound()
        {
            form = new Form();
            Button button = new Button();
            form.Controls.Add(button);

            IntPtr windowsHandle = form.Handle;
            string controlName = button.Name;
            IntPtr expected = button.Handle;

            IntPtr actual = target.FindControlHandle(windowsHandle, controlName);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenNoWindowsHandleAndControlName_WhenFindControlHandle_ThenControlHandleIsFound()
        {
            IntPtr expected = IntPtr.Zero;

            IntPtr actual = target.FindControlHandle(IntPtr.Zero, "MyControl");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GivenClassNameAndWindowsName_WhenFindWindowsHandle_ThenWindowsHandleIsFound()
        {
            form = new Form();
            form.Text = "MyForm1";

            string className = null;
            string windowsName = form.Text;
            IntPtr expected = form.Handle;

            IntPtr actual = target.FindWindowsHandle(className, windowsName);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenWindowsHandle_WhenGetWindowText_ThenWindowsTextIsFound()
        {
            form = new Form();
            form.Text = "MyForm";
            IntPtr windowsHandle = form.Handle;
            string expected = form.Text;

            string actual = target.GetWindowText(windowsHandle);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenWindowsAndControlHandleWithNoSlothEvent_WhenSendMessage_ThenNoMessageIsSent()
        {
            windows = new MessageOnlyWindow();
            IntPtr windowsHandle = windows.Handle;
            IntPtr controlHandle = windows.Handle;
            ISlothEvent slothEvent = null;

            target.SendMessage(windowsHandle, controlHandle, slothEvent);

        }

        [TestMethod()]
        public void GivenWindowsAndControlHandleWithSlothEvent_WhenSendMessage_ThenControlReceiveMessage()
        {
            windows = new MessageOnlyWindow();
            IntPtr windowsHandle = windows.Handle;
            IntPtr controlHandle = windows.Handle;
            ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();
            slothEvent.ControlName = windows.Name;
            slothEvent.WindowsName = windows.Name;
            slothEvent.Message = 0x0;

            target.SendMessage(windowsHandle, controlHandle, slothEvent);

            SpinWait.SpinUntil(() => windows.NullEventReceived, 30000);
            Assert.IsTrue(windows.NullEventReceived);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (form != null) form.Dispose();
                    if (windows != null) windows.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}
