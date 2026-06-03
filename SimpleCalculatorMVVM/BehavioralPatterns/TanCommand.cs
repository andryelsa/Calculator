using CalculatorLibrary;
using SimpleCalculatorMVVM.BehavioralPatterns;

public class TanCommand : ICalculatorCommand
{
    public double Execute(double firstNumber, double secondNumber)
    {
        return CalculatorEngine.Tan(firstNumber);
    }
}