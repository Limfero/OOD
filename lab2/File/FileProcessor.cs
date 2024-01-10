using lab2.Shapes;
using lab2.Shapes.Creators;

namespace lab2.File
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

                    IShapeCreator shapeCreator = GetShapeCreator(shapeType);

                    if (shapeCreator != null)
                    {
                        IShape shape = new ShapeInfoDecorator(shapeCreator.CreateShape(tokens[1]));
                        shapes.Add(shape);
                    }
                    else Console.WriteLine($"Unknown shape type: {shapeType}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return shapes;
        }

        private IShapeCreator GetShapeCreator(string shapeType)
        {
            IShapeCreator? creator = shapeType switch
            {
                "TRIANGLE" => TriangleCreator.Instance,
                "RECTANGLE" => RectangleCreator.Instance,
                "CIRCLE" => CircleCreator.Instance,
                _ => null,
            };
            return creator;
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
