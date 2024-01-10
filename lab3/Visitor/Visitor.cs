using lab3.Shapes;

namespace lab3.Visitor
{
    public class Visitor : IVisitor
    {
        private readonly StreamWriter _writer;

        public Visitor() { }

        public Visitor(StreamWriter writer)
        {
            _writer = writer;
        }

        public void Visit(TriangleShape triangle)
        {
            double perimeter = triangle.CalculatePerimeter();
            double area = triangle.CalculateArea();
            DisplayResults(triangle, perimeter, area);
        }

        public void Visit(RectangleShape rectangle)
        {
            double perimeter = rectangle.CalculatePerimeter();
            double area = rectangle.CalculateArea();
            DisplayResults(rectangle, perimeter, area);
        }

        public void Visit(CircleShape circle)
        {
            double perimeter = circle.CalculatePerimeter();
            double area = circle.CalculateArea();
            DisplayResults(circle, perimeter, area);
        }

        private void DisplayResults(IShape shape, double perimeter, double area)
        {
            string result = $"{shape.GetType().Name} - Perimeter:{perimeter}; Area:{area}";

            if (_writer != null) _writer.WriteLine(result);
            else Console.WriteLine(result);
        }
    }
}
