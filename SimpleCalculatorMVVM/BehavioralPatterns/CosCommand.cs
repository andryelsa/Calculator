using System;

namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    public class CosCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return Math.Cos(firstNumber * Math.PI / 180);
        }
    }
}