using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricShapesApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeContainer.Child = null; 

            if (ShapeSelector.SelectedItem is ComboBoxItem selectedShape)
            {
                Color color = GetColorFromSelection(((ComboBoxItem)ColorSelector.SelectedItem).Content.ToString());
                ShapeBase shapeObj = null;

                if (selectedShape.Content.ToString() == "Rectangle" &&
                    double.TryParse(Parameter1.Text, out double width) &&
                    double.TryParse(Parameter2.Text, out double height))
                {
                    shapeObj = new RectangleShape();
                    ShapeContainer.Child = shapeObj.CreateShape(width, height, color);
                }
                else if (selectedShape.Content.ToString() == "Circle" &&
                         double.TryParse(Parameter1.Text, out double radius))
                {
                    shapeObj = new CircleShape();
                    ShapeContainer.Child = shapeObj.CreateShape(radius, 0, color); 
                }
                else if (selectedShape.Content.ToString() == "Triangle" &&
                         double.TryParse(Parameter1.Text, out double baseLength) &&
                         double.TryParse(Parameter2.Text, out double triangleHeight))
                {
                    shapeObj = new TriangleShape();
                    ShapeContainer.Child = shapeObj.CreateShape(baseLength, triangleHeight, color);
                }
                else
                {
                    MessageBox.Show("Please enter valid numeric values.");
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeContainer.Child = null; 
            var result = MessageBox.Show("Are you sure you want to clear the shapes?", "Confirm Clear",
                                   MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ShapeContainer.Child = null;
            }
        }

        private Color GetColorFromSelection(string colorName)
        {
            return (Color)ColorConverter.ConvertFromString(colorName);
        }
    }
}
