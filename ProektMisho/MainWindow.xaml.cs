using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace GeometricShapesApp
{
    public partial class MainWindow : Window
    {
        private Stack<Action> commandHistory = new Stack<Action>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private List<UIElement> _shapes = new List<UIElement>();

        private void ShapeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShapeSelector.SelectedItem is ComboBoxItem selectedShape)
            {
                if (selectedShape.Content.ToString() == "Rectangle")
                {
                    Parameter1.Text = "Width";
                    Parameter2.Visibility = Visibility.Visible;
                    Parameter2.Text = "Height";
                }
                else if (selectedShape.Content.ToString() == "Circle")
                {
                    Parameter1.Text = "Radius";
                    Parameter2.Visibility = Visibility.Collapsed;
                }
                else if (selectedShape.Content.ToString() == "Triangle")
                {
                    Parameter1.Text = "Base Length";
                    Parameter2.Visibility = Visibility.Visible;
                    Parameter2.Text = "Height";
                }
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (_shapes.Count > 0)
            {
                var lastShape = _shapes[_shapes.Count - 1];
                ShapeContainer.Children.Remove(lastShape);
                _shapes.RemoveAt(_shapes.Count - 1);
            }
        }


        private void SaveShapes(string filePath)
        {
            var shapes = ShapeContainer.Children
                .OfType<Shape>()
                .Select(shape => new ShapeData
                {
                    ShapeType = shape.GetType().Name,
                    Width = shape.Width,
                    Height = shape.Height,
                    Color = ((SolidColorBrush)shape.Fill)?.Color.ToString() ?? "Transparent"
                })
                .ToList();

            var json = JsonSerializer.Serialize(shapes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            MessageBox.Show("Shapes saved successfully.");
        }
        private void CountShapes_Click(object sender, RoutedEventArgs e)
        {

            var shapeGroups = ShapeContainer.Children
                .OfType<Shape>()
                .GroupBy(shape => shape.GetType().Name)
                .Select(group => new { ShapeType = group.Key, Count = group.Count() });


            string message = "Shape counts:\n";
            foreach (var group in shapeGroups)
            {
                message += $"{group.ShapeType}: {group.Count}\n";
            }


            MessageBox.Show(message);
        }
        private void DisplayShapesSortedByArea_Click(object sender, RoutedEventArgs e)
        {

            var sortedShapes = ShapeContainer.Children
                .OfType<Shape>()
                .OrderBy(shape => shape.Width * shape.Height);


            string message = "Shapes sorted by area:\n";
            foreach (var shape in sortedShapes)
            {
                message += $"{shape.GetType().Name} - Area: {shape.Width * shape.Height}\n";
            }


            MessageBox.Show(message);
        }
        private void ListShapes_Click(object sender, RoutedEventArgs e)
        {

            var shapes = ShapeContainer.Children.OfType<Shape>();

            if (!shapes.Any())
            {
                MessageBox.Show("There are no shapes in the container.");
                return;
            }


            string message = "Shapes in the container:\n";
            foreach (var shape in shapes)
            {
                string shapeType = shape.GetType().Name;
                double width = shape.Width;
                double height = shape.Height;
                message += $"{shapeType} - Width: {width}, Height: {height}\n";
            }


            MessageBox.Show(message);
        }



        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeContainer.Children.Clear();
            _shapes.Clear();
        }



        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            double width = double.Parse(Parameter1.Text);
            double height = double.Parse(Parameter2.Text);


            Color color = Colors.Red;
            if (ColorSelector.SelectedItem is ComboBoxItem colorItem)
            {
                string colorName = colorItem.Content.ToString();
                color = (Color)ColorConverter.ConvertFromString(colorName);
            }

            UIElement newShape = null;

            if (ShapeSelector.SelectedItem is ComboBoxItem selectedShape)
            {
                if (selectedShape.Content.ToString() == "Rectangle")
                {
                    newShape = new Rectangle { Width = width, Height = height, Fill = new SolidColorBrush(color) };
                }
                else if (selectedShape.Content.ToString() == "Circle")
                {
                    newShape = new Ellipse { Width = width, Height = width, Fill = new SolidColorBrush(color) };
                }
                else if (selectedShape.Content.ToString() == "Triangle")
                {
                    newShape = new Polygon
                    {
                        Points = new PointCollection
                {
                    new Point(width / 2, 0),
                    new Point(0, height),
                    new Point(width, height)
                },
                        Fill = new SolidColorBrush(color)
                    };
                }

                if (newShape != null)
                {
                    double leftPosition = 50 + _shapes.Count * (width + 10);
                    double topPosition = 50;

                    Canvas.SetLeft(newShape, leftPosition);
                    Canvas.SetTop(newShape, topPosition);

                    ShapeContainer.Children.Add(newShape);
                    _shapes.Add(newShape);

                    AddDragAndResizeHandlers(newShape);
                }
            }
        }

        private void AddDragAndResizeHandlers(UIElement shape)
        {
            Point _initialMousePosition = new Point();
            double _initialLeft = 0;
            double _initialTop = 0;

            shape.MouseLeftButtonDown += (sender, e) =>
            {
                _initialMousePosition = e.GetPosition(ShapeContainer);
                _initialLeft = Canvas.GetLeft(shape);
                _initialTop = Canvas.GetTop(shape);
                shape.CaptureMouse();
            };

            shape.MouseMove += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    double deltaX = e.GetPosition(ShapeContainer).X - _initialMousePosition.X;
                    double deltaY = e.GetPosition(ShapeContainer).Y - _initialMousePosition.Y;

                    Canvas.SetLeft(shape, _initialLeft + deltaX);
                    Canvas.SetTop(shape, _initialTop + deltaY);


                    if (shape is FrameworkElement element)
                    {

                        if (shape is Rectangle || shape is Ellipse)
                        {
                            element.Width = Math.Max(20, element.Width + deltaX);
                            element.Height = Math.Max(20, element.Height + deltaY);
                        }

                        else if (shape is Polygon triangle)
                        {
                            var points = triangle.Points;


                            double baseLength = Math.Max(20, points[1].X - points[0].X + deltaX);
                            double height = Math.Max(20, points[1].Y - points[0].Y + deltaY);

                            points[1] = new Point(points[0].X + baseLength, points[0].Y);
                            points[2] = new Point(points[0].X + baseLength, points[0].Y + height);

                            triangle.Points = points;
                        }
                    }
                }
            };

            shape.MouseLeftButtonUp += (sender, e) =>
            {
                shape.ReleaseMouseCapture();
            };
        }


        private double CalculateTriangleArea(Polygon triangle)
        {
            var points = triangle.Points;

            double baseLength = Math.Abs(points[1].X - points[0].X);

            double height = Math.Abs(points[2].Y - points[0].Y);

            return 0.5 * baseLength * height;
        }



        private Color GetColorFromSelection(string colorName)
        {
            return (Color)ColorConverter.ConvertFromString(colorName);
        }


        public class ShapeWrapper
        {
            private readonly Shape _shape;
            private readonly Thumb _resizeThumb;
            private Point _initialMousePosition;
            private double _initialLeft;
            private double _initialTop;

            public ShapeWrapper(Shape shape)
            {
                _shape = shape ?? throw new ArgumentNullException(nameof(shape));

                _resizeThumb = new Thumb
                {
                    Width = 10,
                    Height = 10,
                    Background = Brushes.Black,
                    Cursor = Cursors.SizeNWSE
                };

                _resizeThumb.DragDelta += ResizeThumb_DragDelta;

                _shape.MouseLeftButtonDown += Shape_MouseLeftButtonDown;
                _shape.MouseMove += Shape_MouseMove;
                _shape.MouseLeftButtonUp += Shape_MouseLeftButtonUp;
            }

            public virtual UIElement GetResizableShape()

            {
                var container = new Canvas();


                if (_shape.Parent != null)
                {
                    ((Panel)_shape.Parent).Children.Remove(_shape);
                }
                if (_resizeThumb.Parent != null)
                {
                    ((Panel)_resizeThumb.Parent).Children.Remove(_resizeThumb);
                }


                Canvas.SetLeft(_shape, 0);
                Canvas.SetTop(_shape, 0);
                container.Children.Add(_shape);


                Canvas.SetLeft(_resizeThumb, 0);
                Canvas.SetTop(_resizeThumb, 0);
                container.Children.Add(_resizeThumb);

                return container;
            }

            private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                _initialMousePosition = e.GetPosition((UIElement)sender);
                _initialLeft = Canvas.GetLeft(_shape);
                _initialTop = Canvas.GetTop(_shape);

                _shape.CaptureMouse();
            }

            private void Shape_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var currentMousePosition = e.GetPosition((UIElement)sender);
                    var deltaX = currentMousePosition.X - _initialMousePosition.X;
                    var deltaY = currentMousePosition.Y - _initialMousePosition.Y;

                    Canvas.SetLeft(_shape, _initialLeft + deltaX);
                    Canvas.SetTop(_shape, _initialTop + deltaY);
                }
            }

            private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                _shape.ReleaseMouseCapture();
            }

            private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
            {
                double deltaX = e.HorizontalChange;
                double deltaY = e.VerticalChange;

                double newWidth = Math.Max(10, _shape.Width + deltaX * 2);
                double newHeight = Math.Max(10, _shape.Height + deltaY * 2);

                _shape.Width = newWidth;
                _shape.Height = newHeight;

                Canvas.SetLeft(_resizeThumb, _shape.Width - _resizeThumb.Width / 2);
                Canvas.SetTop(_resizeThumb, _shape.Height - _resizeThumb.Height / 2);
            }
        }






    }
}