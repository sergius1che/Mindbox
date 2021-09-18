using System;
using ShapeArea.Shapes;

namespace ShapeArea.Resolvers
{
    public class CircleAreaResolver : IAreaResolver<Circle>
    {
        public double Calc(Circle shape)
        {
            Check(shape);

            return Math.PI * shape.Radius * shape.Radius;
        }

        private void Check(Circle shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            if (shape.Radius < 0D || double.IsNaN(shape.Radius))
            {
                throw new ArgumentException("Value must be positive", nameof(shape.Radius));
            }
        }
    }
}
