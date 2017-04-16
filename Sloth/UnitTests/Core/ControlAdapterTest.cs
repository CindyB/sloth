using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class ControlAdapterTest
    {
        private IControlAdapter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new ControlAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod()]
        public void GivenControlHandle_WhenFromHandle_ThenControlIsReturned()
        {
            Control expected = new Control(); ;
            try
            {
                Control actual = target.FromHandle(expected.Handle);

                Assert.AreSame(expected, actual);
            }
            finally
            {
                expected.Dispose();
            }
        }

    }

}
