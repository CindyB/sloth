using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Repeat;
using System;
using System.IO;
using System.Reflection;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class AutomatonTest
    {
        private IEventRaiser m_EventRaiser;
        private IEventReader m_EventReader;
        private IAutomaton m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
            m_EventRaiser = MockRepository.GenerateMock<IEventRaiser>();
            m_EventReader = MockRepository.GenerateMock<IEventReader>();

            m_Target = new Automaton();
            m_Target.GetType().GetField("m_EventRaiser", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_EventRaiser);
            m_Target.GetType().GetField("m_EventReader", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_EventReader);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_EventRaiser = null;
            m_EventReader = null;

            m_Target.GetType().GetField("m_EventRaiser", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target.GetType().GetField("m_EventReader", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenFilePathIsNothing_WhenRepeatBehavior_ThenArgumentNullExceptionIsThrown()
        {
            m_Target.RepeatBehavior(null);
        }

        [TestMethod(), ExpectedException(typeof(ArgumentException))]
        public void GivenFilePathIsEmpty_WhenRepeatBehavior_ThenArgumentExceptionIsThrown()
        { 
            m_Target.RepeatBehavior(String.Empty);
        }

        [TestMethod(), ExpectedException(typeof(FileNotFoundException))]
        public void GivenFilePathDoesntExists_WhenRepeatBehavior_ThenFileNotFoundExceptionIsThrown()
        { 
            m_Target.RepeatBehavior("Z:\\test.txt");
        }

        [TestMethod()]
        public void GivenFilePath_WhenRepeatBehavior_ThenEventsAreReadFromFile()
        { 
            string filePath = this.GetType().Assembly.Location;

            m_Target.RepeatBehavior(filePath);

            m_EventReader.AssertWasCalled(x => x.ReadEvents(filePath));
        }

        [TestMethod()]
        public void GivenNoEventReadFromFile_WhenRepeatBehavior_ThenEventRaisingIsNotCalled()
        { 
            string filePath = this.GetType().Assembly.Location;

            m_Target.RepeatBehavior(filePath);

            m_EventRaiser.AssertWasNotCalled(x => x.RaiseSlothEvent(Arg<ISlothEvent>.Is.Anything));
        }

        [TestMethod()]
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenEventIsRaised()
        { 
            string filePath = this.GetType().Assembly.Location;
            ISlothEvent[] eventSloth = new ISlothEvent[] { MockRepository.GenerateMock<ISlothEvent>()};
            m_EventReader.Expect(x => x.ReadEvents(filePath)).Return(eventSloth);

            m_Target.RepeatBehavior(filePath);

            m_EventRaiser.AssertWasCalled(x => x.RaiseSlothEvent(eventSloth[0]));
        }

        [TestMethod()]
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenAllEventsAreRaised()
        {
            string filePath = this.GetType().Assembly.Location;
            ISlothEvent[] eventSloth = new ISlothEvent[] { MockRepository.GenerateMock<ISlothEvent>(), MockRepository.GenerateMock<ISlothEvent>() };
            m_EventReader.Expect(x => x.ReadEvents(filePath)).Return(eventSloth);

            m_Target.RepeatBehavior(filePath);

            m_EventRaiser.AssertWasCalled(x => x.RaiseSlothEvent(eventSloth[0]));
            m_EventRaiser.AssertWasCalled(x => x.RaiseSlothEvent(eventSloth[1]));
        }

    }

}
