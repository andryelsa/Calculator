using CalculatorLibrary;
using SimpleCalculatorMVVM.BehavioralPatterns;

public class CotCommand : ICalculatorCommand
{
    public double Execute(double firstNumber, double secondNumber)
    {
        return CalculatorEngine.Cot(firstNumber);
    }
}