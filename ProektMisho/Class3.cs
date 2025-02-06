using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricShapesApp
{
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using static global::GeometricShapesApp.MainWindow;

    namespace GeometricShapesApp
    {
        public class CircleShape : ShapeBase
        {

            public override Shape CreateShape(double width, double height, Color color)
            {
                var circle = new Ellipse
                {
                    Width = width,
                    Height = height,
                    Fill = new SolidColorBrush(color),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                return circle;
            }


            public override UIElement CreateShapeWithHandles(double width, double height, Color color)
            {
                var circle = CreateShape(width, height, color);
                var shapeWrapper = new ShapeWrapper(circle);
                return shapeWrapper.GetResizableShape();
            }
        }
    }
}