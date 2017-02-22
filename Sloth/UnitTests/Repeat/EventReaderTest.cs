using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Repeat;
using Sloth.Repeat;
using System.Collections.Generic;
using System.Reflection;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventReaderTest
    {
        private IEventConverter m_EventConverter;
        private IFileAdapter m_FileAdapter;
        private IEventReader m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
            m_EventConverter = MockRepository.GenerateMock<IEventConverter>();
            m_FileAdapter = MockRepository.GenerateMock<IFileAdapter>();

            m_Target = new EventReader();
            m_Target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_EventConverter);
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_FileAdapter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_EventConverter = null;
            m_FileAdapter = null;

            m_Target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadEvents_ThenAllLinesOfFileAreRead()
        {
            string filePath = this.GetType().Assembly.Location;

            m_Target.ReadEvents(filePath);

            m_FileAdapter.AssertWasCalled(x => x.ReadAllLines(filePath));
        }

        [TestMethod()]
        public void GivenLinesOfFile_WhenReadEvents_ThenLinesAreConvertedToSlothEvents()
        { 
            string filePath = this.GetType().Assembly.Location;
            string[] lines = {"MyButton;Click"};
            m_FileAdapter.Expect(x => x.ReadAllLines(filePath)).Return(lines);

            m_Target.ReadEvents(filePath);

            m_EventConverter.AssertWasCalled(x => x.ConvertToSlothEvents(lines));
        }

        [TestMethod()]
        public void GivenFilePath_WhenReadEvents_ThenConvertedEventsAreReturned()
        { 
            string filePath = this.GetType().Assembly.Location;
            string[] lines = {"MyButton;Click"};
            m_FileAdapter.Expect(x => x.ReadAllLines(filePath)).Return(lines);
            IList<ISlothEvent> expected = new List<ISlothEvent>(){ MockRepository.GenerateMock<ISlothEvent>(), MockRepository.GenerateMock<ISlothEvent>()};
            m_EventConverter.Expect(x => x.ConvertToSlothEvents(lines)).Return(expected);

            IList<ISlothEvent> actual = m_Target.ReadEvents(filePath);

            Assert.AreSame(expected, actual);
        }

    }

}
