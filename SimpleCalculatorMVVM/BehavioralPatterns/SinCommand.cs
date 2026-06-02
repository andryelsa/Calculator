using System;

namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    public class SinCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return Math.Sin(firstNumber * Math.PI / 180);
        }
    }
}