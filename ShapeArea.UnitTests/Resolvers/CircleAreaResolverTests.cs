using System;
using NUnit.Framework;
using ShapeArea.Resolvers;
using ShapeArea.Shapes;

namespace ShapeArea.UnitTests.Resolvers
{
    public class CircleAreaResolverTests
    {
        private CircleAreaResolver _resolver;

        [SetUp]
        public void SetUp()
        {
            _resolver = new CircleAreaResolver();
        }

        [TestCase(1D, 3.1415926535D)]
        [TestCase(10D, 314.159265358979D)]
        [TestCase(0D, 0D)]
        public void Calc_CorrectCircle_ReturnArea(double r, double expect)
        {
            var circle = new Circle
            {
                Radius = r,
            };

            var area = _resolver.Calc(circle);

            Assert.AreEqual(expect, area, Consts.EQUAL_DELTA);
        }

        [TestCase(-1D)]
        [TestCase(double.NaN)]
        public void Calc_IncorrectCircle_ThrowsException(double r)
        {
            var circle = new Circle
            {
                Radius = r,
            };

            var ex = Assert.Throws<ArgumentException>(() => _resolver.Calc(circle));

            Assert.AreEqual(nameof(Circle.Radius), ex.ParamName);
        }

        [Test]
        public void Calc_CircleIsNull_ThrowsException()
        {
            _ = Assert.Throws<ArgumentNullException>(() => _resolver.Calc(null));
        }
    }
}
