using lab1.Shapes;

namespace lab2.Shapes.Creators
{
    public interface IShapeCreator
    {
        IShape CreateShape(string data);
    }
}
