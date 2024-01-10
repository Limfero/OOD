namespace lab3.Shapes.Creators
{
    public class TriangleCreator : IShapeCreator
    {
        private static TriangleCreator _instance;
        private static int _countPoint = 3;

        private TriangleCreator() { }

        public static TriangleCreator Instance{ get { return _instance ??= new TriangleCreator(); } }

        public IShape CreateShape(string data)
        {
            string[] pointsData = data.Split(';');

            Point[] points = new Point[_countPoint];

            for (int i = 0; i < _countPoint; i++)
            {
                string[] coordinates = pointsData[i].Split('=')[1].Split(',');
                points[i] = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }

            return new TriangleShape(points);
        }
    }
}
