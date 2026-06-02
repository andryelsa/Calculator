using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    // Главный класс окна калькулятора
    public partial class MainWindow : Window
    {
        // Первое число
        private double firstNumber;

        // Операция
        private string operation = "";

        // Флаг нового числа
        private bool isNewNumber = true;

        // Конструктор
        public MainWindow()
        {
            InitializeComponent();
        }

        // Ввод цифр
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string number = ((Button)sender).Content.ToString();

            if (Display.Text == "0" || isNewNumber)
            {
                Display.Text = number;
                isNewNumber = false;
            }
            else
            {
                Display.Text += number;
            }
        }

        // Десятичная запятая
        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (isNewNumber)
            {
                Display.Text = "0,";
                isNewNumber = false;
                return;
            }

            if (!Display.Text.Contains(","))
            {
                Display.Text += ",";
            }
        }

        // Операции
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(Display.Text);

            operation = ((Button)sender).Content.ToString();

            isNewNumber = true;
        }

        // Вычисление результата
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = Convert.ToDouble(Display.Text);

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "×":
                    result = firstNumber * secondNumber;
                    break;

                case "÷":

                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Деление на ноль невозможно.");
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            Display.Text = result.ToString();

            isNewNumber = true;
        }

        // Полная очистка
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = "";
            isNewNumber = true;
        }

        // Очистка текущего ввода
        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            isNewNumber = true;
        }

        // Удаление последнего символа
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 1 && !isNewNumber)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
                isNewNumber = true;
            }
        }
    }
}