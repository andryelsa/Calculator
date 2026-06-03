using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using SimpleCalculatorMVVM.ViewModels;

namespace SimpleCalculatorMVVM
{
    public partial class MainWindow : Window
    {
        private AppConfig appConfig;

        public MainWindow()
        {
            InitializeComponent();

            LoadConfig();

            DataContext = new MainViewModel();

            CreateInterface();
        }

        private void LoadConfig()
        {
            try
            {
                string json = File.ReadAllText("appsettings.json");

                appConfig = JsonSerializer.Deserialize<AppConfig>(json);

                Width = appConfig.WindowWidth;
                Height = appConfig.WindowHeight;

                Background = (Brush)new BrushConverter()
                    .ConvertFromString(appConfig.BackgroundColor);
            }
            catch (Exception ex)
            {
                appConfig = new AppConfig
                {
                    WindowWidth = 420,
                    WindowHeight = 700,
                    BackgroundColor = "#F2F4F8",
                    FontSize = 20,
                    DatabaseConnection = "Server=localhost;Database=CalculatorDb;Trusted_Connection=True;",
                    AccessibilityTheme = "Light",
                    GenderTheme = "Male",
                    AgeTheme = "Youth"
                };

                Width = appConfig.WindowWidth;
                Height = appConfig.WindowHeight;

                Background = (Brush)new BrushConverter()
                    .ConvertFromString(appConfig.BackgroundColor);

                MessageBox.Show(
                    "Ошибка загрузки конфигурации:\n" + ex.Message,
                    "Конфигурация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void CreateInterface()
        {
            MainGrid.Margin = new Thickness(15);

            MainGrid.RowDefinitions.Clear();
            MainGrid.Children.Clear();

            MainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(30)
            });

            MainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(110)
            });

            MainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            CreateMenu();
            CreateDisplay();
            CreateButtons();
        }

        private void CreateMenu()
        {
            MessageBox.Show("CreateMenu работает");

            Menu menu = new Menu();

            MenuItem fileMenu = new MenuItem
            {
                Header = "Файл"
            };

            MenuItem exitItem = new MenuItem
            {
                Header = "Выход"
            };

            exitItem.Click += (sender, e) => Close();

            fileMenu.Items.Add(exitItem);

            MenuItem helpMenu = new MenuItem
            {
                Header = "Справка"
            };

            MenuItem aboutItem = new MenuItem
            {
                Header = "О программе"
            };

            aboutItem.Click += (sender, e) =>
            {
                AboutWindow aboutWindow = new AboutWindow();
                aboutWindow.Owner = this;
                aboutWindow.ShowDialog();
            };

            helpMenu.Items.Add(aboutItem);

            menu.Items.Add(fileMenu);
            MenuItem settingsMenu = new MenuItem
            {
                Header = "Настройки"
            };

            MenuItem darkTheme = new MenuItem
            {
                Header = "Темная тема"
            };

            darkTheme.Click += (s, e) =>
            {
                appConfig.AccessibilityTheme = "Dark";
                SaveConfig();
                ApplyConfig();
            };

            MenuItem lightTheme = new MenuItem
            {
                Header = "Светлая тема"
            };

            lightTheme.Click += (s, e) =>
            {
                appConfig.AccessibilityTheme = "Light";
                SaveConfig();
                ApplyConfig();
            };

            MenuItem maleTheme = new MenuItem
            {
                Header = "Мужской стиль"
            };

            maleTheme.Click += (s, e) =>
            {
                appConfig.GenderTheme = "Male";
                SaveConfig();
                ApplyConfig();
            };

            MenuItem femaleTheme = new MenuItem
            {
                Header = "Женский стиль"
            };

            femaleTheme.Click += (s, e) =>
            {
                appConfig.GenderTheme = "Female";
                SaveConfig();
                ApplyConfig();
            };

            MenuItem childTheme = new MenuItem
            {
                Header = "Детский"
            };

            childTheme.Click += (s, e) =>
            {
                appConfig.AgeTheme = "Child";
                SaveConfig();
                ApplyConfig();
            };

            MenuItem seniorTheme = new MenuItem
            {
                Header = "Пожилые"
            };

            seniorTheme.Click += (s, e) =>
            {
                appConfig.AgeTheme = "Senior";
                SaveConfig();
                ApplyConfig();
            };

            settingsMenu.Items.Add(lightTheme);
            settingsMenu.Items.Add(darkTheme);
            settingsMenu.Items.Add(new Separator());
            settingsMenu.Items.Add(maleTheme);
            settingsMenu.Items.Add(femaleTheme);
            settingsMenu.Items.Add(new Separator());
            settingsMenu.Items.Add(childTheme);
            settingsMenu.Items.Add(seniorTheme);

            menu.Items.Add(settingsMenu);
            menu.Items.Add(helpMenu);

            Grid.SetRow(menu, 0);
            MainGrid.Children.Add(menu);
        }

