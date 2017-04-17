using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Sloth.Core;
using Sloth.Learn;
using System;
using System.Reflection;
using System.Threading;

namespace Sloth.UnitTests.Learn
{
    [TestClass()]
    public class EventListenerTest
    {
        private HookProc callbackDelegate;
        private IControlAdapter controlAdapter;
        private ILogger logger;
        private IWinUtilities winUtilities;
        private ISlothListener target;

        [TestInitialize]
        public void TestInitialize()
        {
            controlAdapter = MockRepository.GenerateMock<IControlAdapter>();
            logger = MockRepository.GenerateMock <ILogger>();
            winUtilities = MockRepository.GenerateMock<IWinUtilities>();

            target = new SlothListener(controlAdapter,logger,winUtilities);

            callbackDelegate = (HookProc)target.GetType().GetField("callbackDelegate", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            controlAdapter = null;
            logger = null;
            winUtilities = null;
            
            target = null;
        }

        [TestMethod()]
        public void GivenWinUtilities_WhenStart_WindowsIsHook()
        {
            target.Start();
            
            winUtilities.AssertWasCalled(x => x.SetWindowsHookEx(3, callbackDelegate, IntPtr.Zero, Thread.CurrentThread.ManagedThreadId));
        }

    }

}
