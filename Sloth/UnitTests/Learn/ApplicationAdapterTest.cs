using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Interfaces;
using Sloth.Learn;
using System;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class ApplicationAdapterTest
    {

        private IApplicationAdapter m_Target;

        [TestInitialize]
        public void TestInitialize()
        {
            m_Target = new ApplicationAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_Target = null;
        }

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public void GivenEventListenerIsNothing_WhenAddEventListenerAsMessageFilter_ThenArgumentNullExceptionIsThrown()
        {
            m_Target.AddEventListenerAsMessageFilter(null);
        }

    }

}
