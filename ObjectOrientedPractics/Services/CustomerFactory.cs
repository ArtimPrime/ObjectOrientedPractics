using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Генератор случайных покупателей для тестирования приложения.
    /// </summary>
    public static class CustomerFactory
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private static readonly Random _random = new();

        /// <summary>
        /// Набор реальных имён.
        /// </summary>
        private static readonly string[] _firstNames =
        {
            "Иван", "Пётр", "Анна", "Мария", "Сергей",
            "Ольга", "Дмитрий", "Екатерина", "Алексей", "Наталья"
        };

        /// <summary>
        /// Набор реальных фамилий.
        /// </summary>
        private static readonly string[] _lastNames =
        {
            "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов",
            "Попов", "Волков", "Соколов", "Морозов", "Новиков"
        };

        /// <summary>
        /// Набор реальных отчеств.
        /// </summary>
        private static readonly string[] _patronymics =
        {
            "Иванович", "Петрович", "Сергеевич", "Александрович", "Дмитриевич",
            "Ивановна", "Петровна", "Сергеевна", "Александровна", "Дмитриевна"
        };

        /// <summary>
        /// Набор реальных городов.
        /// </summary>
        private static readonly string[] _cities =
        {
            "Томск", "Москва", "Новосибирск", "Казань", "Екатеринбург",
            "Санкт-Петербург"
        };

        /// <summary>
        /// Набор реальных улиц.
        /// </summary>
        private static readonly string[] _streets =
        {
            "Ленина", "Мира", "Советская", "Гагарина", "Пушкина"
        };

        /// <summary>
        /// Создаёт покупателя со случайными именем и адресом доставки.
        /// </summary>
        /// <returns>Новый покупатель.</returns>
        public static Customer Create()
        {
            string fullname = $"{_lastNames[_random.Next(_lastNames.Length)]} " +
                              $"{_firstNames[_random.Next(_firstNames.Length)]} " +
                              $"{_patronymics[_random.Next(_patronymics.Length)]}";

            var address = new Address(
                _random.Next(100000, 1000000),
                "Россия",
                _cities[_random.Next(_cities.Length)],
                _streets[_random.Next(_streets.Length)],
                _random.Next(1, 100).ToString(),
                _random.Next(1, 300).ToString());

            return new Customer(fullname, address);
        }
    }
}