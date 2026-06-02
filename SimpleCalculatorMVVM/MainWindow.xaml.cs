using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using SimpleCalculatorMVVM.ViewModels;

namespace SimpleCalculatorMVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            CreateInterface();
        }

        private void CreateInterface()
        {
            MainGrid.Margin = new Thickness(15);

            MainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(110)
            });

            MainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            CreateDisplay();
            CreateButtons();
        }

        private void CreateDisplay()
        {
            Border displayBorder = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 15)
            };

            Grid.SetRow(displayBorder, 0);

            Grid displayGrid = new Grid();

            displayGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(30)
            });

            displayGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            TextBlock expressionText = new TextBlock
            {
                FontSize = 16,
                Foreground = Brushes.Gray,
                TextAlignment = TextAlignment.Right
            };

            expressionText.SetBinding(
                TextBlock.TextProperty,
                new Binding("ExpressionDisplay"));

            Grid.SetRow(expressionText, 0);

            TextBox displayText = new TextBox
            {
                FontSize = 34,
                IsReadOnly = true,
                BorderThickness = new Thickness(0),
                Background = Brushes.Transparent,
                TextAlignment = TextAlignment.Right,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Color.FromRgb(33, 33, 33))
            };

            displayText.SetBinding(
                TextBox.TextProperty,
                new Binding("Display"));

            Grid.SetRow(displayText, 1);

            displayGrid.Children.Add(expressionText);
            displayGrid.Children.Add(displayText);

            displayBorder.Child = displayGrid;

            MainGrid.Children.Add(displayBorder);
        }

        private void CreateButtons()
        {
            Grid buttonGrid = new Grid();

            Grid.SetRow(buttonGrid, 1);

            for (int i = 0; i < 7; i++)
            {
                buttonGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 4; i++)
            {
                buttonGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            string[,] buttons =
            {
                { "sin", "cos", "tan", "cot" },
                { "MC", "MR", "M+", "%" },
                { "CE", "C", "←", "÷" },
                { "7", "8", "9", "×" },
                { "4", "5", "6", "-" },
                { "1", "2", "3", "+" },
                { "√", "0", "x²", "=" }
            };

            for (int row = 0; row < 7; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    AddButton(buttonGrid, buttons[row, column], row, column);
                }
            }

            MainGrid.Children.Add(buttonGrid);
        }

        private void AddButton(Grid grid, string text, int row, int column)
        {
            Button button = new Button
            {
                Content = text,
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5),
                BorderThickness = new Thickness(0),
                Foreground = new SolidColorBrush(Color.FromRgb(33, 33, 33)),
                Background = GetButtonColor(text)
            };

            button.SetBinding(
                Button.CommandProperty,
                new Binding("ButtonCommand"));

            button.CommandParameter = text;

            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);

            grid.Children.Add(button);
        }

        private Brush GetButtonColor(string buttonText)
        {
            if (buttonText == "0" || buttonText == "1" || buttonText == "2" ||
                buttonText == "3" || buttonText == "4" || buttonText == "5" ||
                buttonText == "6" || buttonText == "7" || buttonText == "8" ||
                buttonText == "9")
            {
                return new SolidColorBrush(Color.FromRgb(217, 217, 217));
            }

            if (buttonText == "+" || buttonText == "-" || buttonText == "×" ||
                buttonText == "÷" || buttonText == "%")
            {
                return new SolidColorBrush(Color.FromRgb(255, 183, 77));
            }

            if (buttonText == "MC" || buttonText == "MR" || buttonText == "M+")
            {
                return new SolidColorBrush(Color.FromRgb(144, 202, 249));
            }

            if (buttonText == "C" || buttonText == "CE" || buttonText == "←")
            {
                return new SolidColorBrush(Color.FromRgb(239, 154, 154));
            }

            if (buttonText == "sin" || buttonText == "cos" || buttonText == "tan" ||
                buttonText == "cot" || buttonText == "√" || buttonText == "x²")
            {
                return new SolidColorBrush(Color.FromRgb(128, 222, 234));
            }

            if (buttonText == "=")
            {
                return new SolidColorBrush(Color.FromRgb(129, 199, 132));
            }

            return Brushes.LightGray;
        }
    }
}