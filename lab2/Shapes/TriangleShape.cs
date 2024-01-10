namespace lab1.Shapes
{
    public class TriangleShape : IShape
    {
        private readonly Point[] _points;

        public TriangleShape(Point[] points)
        {
            _points = points;
        }

        public double CalculatePerimeter()
        {
            double side1 = Distance(_points[0], _points[1]);
            double side2 = Distance(_points[1], _points[2]);
            double side3 = Distance(_points[2], _points[0]);

            return side1 + side2 + side3;
        }

        public double CalculateArea()
        {
            double semiPerimeter = CalculatePerimeter() / 2;
            double side1 = Distance(_points[0], _points[1]);
            double side2 = Distance(_points[1], _points[2]);
            double side3 = Distance(_points[2], _points[0]);

            return Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
        }

        public void Draw(Graphics graphics) => graphics.DrawPolygon(Pens.Black, _points);

        private double Distance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