        private void CreateDisplay()
        {
            Border displayBorder = new Border
            {
                Background = GetDisplayBackground(),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 15)
            };

            Grid.SetRow(displayBorder, 1);

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
                Foreground = GetSecondaryTextColor(),
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
                Foreground = GetMainTextColor()
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
            Grid.SetRow(buttonGrid, 2);

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
                FontSize = GetConfiguredFontSize(),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5),
                BorderThickness = new Thickness(0),
                Foreground = GetMainTextColor(),
                Background = GetButtonColor(text),
                Cursor = Cursors.Hand
            };

            button.SetBinding(
                Button.CommandProperty,
                new Binding("ButtonCommand"));

            button.CommandParameter = text;

            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);

            grid.Children.Add(button);
        }

        private double GetConfiguredFontSize()
        {
            if (appConfig.AgeTheme == "Child")
                return 26;

            if (appConfig.AgeTheme == "Senior")
                return 30;

            if (appConfig.AgeTheme == "Adult")
                return 20;

            return appConfig.FontSize;
        }

        private bool IsDarkTheme()
        {
            return appConfig.AccessibilityTheme == "Dark";
        }

        private Brush GetDisplayBackground()
        {
            if (IsDarkTheme())
                return new SolidColorBrush(Color.FromRgb(45, 45, 45));

            return Brushes.White;
        }

        private Brush GetMainTextColor()
        {
            if (IsDarkTheme())
                return Brushes.White;

            return new SolidColorBrush(Color.FromRgb(33, 33, 33));
        }

        private Brush GetSecondaryTextColor()
        {
            if (IsDarkTheme())
                return Brushes.LightGray;

            return Brushes.Gray;
        }

        private Brush GetButtonColor(string buttonText)
        {
            if (appConfig.AgeTheme == "Child")
            {
                return new SolidColorBrush(Color.FromRgb(255, 224, 130));
            }

            if (appConfig.AgeTheme == "Senior")
            {
                return new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }

            if (appConfig.GenderTheme == "Female")
            {
                if (buttonText == "=")
                    return new SolidColorBrush(Color.FromRgb(244, 143, 177));

                return new SolidColorBrush(Color.FromRgb(248, 187, 208));
            }

            if (appConfig.GenderTheme == "Male")
            {
                if (buttonText == "+" || buttonText == "-" || buttonText == "×" ||
                    buttonText == "÷" || buttonText == "%")
                    return new SolidColorBrush(Color.FromRgb(100, 181, 246));
            }

            if (IsDarkTheme())
            {
                if (buttonText == "=")
                    return new SolidColorBrush(Color.FromRgb(76, 175, 80));

                return new SolidColorBrush(Color.FromRgb(80, 80, 80));
            }

            if (buttonText == "0" || buttonText == "1" || buttonText == "2" ||
                buttonText == "3" || buttonText == "4" || buttonText == "5" ||
                buttonText == "6" || buttonText == "7" || buttonText == "8" ||
                buttonText == "9")
                return new SolidColorBrush(Color.FromRgb(217, 217, 217));

            if (buttonText == "+" || buttonText == "-" || buttonText == "×" ||
                buttonText == "÷" || buttonText == "%")
                return new SolidColorBrush(Color.FromRgb(255, 183, 77));

            if (buttonText == "MC" || buttonText == "MR" || buttonText == "M+")
                return new SolidColorBrush(Color.FromRgb(144, 202, 249));

            if (buttonText == "C" || buttonText == "CE" || buttonText == "←")
                return new SolidColorBrush(Color.FromRgb(239, 154, 154));

            if (buttonText == "=")
                return new SolidColorBrush(Color.FromRgb(129, 199, 132));

            return new SolidColorBrush(Color.FromRgb(128, 222, 234));
        }
        private void SaveConfig()
        {
            string json = JsonSerializer.Serialize(
                appConfig,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText("appsettings.json", json);
        }

        private void ApplyConfig()
        {
            MainGrid.Children.Clear();
            MainGrid.RowDefinitions.Clear();

            Background = (Brush)new BrushConverter()
                .ConvertFromString(appConfig.BackgroundColor);

            CreateInterface();
        }
    }
}