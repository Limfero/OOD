using lab2.Shapes;

namespace lab2.Shapes.Creators
{
    public interface IShapeCreator
    {
        public IShape CreateShape(string data);
    }
}
