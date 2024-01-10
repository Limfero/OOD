namespace lab1.Shapes
{
    public class ShapeInfoDecorator : IShape
    {
        private readonly IShape _decoratedShape;

        private readonly string _outputFilePath = "output.txt";

        public ShapeInfoDecorator(IShape decoratedShape)
        {
            this._decoratedShape = decoratedShape;
        }

        public double CalculatePerimeter()
        {
            double perimeter = _decoratedShape.CalculatePerimeter();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"{_decoratedShape.GetType().Name} - Perimeter: {perimeter} ");
            writer.Close();

            return perimeter;
        }

        public double CalculateArea()
        {
            double area = _decoratedShape.CalculateArea();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"Area: {area} \n");
            writer.Close();

            return area;
        }

        public void Draw(Graphics graphics) => _decoratedShape.Draw(graphics);

    }
}
