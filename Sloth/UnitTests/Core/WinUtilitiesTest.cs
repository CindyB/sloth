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
        private const string WindowsName = "Test";
        private Form form;
        private IWinUtilities m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            m_Target = new WinUtilities();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            form.Dispose();
            m_Target = null;
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
            form = new Form();
            form.Text = WindowsName;
            
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
            form = new Form();
            form.Text = WindowsName;
            IntPtr windowsHandle = form.Handle;
            string expected = form.Text;

            string actual = m_Target.GetWindowText(windowsHandle);

            Assert.AreEqual(expected, actual);
            form.Dispose();
        }

        [TestMethod()]
        public void GivenWindowsAndControlHandleWithNoSlothEvent_WhenSendMessage_ThenNoMessageIsSent()
        {
            MessageOnlyWindow windows = new MessageOnlyWindow();
            IntPtr windowsHandle = windows.Handle;
            IntPtr controlHandle = windows.Handle;
            ISlothEvent slothEvent = null;

            m_Target.SendMessage(windowsHandle, controlHandle, slothEvent);
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

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~WinUtilitiesTest() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
