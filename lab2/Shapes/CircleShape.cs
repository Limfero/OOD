namespace lab2.Shapes
{
    public class CircleShape : IShape
    {
        private readonly Point _center;
        private readonly int _radius;

        public CircleShape(Point center, int radius)
        {
            this._center = center;
            this._radius = radius;
        }

        public double CalculatePerimeter() => 2 * Math.PI * _radius;

        public double CalculateArea() => Math.PI * _radius * _radius;

        public void Draw(Graphics graphics) => graphics.DrawEllipse(Pens.Black, _center.X - _radius, _center.Y - _radius, 2 * _radius, 2 * _radius);
    }
}
