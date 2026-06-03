using CalculatorLibrary;
using SimpleCalculatorMVVM.BehavioralPatterns;

public class SinCommand : ICalculatorCommand
{
    public double Execute(double firstNumber, double secondNumber)
    {
        return CalculatorEngine.Sin(firstNumber);
    }
}