using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class KeyboardTest
    {
        private IFilter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new KeyboardFilter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }
        
        [TestMethod()]
        public void GivenMessageIsKeyFirst_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.KeyFirst);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsKeyFirst_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.KeyFirst - 1);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void GivenMessageIsKeyLast_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange((uint)WM.KeyLast);

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GivenMessageIsAboveKeyLast_WhenIsInRange_ThenItIsFalse()
        {
            bool actual = target.IsInRange((uint)WM.KeyLast + 1);

            Assert.IsFalse(actual);
        }

    }

}
