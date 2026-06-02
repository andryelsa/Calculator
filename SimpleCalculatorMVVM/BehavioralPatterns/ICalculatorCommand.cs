namespace SimpleCalculatorMVVM.BehavioralPatterns
{
    // Общий интерфейс команды калькулятора
    public interface ICalculatorCommand
    {
        // Метод выполняет операцию над двумя числами
        double Execute(double firstNumber, double secondNumber);
    }
}
