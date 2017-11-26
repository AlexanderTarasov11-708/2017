using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex5Test
{
    [TestClass]
    public class Ex5Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            double a1 = 1.02763268284328;
            double a2 = 1.02823020753868;
            double a3 = 1.02793144519097;
            double a4 = 1.02831555932509;
            double a = 0;
            double b = 1.5;
            int n = 50;
            double h = (b - a) / n;
            double res1 = ex.Program.LeftRectAngle(h, n);
            double res2 = ex.Program.RightRectAngle(h, n);
            double res3 = ex.Program.TrapezoidalMethod(h, n);
            double res4 = ex.Program.SimpsonMethod(a, b, n);
            Assert.AreEqual(a1, res1);
            Assert.AreEqual(a2, res2);
            Assert.AreEqual(a3, res3);
            Assert.AreEqual(a4, res4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double a1 = 1.15529975907964;
            double a2 = 1.17023787646464;
            double a3 = 1.16276881777214;
            double a4 = 1.50383474931928;
            double a = 0;
            double b = 1.5;
            int n = 2;
            double h = (b - a) / n;
            var res1 = ex.Program.LeftRectAngle(h, n);
            var res2 = ex.Program.RightRectAngle(h, n);
            var res3 = ex.Program.TrapezoidalMethod(h, n);
            var res4 = ex.Program.SimpsonMethod(a, b, n);
            Assert.AreEqual(a1, res1);
            Assert.AreEqual(a2, res2);
            Assert.AreEqual(a3, res3);
            Assert.AreEqual(a4, res4);
        }
    }
}
