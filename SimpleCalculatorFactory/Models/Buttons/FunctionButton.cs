namespace SimpleCalculatorFactory.Models.Buttons
{
    // Класс функциональных кнопок (C, CE, %, ±)
    public class FunctionButton : CalculatorButton
    {
        // Конструктор функциональной кнопки
        public FunctionButton(string function) : base(function)
        {
        }

        // Возвращает функциональную команду
        public override string Press()
        {
            return Content;
        }
    }
}