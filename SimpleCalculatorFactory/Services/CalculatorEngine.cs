using System;

namespace SimpleCalculatorFactory.Services
{
    // Класс, отвечающий за логику вычислений калькулятора
    public class CalculatorEngine
    {
        // Первое число
        private double firstNumber;

        // Выбранная операция
        private string operation = "";

        // Флаг начала ввода нового числа
        public bool IsNewNumber { get; private set; } = true;

        // Метод ввода цифры
        public string AddDigit(string currentText, string digit)
        {
            if (currentText == "0" || IsNewNumber)
            {
                IsNewNumber = false;
                return digit;
            }

            return currentText + digit;
        }

        // Метод добавления десятичной запятой
        public string AddDecimal(string currentText)
        {
            if (IsNewNumber)
            {
                IsNewNumber = false;
                return "0,";
            }

            if (!currentText.Contains(","))
            {
                return currentText + ",";
            }

            return currentText;
        }

        // Метод выбора операции
        public void SetOperation(string currentText, string selectedOperation)
        {
            firstNumber = Convert.ToDouble(currentText);
            operation = selectedOperation;
            IsNewNumber = true;
        }

        // Метод вычисления результата
        public string Calculate(string currentText)
        {
            double secondNumber = Convert.ToDouble(currentText);
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
                        throw new DivideByZeroException();
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            IsNewNumber = true;
            return result.ToString();
        }

        // Полная очистка калькулятора
        public string Clear()
        {
            firstNumber = 0;
            operation = "";
            IsNewNumber = true;

            return "0";
        }

        // Очистка только текущего ввода
        public string ClearEntry()
        {
            IsNewNumber = true;
            return "0";
        }

        // Удаление последнего символа
        public string Backspace(string currentText)
        {
            if (currentText.Length > 1 && !IsNewNumber)
            {
                return currentText.Substring(0, currentText.Length - 1);
            }

            IsNewNumber = true;
            return "0";
        }

        // Изменение знака числа
        public string ChangeSign(string currentText)
        {
            if (currentText == "0")
            {
                return currentText;
            }

            if (currentText.StartsWith("-"))
            {
                return currentText.Substring(1);
            }

            return "-" + currentText;
        }

        // Вычисление процента
        public string Percent(string currentText)
        {
            double number = Convert.ToDouble(currentText);
            number = number / 100;

            IsNewNumber = true;
            return number.ToString();
        }
    }
}