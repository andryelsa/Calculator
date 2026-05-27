using SimpleCalculatorFactory.Models.Buttons;

namespace SimpleCalculatorFactory.Factories
{
    // Интерфейс фабрики кнопок
    public interface IButtonFactory
    {
        // Метод создания кнопки по её содержимому
        CalculatorButton CreateButton(string content);
    }
}