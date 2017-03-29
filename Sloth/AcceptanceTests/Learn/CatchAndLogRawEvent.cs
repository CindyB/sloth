using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using Sloth.Learn;
using Sloth.UnitTests.Core;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TestStack.BDDfy;

namespace Sloth.AcceptanceTests.Learn
{
    [TestClass, Story(Title = "Catch a user event and log it raw",
                    AsA = "Developer",
                    IWant = "To catch a raw user event",
                    SoThat = "I can log it")]
    public class CatchAndLogRawEvent : IDisposable
    {
        private string logFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "TestUserEvent.sloth";
        private const string eventLine = ";;0";
        private ILogger logger;
        private ISlothEvent slothEvent;
        private MessageOnlyWindow windows;
        private WinUtilities winUtilities;

        [TestInitialize]
        public void TestInitialize()
        {
            logger = new Logger();
            logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(logger, logFileName);

            File.Delete(logFileName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(logger, null);
            logger = null;
            slothEvent = null;
            windows = null;
            winUtilities = null;
        }

        public void GivenWindows(string windowName)
        {
            windows = new MessageOnlyWindow();
            windows.Name = windowName;
        }

        public void GivenEventListenerService()
        {
            winUtilities = new WinUtilities();
            IEventListener eventListener = new EventListener(new ControlAdapter(), logger, winUtilities);
            eventListener.Start();
        }

        public void GivenSlothEvent()
        {
            slothEvent = new SlothEvent(windows.Name, windows.Name,0x0);
        }

        public void WhenButtonIsClick()
        {
            winUtilities.SendMessage(windows.Handle, windows.Handle, slothEvent);
        }

        public void ThenEventIsLogIntoFile()
        {
            SpinWait.SpinUntil(() => windows.NullEventReceived, 30000);
            Assert.AreEqual(eventLine, File.ReadLines(logFileName));
        }

        [TestMethod]
        public void CatchedEventLogged()
        {
            this.Given(x => x.GivenWindows("MyTestButton"), "A user button named {0}")
                .And(x => x.GivenEventListenerService(), "A event listener service")
                .And(x => x.GivenSlothEvent(),"And an event")
            .When(x => x.WhenButtonIsClick(), "When button is click")
                .Then(x => x.ThenEventIsLogIntoFile(), "Then event is log in file")
                .BDDfy();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    windows.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~CatchAndLogRawEvent() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}