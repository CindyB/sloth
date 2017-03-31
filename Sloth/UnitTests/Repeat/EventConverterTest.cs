using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Repeat;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventConverterTest
    {
        private const char LineSeparator = ';';
        private IEventConverter target; 

        [TestInitialize]
        public void TestInitialize()
        {
            target = new EventConverter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentException))]
        public void GivenLinesAreEmpty_WhenConvertToSlothEvents_ThenArgumentExceptionIsThrown()
        {
            target.ConvertToSlothEvents(new string[] { });   
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenLinesAreNull_WhenConvertToSlothEvents_ThenArgumentNullExceptionIsThrown()
        {
            target.ConvertToSlothEvents(null);
        }

        [TestMethod()]
        public void GivenLine_WhenConvertToSlothEvents_ThenCorrespondingSlothEventIsReturned()
        {
            int numberOfEvent = 1;
            string windowsName = "MyWindows";
            string controlName = "MyButton";
            uint message = (uint)WM.LButtonDown;

            string line = windowsName + LineSeparator + controlName + LineSeparator + message.ToString(CultureInfo.InvariantCulture);
            ISlothEvent expected = MockRepository.GenerateMock<ISlothEvent>();
            expected.Expect(x => x.WindowsName).Return(windowsName);
            expected.Expect(x => x.ControlName).Return(controlName);
            expected.Expect(x => x.Message).Return(message);

            IList<ISlothEvent> actual = target.ConvertToSlothEvents(new string[] { line });

            Assert.AreEqual(numberOfEvent, actual.Count);
            Assert.AreEqual(expected.WindowsName, actual[0].WindowsName);
            Assert.AreEqual(expected.ControlName, actual[0].ControlName);
            Assert.AreEqual(expected.Message, actual[0].Message);
        }

    }

}
