namespace lab1.Shapes
{
    public class RectangleShape : IShape
    {
        private readonly Point[] points;

        public RectangleShape(Point[] points)
        {
            if (points.Length != 2)
                throw new ArgumentException("A rectangle must have exactly 2 points.");

            this.points = points;
        }

        public double CalculatePerimeter()
        {
            double side1 = Math.Abs(points[1].X - points[0].X);
            double side2 = Math.Abs(points[1].Y - points[0].Y);

            return 2 * (side1 + side2);
        }

        public double CalculateArea()
        {
            double side1 = Math.Abs(points[1].X - points[0].X);
            double side2 = Math.Abs(points[1].Y - points[0].Y);

            return side1 * side2;
        }

        public void Draw(Graphics graphics) => graphics.DrawRectangle(Pens.Black, new Rectangle(points[0], new Size(points[1].X - points[0].X, points[1].Y - points[0].Y)));
    }
}
