namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    // Команда сложения
    public class AddCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}