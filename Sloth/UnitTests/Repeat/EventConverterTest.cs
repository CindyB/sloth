using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Interfaces.Core;
using Sloth.Interfaces.Repeat;
using Sloth.Repeat;
using System;
using System.IO;
using System.Reflection;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventConverterTest
    {
        private const char CHR_LineSeparator = ';';
        private IEventConverter m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
            m_Target = new EventConverter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_Target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentException))]
        public void GivenLinesAreEmpty_WhenConvertToSlothEvents_ThenArgumentExceptionIsThrown()
        {
            m_Target.ConvertToSlothEvents(new string[] { });   
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenLinesAreNull_WhenConvertToSlothEvents_ThenArgumentNullExceptionIsThrown()
        {
            m_Target.ConvertToSlothEvents(null);
        }

        [TestMethod()]
        public void GivenLine_WhenConvertToSlothEvents_ThenLineIsSplittedByInformationType()
        {
           string line = MockRepository.GenerateMock<string>();
            
            m_Target.ConvertToSlothEvents(new string[]{line});

            line.AssertWasCalled(x => x.Split(CHR_LineSeparator));
        }

        [TestMethod()]
        public void GivenLines_WhenConvertToSlothEvents_ThenAllLinesAreManaged()
        {
            string[] lines = new string[] { MockRepository.GenerateMock<string>(), MockRepository.GenerateMock<string>(), MockRepository.GenerateMock<string>() };

            m_Target.ConvertToSlothEvents(lines);

            foreach(string line in lines)
                line.AssertWasCalled(x => x.Split(CHR_LineSeparator));
        }

        [TestMethod()]
        public void GivenLine_WhenConvertToSlothEvents_ThenCorrespondingSlothEventIsReturned()
        {
            string windowsName = "MyWindows";
            string controlName = "MyButton";
            uint message = (uint)WM.LBUTTONDOWN;

            string line = MockRepository.GenerateMock<string>();
            //TODO MOCK LINE
            ISlothEvent expected = MockRepository.GenerateMock<ISlothEvent>();
            expected.Expect(x => x.WindowsName).Return(windowsName);
            expected.Expect(x => x.ControlName).Return(controlName);
            expected.Expect(x => x.Message).Return(message);

            ISlothEvent actual = m_Target.ConvertToSlothEvents(new string[] { line })[0];

            Assert.AreEqual(expected.WindowsName, actual.WindowsName);
            Assert.AreEqual(expected.ControlName, actual.ControlName);
            Assert.AreEqual(expected.Message, actual.Message);
        }

    }

}
