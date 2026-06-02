using SimpleCalculatorMVVM.BehavioralPatterns;

namespace SimpleCalculatorMVVM.StructuralPatterns
{
    // Адаптер между моделью калькулятора и командами операций
    public class CommandOperationAdapter : IOperationAdapter
    {
        public double Calculate(string operation, double firstNumber, double secondNumber)
        {
            ICalculatorCommand command;

            switch (operation)
            {
                case "+":
                    command = new AddCommand();
                    break;

                case "-":
                    command = new SubtractCommand();
                    break;

                case "×":
                    command = new MultiplyCommand();
                    break;

                case "÷":
                    command = new DivideCommand();
                    break;

                default:
                    return secondNumber;
            }

            return command.Execute(firstNumber, secondNumber);
        }
    }
}