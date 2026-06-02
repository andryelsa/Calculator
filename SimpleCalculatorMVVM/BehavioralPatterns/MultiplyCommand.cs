namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    // Команда умножения
    public class MultiplyCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}