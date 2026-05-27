using SimpleCalculatorFactory.Models.Buttons;

namespace SimpleCalculatorFactory.Factories
{
    // Фабрика для создания кнопок калькулятора
    public class ButtonFactory : IButtonFactory
    {
        // Метод создания кнопки
        public CalculatorButton CreateButton(string content)
        {
            // Создание цифровых кнопок
            if (int.TryParse(content, out _))
            {
                return new DigitButton(content);
            }

            // Создание кнопок операций
            if (content == "+" || content == "-" ||
                content == "×" || content == "÷")
            {
                return new OperatorButton(content);
            }

            // Создание функциональных кнопок
            return new FunctionButton(content);
        }
    }
}