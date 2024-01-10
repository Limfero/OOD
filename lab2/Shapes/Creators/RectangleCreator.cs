using lab1.Shapes;

namespace lab2.Shapes.Creators
{
    public class RectangleCreator : IShapeCreator
    {
        private static RectangleCreator _instance;
        private readonly int _countPoint = 2;

        private RectangleCreator() { }

        public static RectangleCreator Instance { get { return _instance ??= new RectangleCreator(); } } 
 
        public IShape CreateShape(string data)
        {
            string[] pointsData = data.Split(';');

            Point[] points = new Point[_countPoint];

            for (int i = 0; i < _countPoint; i++)
            {
                string[] coordinates = pointsData[i].Split('=')[1].Split(',');
                points[i] = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }

            return new RectangleShape(points);
        }
    }
}
