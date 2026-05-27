namespace SimpleCalculatorFactory.Models.Buttons
{
    // Базовый абстрактный класс для всех кнопок калькулятора
    public abstract class CalculatorButton
    {
        // Текст, отображаемый на кнопке
        public string Content { get; }

        // Конструктор кнопки
        protected CalculatorButton(string content)
        {
            Content = content;
        }

        // Метод нажатия кнопки
        public abstract string Press();
    }
}