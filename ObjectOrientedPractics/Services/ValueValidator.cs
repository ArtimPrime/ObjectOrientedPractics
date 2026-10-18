namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Сервисный класс для валидации значений свойств.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверяет, что длина строки не превышает заданное максимальное значение.
        /// </summary>
        /// <param name="value">Проверяемое строковое значение.</param>
        /// <param name="maxLength">Максимально допустимая длина строки.</param>
        /// <param name="propertyName">Имя свойства, из которого вызван метод, для текста исключения.</param>
        /// <exception cref="ArgumentException">Строка длиннее <paramref name="maxLength"/> символов.</exception>
        public static void AssertStringOnLength(string value, int maxLength, string propertyName)
        {
            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{propertyName} должен быть меньше {maxLength} символов");
            }
        }

        /// <summary>
        /// Проверяет, что строка не пустая и не состоит только из пробелов.
        /// </summary>
        /// <param name="value">Проверяемая строка.</param>
        /// <param name="propertyName">Названия свойства для текста исключения.</param>
        /// <exception cref="ArgumentException">Если строка пустая.</exception>
        public static void AssertNotEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{propertyName} не должно быть пустым.");
            }
        }
    }
}
