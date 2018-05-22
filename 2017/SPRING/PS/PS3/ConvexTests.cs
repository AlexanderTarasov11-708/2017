using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConvexHull
{
    class ConvexTests
    {
        List<Point> points = new List<Point>
            {
                new Point(6, -6),
                new Point(-5, -10),
                new Point(1, 2),
                new Point(5, 3),
                new Point(0, -2),
                new Point(-2, 0)
            };

        //метод Грэхема
        [Test]
        public void GrahamTest()
        {
            var expected = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6),
                new Point(5, 3),
                new Point(1, 2),
                new Point(-2, 0)
            };
            var res = Algorithms.Graham(points);
            Assert.AreEqual(expected, res);
        }

        //метод Джарвиса
        [Test]
        public void JarvisTest()
        {
            var expected = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6),
                new Point(5, 3),
                new Point(1, 2),
                new Point(-2, 0)
            };
            var res = Algorithms.Jarvis(points);
            Assert.AreEqual(expected, res);
        }

        //нахождение самой левой точки в множестве
        [Test]
        public void FindingLeftPoint()
        {
            var indexArray = Algorithms.Range(points.Count);
            Algorithms.FindLeft(points, indexArray);
            Assert.AreEqual(new Point(-5,-10), points[indexArray[0]]);
        }

        [Test]
        public void WhatSide()
        {
            Assert.AreEqual(true, Algorithms.Rotate(points[2], points[1], points[5]) < 0);
        }

        //если в множестве только 2 точки методом Джарвиса
        [Test]
        public void TwoPointsGraham()
        {
            var twoPoints = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6)
            };
            var expected = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6)
            };
            var res = Algorithms.Graham(twoPoints);
            Assert.AreEqual(expected, res);
        }

        //если в множестве только 2 точки методом Джарвиса
        [Test]
        public void TwoPointsJarvis()
        {
            var twoPoints = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6)
            };
            var expected = new List<Point>
            {
                new Point(-5, -10),
                new Point(6, -6)
            };
            var res = Algorithms.Jarvis(twoPoints);
            Assert.AreEqual(expected, res);
        }
    }
}
