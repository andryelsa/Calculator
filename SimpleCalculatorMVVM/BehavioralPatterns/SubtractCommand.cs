namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    // Команда вычитания
    public class SubtractCommand : ICalculatorCommand
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}