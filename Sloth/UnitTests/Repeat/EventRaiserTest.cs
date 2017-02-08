using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

using Sloth.Interfaces;
using Sloth.Repeat;
using System.Reflection;
using System.Windows.Forms;

namespace Sloth.UnitTests.Repeat
{
    [TestClass()]
    public class EventRaiserTest
    {
        private IApplicationAdapter m_ApplicationAdapter;
        private IEventRaiser m_Target; 

        [TestInitialize]
        public void TestInitialize()
        {
            m_ApplicationAdapter = MockRepository.GenerateMock<IApplicationAdapter>();

            m_Target = new EventRaiser();
            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, m_ApplicationAdapter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            m_ApplicationAdapter = null;

            m_Target.GetType().GetField("m_ApplicationAdapter", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m_Target, null);
            m_Target = null;
        }

        [TestMethod()]
        public void GivenSlothEvent_WhenRaiseSlothEvent_ThenAllOpenFormsAreGet()
        {
            m_Target.RaiseSlothEvent(MockRepository.GenerateMock<ISlothEvent>());

            m_ApplicationAdapter.AssertWasCalled(x => x.GetAllOpenForms());
        }

        [TestMethod()]
        public void GivenSlothEvent_WhenRaiseSlothEvent_ThenControlIsFindInOpenForms()
        {
            FormCollection collection = new FormCollection();

            m_Target.RaiseSlothEvent(MockRepository.GenerateMock<ISlothEvent>());

            Assert.Fail();
        }

    }

}
