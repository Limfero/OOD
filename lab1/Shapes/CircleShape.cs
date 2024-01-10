namespace lab1.Shapes
{
    public class CircleShape : IShape
    {
        private readonly Point center;
        private readonly int radius;

        public CircleShape(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public double CalculatePerimeter() => 2 * Math.PI * radius;

        public double CalculateArea() => Math.PI * radius * radius;

        public void Draw(Graphics graphics) => graphics.DrawEllipse(Pens.Black, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
    }
}
