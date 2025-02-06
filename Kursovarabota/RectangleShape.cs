using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricShapesApp
{
    public class RectangleShape : ShapeBase
    {
        public override Shape CreateShape(double width, double height, Color color)
        {
            return new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(color),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
        }
    }
}