namespace ShapeArea
{
    public interface IAreaResolver<in TShape>
        where TShape : IShape2D
    {
        double Calc(TShape shape);
    }
}
