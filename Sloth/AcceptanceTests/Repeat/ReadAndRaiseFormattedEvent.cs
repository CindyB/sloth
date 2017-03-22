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

        public void Dispose()
        {
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

    }

}