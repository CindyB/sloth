﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sloth.Core;
using System.Windows.Forms;

namespace Sloth.UnitTests.Core
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

        [TestMethod()]
        public void GivenApplicationWithOpenForms_WhenGetAllOpenForms_ThenAllOpenFormsOfApplicationAreReturned()
        {
            FormCollection expected = Application.OpenForms;

            FormCollection actual = m_Target.AllOpenForms();

            Assert.AreSame(expected, actual);
        }

    }

}
