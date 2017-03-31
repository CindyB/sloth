using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Repeat;
using System.Collections.Generic;
using System.Reflection;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventReaderTest
    {
        private IEventConverter eventConverter;
        private IFileAdapter fileAdapter;
        private IEventReader target; 

        [TestInitialize]
        public void TestInitialize()
        {
            eventConverter = MockRepository.GenerateMock<IEventConverter>();
            fileAdapter = MockRepository.GenerateMock<IFileAdapter>();

            target = new EventReader();
            target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, eventConverter);
            target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, fileAdapter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            eventConverter = null;
            fileAdapter = null;

            target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, null);
            target = null;
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadEvents_ThenAllLinesOfFileAreRead()
        {
            string filePath = this.GetType().Assembly.Location;

            target.ReadEvents(filePath);

            fileAdapter.AssertWasCalled(x => x.ReadAllLines(filePath));
        }

        [TestMethod()]
        public void GivenLinesOfFile_WhenReadEvents_ThenLinesAreConvertedToSlothEvents()
        { 
            string filePath = this.GetType().Assembly.Location;
            string[] lines = {"MyButton;Click"};
            fileAdapter.Expect(x => x.ReadAllLines(filePath)).Return(lines);

            target.ReadEvents(filePath);

            eventConverter.AssertWasCalled(x => x.ConvertToSlothEvents(lines));
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadEvents_ThenConvertedEventsAreReturned()
        { 
            string filePath = this.GetType().Assembly.Location;
            string[] lines = {"MyButton;Click"};
            fileAdapter.Expect(x => x.ReadAllLines(filePath)).Return(lines);
            IList<ISlothEvent> expected = new List<ISlothEvent>(){ MockRepository.GenerateMock<ISlothEvent>(), MockRepository.GenerateMock<ISlothEvent>()};
            eventConverter.Expect(x => x.ConvertToSlothEvents(lines)).Return(expected);

            IList<ISlothEvent> actual = target.ReadEvents(filePath);

            Assert.AreSame(expected, actual);
        }

    }

}
