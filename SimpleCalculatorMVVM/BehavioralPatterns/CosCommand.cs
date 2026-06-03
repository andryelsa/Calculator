using CalculatorLibrary;
using SimpleCalculatorMVVM.BehavioralPatterns;

public class CosCommand : ICalculatorCommand
{
    public double Execute(double firstNumber, double secondNumber)
    {
        return CalculatorEngine.Cos(firstNumber);
    }
}