using lab1.Shapes;

namespace lab2.Shapes
{
    public abstract class ShapeDecorator : IShape
    {
        protected readonly IShape _decoratee;

        public ShapeDecorator(IShape decoratee)
        {
            _decoratee = decoratee;
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public abstract void Draw(Graphics graphics);
    }
}
