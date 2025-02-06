using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static GeometricShapesApp.MainWindow;

namespace GeometricShapesApp
{
    public class RectangleShape : ShapeBase
    {

        public override Shape CreateShape(double width, double height, Color color)
        {
            var rectangle = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(color),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            return rectangle;
        }


        public override UIElement CreateShapeWithHandles(double width, double height, Color color)
        {
            var rectangle = CreateShape(width, height, color);
            var shapeWrapper = new ShapeWrapper(rectangle);
            return shapeWrapper.GetResizableShape();
        }
    }
}