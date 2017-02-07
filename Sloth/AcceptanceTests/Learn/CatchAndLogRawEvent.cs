using System.Windows.Forms
using TestStack.BDDfy
using System.IO
using Sloth.Sloth.Interfaces
using Sloth.Sloth.Log

namespace Sloth.AcceptanceTests.Learn

    <TestClass, Story(Title:="Catch a user event and log it raw",
                      AsA:="Developer",
           IWant:="To catch a raw user event",
           SoThat:="I can log it")>
    public class CatchAndLogRawEvent

        private logFileName As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "UserEvent.sloth"
        private Const eventLine As String = ""
        private userButton As Button

        public void GivenUserButton(buttonName As String)
            userButton = new Button()
            userButton.Name = buttonName
        }

        public void GivenEventListenerService()
            Dim eventListener As IEventListener = new EventListener()
            eventListener.Start()
        }

        public void WhenButtonIsClick()
            userButton.PerformClick()
        }

        public void ThenEventIsLogInFile()
            Assert.AreEqual(eventLine, File.ReadLines(logFileName))
        }

        <TestMethod>
        public void CatchedEventLogged()
            Me.Given(void(x) x.GivenUserButton("MyTestButton"), "A user button named {0}") _
                .And(void(x) x.GivenEventListenerService(), "A event listener service") _
            .When(void(x) x.WhenButtonIsClick(), "When button is click") _
                .Then(void(x) x.ThenEventIsLogInFile(), "Then event is log in file") _
                .BDDfy()
        }

    }

}
