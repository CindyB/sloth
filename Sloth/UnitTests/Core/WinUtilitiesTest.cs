using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Interfaces.Core;
using System;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class WinUtilitiesTest
    {

        private IWinUtilities m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
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
            form.CreateControl();

            IntPtr windowsHandle = form.Handle;
            string controlName = button.Name;
            IntPtr expected = button.Handle;

            IntPtr actual = m_Target.FindControlHandle(windowsHandle, controlName);

            Assert.AreSame(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenClassNameAndWindowsName_WhenFindWindowsHandle_ThenWindowsHandleIsFound()
        {
            Form form = new Form();
            form.Text = "Test";
            form.CreateControl();
            string className = null;
            string windowsName = form.Text;
            IntPtr expected = form.Handle;

            IntPtr actual = m_Target.FindWindowsHandle(className, windowsName);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenWindowsHandle_WhenGetClassName_ThenClassNameIsFound()
        {
            Form form = new Form();
            form.Text = "Test";
            IntPtr windowsHandle = form.Handle;
            string expected = form.GetType().Name;

            string actual = m_Target.GetClassName(windowsHandle);

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
        public void GivenWindowsAndControlHandleWithSlothEvent_WhenSendMessage_ThenXXXXX()
        {
            //IntPtr windowsHandle;
            //IntPtr controlHandle;
            //ISlothEvent slothEvent = MockRepository.GenerateMock<ISlothEvent>();

            //m_Target.SendMessage(windowsHandle,controlHandle,slothEvent);

            Assert.Fail();
        }

    }

}
