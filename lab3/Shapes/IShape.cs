using lab3.Visitor;

namespace lab3.Shapes
{
    public interface IShape
    {
        public void Accept(IVisitor visitor);
        public void Draw(Graphics graphics);
    }
}
