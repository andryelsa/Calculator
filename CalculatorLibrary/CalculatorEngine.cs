using System;

namespace CalculatorLibrary
{
    public static class CalculatorEngine
    {
        public static double Add(double a, double b) => a + b;

        public static double Subtract(double a, double b) => a - b;

        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");

            return a / b;
        }

        public static double Sin(double value) => Math.Sin(value);

        public static double Cos(double value) => Math.Cos(value);

        public static double Tan(double value) => Math.Tan(value);

        public static double Cot(double value) => 1 / Math.Tan(value);

        public static double Sqrt(double value) => Math.Sqrt(value);

        public static double Square(double value) => value * value;

        public static double Percent(double value) => value / 100;
    }
}