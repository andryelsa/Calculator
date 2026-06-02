using System;

namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    // Команда деления
    public class DivideCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно.");
            }

            return firstNumber / secondNumber;
        }
    }
}