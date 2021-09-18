using System;
using ShapeArea.Shapes;

namespace ShapeArea.Resolvers
{
    public class TriangleAreaResolver : IAreaResolver<Triangle>
    {
        public double Calc(Triangle shape)
        {
            Check(shape);

            var p = (shape.Edge1 + shape.Edge2 + shape.Edge3) / 2D;
            return Math.Sqrt(p * (p - shape.Edge1) * (p - shape.Edge2) * (p - shape.Edge3));
        }

        private void Check(Triangle shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            EdgeCheck(shape.Edge1, nameof(shape.Edge1));

            EdgeCheck(shape.Edge2, nameof(shape.Edge2));

            EdgeCheck(shape.Edge3, nameof(shape.Edge3));

            EdgeCheck(shape.Edge1, shape.Edge2 + shape.Edge3);

            EdgeCheck(shape.Edge2, shape.Edge3 + shape.Edge1);

            EdgeCheck(shape.Edge3, shape.Edge1 + shape.Edge2);
        }

        private void EdgeCheck(double edge, string name)
        {
            if (edge < 0D || double.IsNaN(edge))
            {
                throw new ArgumentException("Value must be positive", name);
            }
        }

        private void EdgeCheck(double edge, double sumOther)
        {
            if (edge > sumOther)
            {
                throw new ArgumentException("Triangle can't exist");
            }
        }
    }
}
