using lab1.Shapes;

namespace lab2.Shapes
{
    public class ShapeInfoDecorator : ShapeDecorator
    {
        private readonly string _outputFilePath = "output.txt";

        public ShapeInfoDecorator(IShape decoratee) : base(decoratee) { }

        public override double CalculatePerimeter()
        {
            double perimeter = _decoratee.CalculatePerimeter();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"{_decoratee.GetType().Name} - Perimeter: {perimeter} ");
            writer.Close();

            return perimeter;
        }

        public override double CalculateArea()
        {
            double area = _decoratee.CalculateArea();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"Area: {area} \n");
            writer.Close();

            return area;
        }

        public override void Draw(Graphics graphics) => _decoratee.Draw(graphics);

    }
}
