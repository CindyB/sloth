using Sloth.Sloth.Interfaces
using Sloth.Sloth.Log

namespace Sloth.UnitTests.Log

    <TestClass()>
    public class ApplicationAdapterTest

        private m_Target As IApplicationAdapter

        <TestInitialize>
        public void TestInitialize()
            m_Target = new ApplicationAdapter()
        }

        <TestCleanup>
        public void TestCleanup()
            m_Target = Nothing
        }

        <TestMethod(), ExpectedException(GetType(ArgumentNullException))>
        public void GivenEventListenerIsNothing_WhenAddEventListenerAsMessageFilter_ThenArgumentNullExceptionIsThrown()
            m_Target.AddEventListenerAsMessageFilter(Nothing)
        }

    }

}
