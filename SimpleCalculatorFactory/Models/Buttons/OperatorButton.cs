namespace SimpleCalculatorFactory.Models.Buttons
{
    // Класс операционных кнопок (+, -, *, /)
    public class OperatorButton : CalculatorButton
    {
        // Конструктор операционной кнопки
        public OperatorButton(string operation) : base(operation)
        {
        }

        // Возвращает знак операции
        public override string Press()
        {
            return Content;
        }
    }
}