using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SimpleCalculatorMVVM.Commands;
using SimpleCalculatorMVVM.Models;

namespace SimpleCalculatorMVVM.ViewModels
{
    // ViewModel калькулятора
    public class MainViewModel : INotifyPropertyChanged
    {
        // Модель калькулятора
        private readonly CalculatorModel calculatorModel;

        // Текст основного дисплея
        private string display = "0";

        // Текст выражения
        private string expressionDisplay = "";

        // Свойство дисплея
        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        // Свойство строки выражения
        public string ExpressionDisplay
        {
            get => expressionDisplay;
            set
            {
                expressionDisplay = value;
                OnPropertyChanged(nameof(ExpressionDisplay));
            }
        }

        // Команда кнопок
        public ICommand ButtonCommand { get; }

        // Конструктор
        public MainViewModel()
        {
            calculatorModel = new CalculatorModel();

            // Инициализация команды
            ButtonCommand = new RelayCommand(ExecuteButton);
        }

        // Обработка кнопок
        private void ExecuteButton(object parameter)
        {
            string command = parameter.ToString();

            try
            {
                HandleCommand(command);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Деление на ноль невозможно.");
                Display = "0";
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Некорректная операция.");
                Display = "0";
            }
        }

        // Логика обработки команд
        private void HandleCommand(string command)
        {
            // Цифры
            if (int.TryParse(command, out _))
            {
                Display = calculatorModel.AddDigit(Display, command);
                return;
            }

            switch (command)
            {
                case ",":
                    Display = calculatorModel.AddDecimal(Display);
                    break;

                case "+":
                case "-":
                case "×":
                case "÷":
                    ExpressionDisplay = Display + " " + command;
                    calculatorModel.SetOperation(Display, command);
                    break;

                case "=":
                    ExpressionDisplay = ExpressionDisplay + " " + Display + " =";
                    Display = calculatorModel.Calculate(Display);
                    break;

                case "C":
                    Display = calculatorModel.Clear();
                    ExpressionDisplay = "";
                    break;

                case "CE":
                    Display = calculatorModel.ClearEntry();
                    break;

                case "←":
                    Display = calculatorModel.Backspace(Display);
                    break;

                case "±":
                    Display = calculatorModel.ChangeSign(Display);
                    break;

                case "%":
                    Display = calculatorModel.Percent(Display);
                    break;

                case "√":
                    Display = calculatorModel.SquareRoot(Display);
                    break;

                case "x²":
                    Display = calculatorModel.Square(Display);
                    break;

                case "MC":
                    calculatorModel.MemoryClear();
                    break;

                case "MR":
                    Display = calculatorModel.MemoryRecall();
                    break;

                case "M+":
                    calculatorModel.MemoryAdd(Display);
                    break;
            }
        }

        // Интерфейс обновления UI
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод обновления интерфейса
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}