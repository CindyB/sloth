using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class MouseTest
    {
        private IFilter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new MouseFilter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod()]
        public void GivenMessageIsNonClientMouseMove_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.NonClientMouseMove);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsBelowNonClientMouseMove_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.NonClientMouseMove-1);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void GivenMessageIsNonClientXButtonDblClk_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.NonClientXButtonDblClk);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsAboveNonClientXButtonDblClk_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.NonClientXButtonDblClk + 1);

            Assert.IsFalse(actual);
        }
        
        [TestMethod()]
        public void GivenMessageIsMouseFirst_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.MouseFirst);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsBelowMouseFirst_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.MouseFirst - 1);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void GivenMessageIsMouseLast_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.MouseLast);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsAboveMouseLast_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.MouseLast + 1);

            Assert.IsFalse(actual);
        }
    }

}
