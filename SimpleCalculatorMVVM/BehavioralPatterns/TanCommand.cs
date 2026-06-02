using System;

namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    public class TanCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return Math.Tan(firstNumber * Math.PI / 180);
        }
    }
}