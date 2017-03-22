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

        public void GivenWindows(string buttonName)
        {
            windows = new MessageOnlyWindow();
        }

        public void GivenEventListenerService()
        {
            winUtilities = new WinUtilities();
            IEventListener eventListener = new EventListener(new ApplicationAdapter(), new ControlAdapter(), logger, winUtilities);
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

        public void ThenEventIsLogInFile()
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
                .Then(x => x.ThenEventIsLogInFile(), "Then event is log in file")
                .BDDfy();
        }

        public void Dispose()
        {
            windows.Dispose();
        }
    }

}