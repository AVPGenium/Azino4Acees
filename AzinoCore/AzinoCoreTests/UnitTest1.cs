using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AzinoCore;

namespace AzinoCoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(10, Rules.SpinCost);
        }
    }
}
