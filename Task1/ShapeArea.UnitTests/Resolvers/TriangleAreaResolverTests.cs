using System;
using NUnit.Framework;
using ShapeArea.Resolvers;
using ShapeArea.Shapes;

namespace ShapeArea.UnitTests.Resolvers
{
    public class TriangleAreaResolverTests
    {
        private TriangleAreaResolver _resolver;

        [SetUp]
        public void SetUp()
        {
            _resolver = new TriangleAreaResolver();
        }

        [TestCase(5D, 4D, 6D, 9.921567416D)]
        [TestCase(5D, 4D, 6D, 9.921567416D)]
        [TestCase(12D, 15D, 8D, 47.811478747D)]
        [TestCase(0D, 0D, 0D, 0D)]
        public void Calc_CorrectTriangle_ReturnArea(double edge1, double edge2, double edge3, double expect)
        {
            var circle = new Triangle
            {
                Edge1 = edge1,
                Edge2 = edge2,
                Edge3 = edge3,
            };

            var area = _resolver.Calc(circle);

            Assert.AreEqual(expect, area, Consts.EQUAL_DELTA);
        }

        [TestCase(-1D, 1D, 1D, nameof(Triangle.Edge1))]
        [TestCase(double.NaN, 1D, 1D, nameof(Triangle.Edge1))]
        [TestCase(1D, -1D, 1D, nameof(Triangle.Edge2))]
        [TestCase(1D, double.NaN, 1D, nameof(Triangle.Edge2))]
        [TestCase(1D, 1D, -1D, nameof(Triangle.Edge3))]
        [TestCase(1D, 1D, double.NaN, nameof(Triangle.Edge3))]
        public void Calc_IncorrectEdge_ThrowsException(double edge1, double edge2, double edge3, string paramName)
        {
            var triangle = new Triangle
            {
                Edge1 = edge1,
                Edge2 = edge2,
                Edge3 = edge3,
            };

            var ex = Assert.Throws<ArgumentException>(() => _resolver.Calc(triangle));

            Assert.AreEqual(paramName, ex.ParamName);
        }

        [TestCase(10D, 1D, 1D)]
        [TestCase(1D, 10D, 1D)]
        [TestCase(1D, 1D, 10D)]
        public void Calc_IncorrectTriangle_ThrowsException(double edge1, double edge2, double edge3)
        {
            var triangle = new Triangle
            {
                Edge1 = edge1,
                Edge2 = edge2,
                Edge3 = edge3,
            };

            _ = Assert.Throws<ArgumentException>(() => _resolver.Calc(triangle));
        }

        [Test]
        public void Calc_TriangleIsNull_ThrowsException()
        {
            _ = Assert.Throws<ArgumentNullException>(() => _resolver.Calc(null));
        }
    }
}
