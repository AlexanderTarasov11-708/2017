using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex1Test
{
    [TestClass]
    public class Ex1Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tuple<double, int> a = Tuple.Create(1.4052734375, 6);
            double x = 1;
            double e = 0.01;
            var res = ex.Program.GetSum(x, e, Math.Sqrt(1 + x));
            Assert.AreEqual(a, res);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tuple<double, int> a = Tuple.Create(1.21875, 2);
            double x = 0.5;
            double e = 0.01;
            var res = ex.Program.GetSum(x, e, Math.Sqrt(1 + x));
            Assert.AreEqual(a, res);
        }
    }
}
