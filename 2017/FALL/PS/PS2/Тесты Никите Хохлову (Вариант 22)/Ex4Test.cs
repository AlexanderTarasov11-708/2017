using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex4Test
{
    [TestClass]
    public class Ex4Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tuple<double, int> b = Tuple.Create(2.59047619047619, 4);
            double e = 1;
            var res1 = ex.Program.GetSum(e);
            Assert.AreEqual(b, res);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tuple<double, int> b = Tuple.Create(2.13333333333333, 3);
            double e = 1.5;
            var res = ex.Program.GetSum(e);
            Assert.AreEqual(b, res);
        }
    }
}
