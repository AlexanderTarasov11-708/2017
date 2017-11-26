using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex3Test
{
    [TestClass]
    public class Ex3Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tuple<double, int> b = Tuple.Create(7.99920263888835, 7);
            double x = 2;
            double a = 3;
            double e = 0.001;
            var res = ex.Program.GetSum(x, a, e, Math.Pow(x, a));
            Assert.AreEqual(b, res);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tuple<double, int> b = Tuple.Create(8.95133551154598, 4);
            double x = 3;
            double a = 2;
            double e = 0.1;
            var res = ex.Program.GetSum(x, a, e, Math.Pow(x, a));
            Assert.AreEqual(b, res);
        }
    }
}
