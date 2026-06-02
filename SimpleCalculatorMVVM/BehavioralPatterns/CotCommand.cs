using System;

namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    public class CotCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            double tan = Math.Tan(firstNumber * Math.PI / 180);

            if (tan == 0)
                throw new DivideByZeroException();

            return 1 / tan;
        }
    }
}