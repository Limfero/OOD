namespace lab2.Shapes
{
    public class RectangleShape : IShape
    {
        private readonly Point[] _points;

        public RectangleShape(Point[] points)
        {
            _points = points;
        }

        public double CalculatePerimeter()
        {
            double side1 = Math.Abs(_points[1].X - _points[0].X);
            double side2 = Math.Abs(_points[1].Y - _points[0].Y);

            return 2 * (side1 + side2);
        }

        public double CalculateArea()
        {
            double side1 = Math.Abs(_points[1].X - _points[0].X);
            double side2 = Math.Abs(_points[1].Y - _points[0].Y);

            return side1 * side2;
        }

        public void Draw(Graphics graphics) => graphics.DrawRectangle(Pens.Black, new Rectangle(_points[0], new Size(_points[1].X - _points[0].X, _points[1].Y - _points[0].Y)));

    }
}
