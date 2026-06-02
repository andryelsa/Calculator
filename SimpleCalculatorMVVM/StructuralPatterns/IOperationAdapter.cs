namespace SimpleCalculatorMVVM.StructuralPatterns
{
    // Интерфейс адаптера операций
    public interface IOperationAdapter
    {
        // Метод выполняет вычисление через адаптер
        double Calculate(string operation, double firstNumber, double secondNumber);
    }
}