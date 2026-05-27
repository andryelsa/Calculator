using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double firstNumber;
        private string operation = "";
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(Display.Text);
            operation = ((Button)sender).Content.ToString();
            isNewNumber = true;
        }

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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = "";
            isNewNumber = true;
        }

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