using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace GeometricShapesApp
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using static global::GeometricShapesApp.MainWindow;

    namespace GeometricShapesApp
    {
        public class TriangleShape : ShapeBase
        {

            public override Shape CreateShape(double width, double height, Color color)
            {
                var triangle = new Polygon
                {
                    Points = new PointCollection
                {
                    new Point(0, height),
                    new Point(width / 2, 0),
                    new Point(width, height)
                },
                    Fill = new SolidColorBrush(color),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                return triangle;
            }


            public override UIElement CreateShapeWithHandles(double width, double height, Color color)
            {
                var triangle = CreateShape(width, height, color);
                var shapeWrapper = new ShapeWrapper(triangle);
                return shapeWrapper.GetResizableShape();
            }
            private double CalculateTriangleArea(Polygon triangle)
            {
                var points = triangle.Points;

                double baseLength = Math.Abs(points[1].X - points[0].X);

                double height = Math.Abs(points[2].Y - points[0].Y);

                return 0.5 * baseLength * height;
            }
        }
    }
}