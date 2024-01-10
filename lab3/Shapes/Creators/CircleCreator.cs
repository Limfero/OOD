namespace lab3.Shapes.Creators
{
    public class CircleCreator : IShapeCreator
    {
        private static CircleCreator _instance;

        private CircleCreator() { }

        public static CircleCreator Instance { get { return _instance ??= new CircleCreator(); } }

        public IShape CreateShape(string data)
        {
            string[] parameters = data.Split(';');
            string[] coordinates = parameters[0].Split('=')[1].Split(',');
            var center = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            var radius = int.Parse(parameters[1].Split('=')[1]);

            return new CircleShape(center, radius);
        }
    }
}
