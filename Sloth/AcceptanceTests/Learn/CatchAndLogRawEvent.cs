using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Interfaces;
using Sloth.Learn;
using System;
using System.IO;

using System.Windows.Forms;

using TestStack.BDDfy;

namespace Sloth.AcceptanceTests.Learn
{ 
    [TestClass, Story(Title = "Catch a user event and log it raw",
                      AsA = "Developer",
           IWant = "To catch a raw user event",
           SoThat = "I can log it")]
    public class CatchAndLogRawEvent
    {
        private string logFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth";
        private const string eventLine = "";
        private Button userButton;

        public void GivenUserButton(string buttonName)
        {
            userButton = new Button();
            userButton.Name = buttonName;
        }

        public void GivenEventListenerService()
        {
            IEventListener eventListener = new EventListener();
            eventListener.Start();
        }

        public void WhenButtonIsClick()
        {
            userButton.PerformClick();
        }

        public void ThenEventIsLogInFile()
        {
            Assert.AreEqual(eventLine, File.ReadLines(logFileName));
        }

        [TestMethod]
        public void CatchedEventLogged()
        { 
            this.Given(x => x.GivenUserButton("MyTestButton"), "A user button named {0}") 
                .And(x => x.GivenEventListenerService(), "A event listener service") 
            .When(x => x.WhenButtonIsClick(), "When button is click") 
                .Then(x => x.ThenEventIsLogInFile(), "Then event is log in file") 
                .BDDfy();
        }

    }

}
