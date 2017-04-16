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
        private IEventRaiser eventRaiser;
        private IEventReader eventReader;
        private IAutomaton target; 

        [TestInitialize]
        public void TestInitialize()
        {
            eventRaiser = MockRepository.GenerateMock<IEventRaiser>();
            eventReader = MockRepository.GenerateMock<IEventReader>();

            target = new Automaton();
            target.GetType().GetField("eventRaiser", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, eventRaiser);
            target.GetType().GetField("eventReader", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, eventReader);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            eventRaiser = null;
            eventReader = null;

            target.GetType().GetField("eventRaiser", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target.GetType().GetField("eventReader", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenFilePathIsNothing_WhenRepeatBehavior_ThenArgumentNullExceptionIsThrown()
        {
            target.RepeatBehavior(null);
        }

        [TestMethod(), ExpectedException(typeof(ArgumentException))]
        public void GivenFilePathIsEmpty_WhenRepeatBehavior_ThenArgumentExceptionIsThrown()
        { 
            target.RepeatBehavior(String.Empty);
        }

        [TestMethod(), ExpectedException(typeof(FileNotFoundException))]
        public void GivenFilePathDoesNotExists_WhenRepeatBehavior_ThenFileNotFoundExceptionIsThrown()
        { 
            target.RepeatBehavior("Z:\\test.txt");
        }

        [TestMethod()]
        public void GivenFilePath_WhenRepeatBehavior_ThenEventsAreReadFromFile()
        { 
            string filePath = this.GetType().Assembly.Location;

            target.RepeatBehavior(filePath);

            eventReader.AssertWasCalled(x => x.ReadEvents(filePath));
        }

        [TestMethod()]
        public void GivenNoEventReadFromFile_WhenRepeatBehavior_ThenEventRaisingIsNotCalled()
        { 
            string filePath = this.GetType().Assembly.Location;

            target.RepeatBehavior(filePath);

            eventRaiser.AssertWasNotCalled(x => x.PublishSlothEvent(Arg<ISlothEvent>.Is.Anything));
        }

        [TestMethod()]
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenEventIsRaised()
        { 
            string filePath = this.GetType().Assembly.Location;
            ISlothEvent[] eventSloth = new ISlothEvent[] { MockRepository.GenerateMock<ISlothEvent>()};
            eventReader.Expect(x => x.ReadEvents(filePath)).Return(eventSloth);

            target.RepeatBehavior(filePath);

            eventRaiser.AssertWasCalled(x => x.PublishSlothEvent(eventSloth[0]));
        }

        [TestMethod()]
        public void GivenEventReadFromFile_WhenRepeatBehavior_ThenAllEventsAreRaised()
        {
            string filePath = this.GetType().Assembly.Location;
            ISlothEvent[] eventSloth = new ISlothEvent[] { MockRepository.GenerateMock<ISlothEvent>(), MockRepository.GenerateMock<ISlothEvent>() };
            eventReader.Expect(x => x.ReadEvents(filePath)).Return(eventSloth);

            target.RepeatBehavior(filePath);

            eventRaiser.AssertWasCalled(x => x.PublishSlothEvent(eventSloth[0]));
            eventRaiser.AssertWasCalled(x => x.PublishSlothEvent(eventSloth[1]));
        }

    }

}
