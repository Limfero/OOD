namespace lab1.Shapes
{
    public class ShapeInfoDecorator : IShape
    {
        private readonly IShape decoratedShape;

        private readonly string _outputFilePath = "output.txt";

        public ShapeInfoDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public double CalculatePerimeter()
        {
            double perimeter = decoratedShape.CalculatePerimeter();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"{decoratedShape.GetType().Name} - Perimeter: {perimeter} ");
            writer.Close();

            return perimeter;
        }

        public double CalculateArea()
        {
            double area = decoratedShape.CalculateArea();

            using StreamWriter writer = new(_outputFilePath, true);
            writer.Write($"Area: {area} \n");
            writer.Close();

            return area;
        }

        public void Draw(Graphics graphics) => decoratedShape.Draw(graphics);

    }
}
