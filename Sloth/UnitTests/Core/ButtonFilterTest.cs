using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class ButtonTest
    {
        private IFilter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new ButtonFilter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }
        
        [TestMethod()]
        public void GivenMessageIsLButtonDown_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.LButtonDown);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsLButtonDown_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.LButtonDown - 1);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void GivenMessageIsMouseHWheel_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.MouseHWheel);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsAboveMouseHWheel_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.MouseHWheel + 1);

            Assert.IsFalse(actual);
        }

    }

}
