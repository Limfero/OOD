using lab3.Shapes;

namespace lab3.Visitor
{
    public interface IVisitor
    {
        public void Visit(TriangleShape triangle);
        public void Visit(RectangleShape rectangle);
        public void Visit(CircleShape circle);
    }
}
