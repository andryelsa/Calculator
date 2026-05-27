namespace SimpleCalculatorFactory.Models.Buttons
{
    // Класс цифровой кнопки
    public class DigitButton : CalculatorButton
    {
        // Конструктор цифровой кнопки
        public DigitButton(string digit) : base(digit)
        {
        }

        // Возвращает значение цифры
        public override string Press()
        {
            return Content;
        }
    }
}