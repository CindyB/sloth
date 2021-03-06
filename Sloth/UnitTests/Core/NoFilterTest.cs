﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class NoFilterTest
    {
        private IFilter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new NoFilter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod()]
        public void GivenAnyMessage_WhenIsInRange_ThenItIsTrue()
        {
            bool actual = target.IsInRange(20);

            Assert.IsTrue(actual);
        }

    }

}
