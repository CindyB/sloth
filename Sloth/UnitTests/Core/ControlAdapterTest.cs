using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class ControlAdapterTest
    {

        private IControlAdapter m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            m_Target = new ControlAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_Target = null;
        }

        [TestMethod()]
        public void GivenControlHandle_WhenFromHandle_ThenControlIsReturned()
        {
            Control expected = new Control();

            Control actual = m_Target.FromHandle(expected.Handle);

            Assert.AreSame(expected, actual);
            expected.Dispose();
        }

    }

}
