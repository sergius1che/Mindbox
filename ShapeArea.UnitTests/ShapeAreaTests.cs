using NUnit.Framework;
using ShapeArea.Shapes;

namespace ShapeArea.UnitTests
{
    public class Shape2DAreaTests
    {
        [TestCase(10D, 314.15926535D)]
        [TestCase(12D, 452.38934210D)]
        [TestCase(12.231D, 469.9739703D)]
        [TestCase(0.001D, 0.00000314D)]
        [TestCase(0D, 0D)]
        public void Calc_Circle_ReturnedArea(double r, double expect)
        {
            var circle = new Circle
            {
                Radius = r,
            };

            var area = Shape2DArea.Instance.Calc(circle);

            Assert.AreEqual(expect, area, Consts.EQUAL_DELTA);
        }

        [TestCase(4D, 5D, 3D, 6D)]
        [TestCase(40D, 50D, 30D, 600D)]
        [TestCase(0.4D, 0.5D, 0.3D, 0.06D)]
        [TestCase(6D, 9D, 4D, 9.562295749D)]
        public void Calc_Triangle_ReturnedArea(double edge1, double edge2, double edge3, double expect)
        {
            var triangle = new Triangle
            {
                Edge1 = edge1,
                Edge2 = edge2,
                Edge3 = edge3,
            };

            var area = Shape2DArea.Instance.Calc(triangle);

            Assert.AreEqual(expect, area, Consts.EQUAL_DELTA);
        }
    }
}