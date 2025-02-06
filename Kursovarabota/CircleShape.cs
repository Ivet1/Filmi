using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricShapesApp
{
    public class CircleShape : ShapeBase
    {
        public override Shape CreateShape(double width, double height, Color color)
        {
            double radius = width; 
            return new Ellipse
            {
                Width = radius * 2,
                Height = radius * 2,
                Fill = new SolidColorBrush(color),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }
    }
}