using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex2Test
{
    [TestClass]
    public class Ex2Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tuple<double, int> a = Tuple.Create(0, 0);
            double x = 0;
            double e = 1;
            var res = ex.Program.GetSum(x, e, Math.Atan(x));
            Assert.AreEqual(a, res);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tuple<double, int> a = Tuple.Create(0, 0);
            double x = 0.001;
            double e = 0.1;
            var res = ex.Program.GetSum(x, e, Math.Atan(x));
            Assert.AreEqual(a, res);
        }
    }
}
