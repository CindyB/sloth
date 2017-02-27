using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Interfaces.Learn;
using Sloth.Interfaces.Repeat;
using Sloth.Learn;
using Sloth.Repeat;
using System;
using System.IO;

using System.Reflection;
using System.Windows.Forms;
using TestStack.BDDfy;

namespace Sloth.AcceptanceTests.Automation
{
    [TestClass, Story(Title = "Read formatted user event and raise it",
                      AsA = "Developer",
           IWant = "To read a user event",
           SoThat = "Raise it")]
    public class ReadAndRaiseFormattedEvent
    {
        private Button button;
        private Boolean buttonClicked;
        private Form form;
        private string m_logFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "Sloth" + Path.DirectorySeparatorChar + "TestUserEvent.sloth";
        private ILogger m_Logger;

        [TestInitialize]
        public void TestInitialize()
        {
            m_Logger = new Logger();
            m_Logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Logger, m_logFileName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            button = null;
            form = null;

            m_Logger.GetType().GetField("m_FilePath", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Logger, null);
            m_Logger = null;

            File.Delete(m_logFileName);
        }

        public void GivenUserEventLogFileWithUserEvent(string eventLine)
        {
            m_Logger.Log(eventLine);
        }

        public void GivenFormWithButton(string formText, string buttonName)
        {
            form = new Form();
            form.Text = formText;

            button = new Button();
            button.Name = buttonName;
            form.Controls.Add(button);
            button.Click += Button_Click;

            buttonClicked = false;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
        }

        public void WhenReadAndRaiseFirstEvent()
        {
            IAutomaton auto = new Automaton();
            auto.RepeatBehavior(m_logFileName);
        }

        public void ThenFirstEventReadIsRaised()
        {
            Assert.IsTrue(buttonClicked);
        }

        [TestMethod]
        public void ReadEventRaised()
        { 
            this.Given(x => x.GivenUserEventLogFileWithUserEvent("MyForm;MyButton;513"), "A user event log file with user event {0}")
                .And(x => x.GivenFormWithButton("MyForm","MyButton"),"And form {0} with button {1}")
            .When(x => x.WhenReadAndRaiseFirstEvent(), "When read file and raise first event")
                .Then(x => x.ThenFirstEventReadIsRaised(), "Then first user event read in file is raised")
                .BDDfy();
        }

    }

}
