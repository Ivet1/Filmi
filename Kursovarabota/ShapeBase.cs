using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricShapesApp
{
    public abstract class ShapeBase
    {
        public abstract Shape CreateShape(double width, double height, Color color);
    }
}