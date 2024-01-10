using lab1.Shapes;
using lab2.Shapes;

namespace lab1.File
{
    public class FileProcessor
    {
        private readonly string _outputFilePath = "output.txt";

        public List<IShape> ReadShapes(string filePath)
        {
            List<IShape> shapes = new();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(':');
                    string shapeType = tokens[0].Trim().ToUpper();

                    switch (shapeType)
                    {
                        case "TRIANGLE":
                            shapes.Add(ParseTriangle(tokens[1]));
                            break;

                        case "RECTANGLE":
                            shapes.Add(ParseRectangle(tokens[1]));
                            break;

                        case "CIRCLE":
                            shapes.Add(ParseCircle(tokens[1]));
                            break;

                        default:
                            Console.WriteLine($"Unknown shape type: {shapeType}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return shapes;
        }

        private IShape ParseTriangle(string data)
        {
            string[] pointsData = data.Split(';');
            Point[] points = new Point[3];

            for (int i = 0; i < 3; i++)
            {
                string[] coordinates = pointsData[i].Split('=')[1].Split(',');
                points[i] = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }

            return new ShapeInfoDecorator(new TriangleShape(points));
        }

        private IShape ParseRectangle(string data)
        {
            string[] pointsData = data.Split(';');
            Point[] points = new Point[2];

            for (int i = 0; i < 2; i++)
            {
                string[] coordinates = pointsData[i].Split('=')[1].Split(',');
                points[i] = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }

            return new ShapeInfoDecorator(new RectangleShape(points));
        }

        private IShape ParseCircle(string data)
        {
            string[] parameters = data.Split(';');
            string[] coordinates = parameters[0].Split('=')[1].Split(',');
            Point center = new(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            int radius = int.Parse(parameters[1].Split('=')[1]);

            return new ShapeInfoDecorator(new CircleShape(center, radius));
        }

        public void WriteResults(List<IShape> shapes)
        {
            try
            {
                using StreamWriter writer = new(_outputFilePath);
                writer.WriteLine($"Result:");
                writer.Close();

                foreach (IShape shape in shapes)
                {
                    shape.CalculatePerimeter();
                    shape.CalculateArea();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing results: {ex.Message}");
            }
        }
    }
}
