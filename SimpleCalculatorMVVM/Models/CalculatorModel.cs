using System;

namespace SimpleCalculatorMVVM.Models
{
    // Модель калькулятора: хранит данные и выполняет вычисления
    public class CalculatorModel
    {
        private double firstNumber;
        private string operation = "";
        private double memoryValue;

        public bool IsNewNumber { get; private set; } = true;

        // Добавление цифры к текущему значению
        public string AddDigit(string currentText, string digit)
        {
            if (currentText == "0" || IsNewNumber)
            {
                IsNewNumber = false;
                return digit;
            }

            return currentText + digit;
        }

        // Добавление десятичной запятой
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

        // Выбор арифметической операции
        public void SetOperation(string currentText, string selectedOperation)
        {
            firstNumber = Convert.ToDouble(currentText);
            operation = selectedOperation;
            IsNewNumber = true;
        }

        // Выполнение вычисления
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

        // Полная очистка
        public string Clear()
        {
            firstNumber = 0;
            operation = "";
            IsNewNumber = true;
            return "0";
        }

        // Очистка текущего ввода
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

        // Смена знака числа
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

        // Процент
        public string Percent(string currentText)
        {
            double number = Convert.ToDouble(currentText);
            number = number / 100;
            IsNewNumber = true;

            return number.ToString();
        }

        // Квадратный корень
        public string SquareRoot(string currentText)
        {
            double number = Convert.ToDouble(currentText);

            if (number < 0)
            {
                throw new InvalidOperationException();
            }

            IsNewNumber = true;
            return Math.Sqrt(number).ToString();
        }

        // Возведение в квадрат
        public string Square(string currentText)
        {
            double number = Convert.ToDouble(currentText);
            IsNewNumber = true;

            return (number * number).ToString();
        }

        // Очистка памяти
        public void MemoryClear()
        {
            memoryValue = 0;
        }

        // Сохранение числа в память
        public void MemoryAdd(string currentText)
        {
            memoryValue += Convert.ToDouble(currentText);
            IsNewNumber = true;
        }

        // Получение числа из памяти
        public string MemoryRecall()
        {
            IsNewNumber = true;
            return memoryValue.ToString();
        }
    }
}