using System;
using System.Windows;
using System.Windows.Controls;
using SimpleCalculatorFactory.Factories;
using SimpleCalculatorFactory.Models.Buttons;
using SimpleCalculatorFactory.Services;

namespace SimpleCalculatorFactory
{
    // Главное окно калькулятора
    public partial class MainWindow : Window
    {
        // Фабрика создает нужный тип кнопки
        private readonly IButtonFactory buttonFactory;

        // Класс отвечает за вычисления
        private readonly CalculatorEngine calculatorEngine;

        // Конструктор окна
        public MainWindow()
        {
            InitializeComponent();

            buttonFactory = new ButtonFactory();
            calculatorEngine = new CalculatorEngine();
        }

        // Единый обработчик всех кнопок
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = ((Button)sender).Content.ToString();

            // Создаем объект кнопки через фабрику
            CalculatorButton calculatorButton = buttonFactory.CreateButton(content);

            // Получаем команду кнопки
            string command = calculatorButton.Press();

            try
            {
                HandleCommand(command);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Деление на ноль невозможно.");
                Display.Text = "0";
                ExpressionDisplay.Text = "";
            }
        }

        // Обработка команды
        private void HandleCommand(string command)
        {
            // Обработка цифровых кнопок
            if (int.TryParse(command, out _))
            {
                Display.Text = calculatorEngine.AddDigit(Display.Text, command);
                return;
            }

            switch (command)
            {
                case ",":
                    Display.Text = calculatorEngine.AddDecimal(Display.Text);
                    break;

                case "+":
                case "-":
                case "×":
                case "÷":
                    ExpressionDisplay.Text = Display.Text + " " + command;
                    calculatorEngine.SetOperation(Display.Text, command);
                    break;

                case "=":
                    ExpressionDisplay.Text = ExpressionDisplay.Text + " " + Display.Text + " =";
                    Display.Text = calculatorEngine.Calculate(Display.Text);
                    break;

                case "C":
                    Display.Text = calculatorEngine.Clear();
                    ExpressionDisplay.Text = "";
                    break;

                case "CE":
                    Display.Text = calculatorEngine.ClearEntry();
                    break;

                case "←":
                    Display.Text = calculatorEngine.Backspace(Display.Text);
                    break;

                case "±":
                    Display.Text = calculatorEngine.ChangeSign(Display.Text);
                    break;

                case "%":
                    Display.Text = calculatorEngine.Percent(Display.Text);
                    break;
            }
        }
    }
}