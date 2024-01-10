namespace lab1.Shapes
{
    public class ShapeInfoDecorator : IShape
    {
        private readonly IShape decoratedShape;

        public ShapeInfoDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public double CalculatePerimeter()
        {
            double perimeter = decoratedShape.CalculatePerimeter();
            Console.WriteLine($"Perimeter: {perimeter}");
            return perimeter;
        }

        public double CalculateArea()
        {
            double area = decoratedShape.CalculateArea();
            Console.WriteLine($"Area: {area}");
            return area;
        }

        public void Draw(Graphics graphics) => decoratedShape.Draw(graphics);

    }
}
