using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Learn;
using Sloth.Repeat;
using Sloth.UnitTests.Core;
using System;
using System.IO;

using System.Reflection;
using System.Threading;
using TestStack.BDDfy;

namespace Sloth.AcceptanceTests.Automation
{
    [TestClass, Story(Title = "Read formatted user event and raise it",
                    AsA = "Developer",
                    IWant = "To read a user event",
                    SoThat = "Raise it")]
    public class ReadAndRaiseFormattedEvent : IDisposable
    {
        private string logFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "TestUserEvent.sloth";
        private ILogger logger;
        private MessageOnlyWindow windows;

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
            windows = null;
        }

        public void GivenUserEventLogFileWithUserEvent(string eventLine)
        {
            logger.Log(eventLine);
        }

        public void GivenWindows(string windowsName)
        {
            windows = new MessageOnlyWindow();
            windows.Name = windowsName;
        }

        public void WhenReadAndRaiseFirstEvent()
        {
            IAutomaton auto = new Automaton();
            auto.RepeatBehavior(logFileName);
        }

        public void ThenFirstEventReadIsRaised()
        {
            SpinWait.SpinUntil(() => windows.NullEventReceived, 30000);
            Assert.IsTrue(windows.NullEventReceived);
        }

        [TestMethod]
        public void ReadEventRaised()
        {
            this.Given(x => x.GivenUserEventLogFileWithUserEvent("test;test;0"), "A user event log file with user event {0}")
                .And(x => GivenWindows("test"),"A windows named {0}")
            .When(x => x.WhenReadAndRaiseFirstEvent(), "When read file and raise first event")
                .Then(x => x.ThenFirstEventReadIsRaised(), "Then first user event read in file is raised")
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
        // ~ReadAndRaiseFormattedEvent() {
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