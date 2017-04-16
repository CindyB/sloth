using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
{
    [TestClass()]
    public class ApplicationAdapterTest
    {
        private IApplicationAdapter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new ApplicationAdapter();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod()]
        public void GivenApplicationWithOpenForms_WhenGetAllOpenForms_ThenAllOpenFormsOfApplicationAreReturned()
        {
            FormCollection expected = Application.OpenForms;

            FormCollection actual = target.AllOpenForms();

            Assert.AreSame(expected, actual);
        }

    }

}
