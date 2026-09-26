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
        /// Набор реальных адресов доставки.
        /// </summary>
        private static readonly string[] _addresses =
        {
            "г. Москва, ул. Ленина, д. 12, кв. 5",
            "г. Санкт-Петербург, Невский пр-т, д. 45, кв. 10",
            "г. Новосибирск, ул. Мира, д. 3, кв. 22",
            "г. Екатеринбург, ул. Малышева, д. 8, кв. 14",
            "г. Казань, ул. Баумана, д. 20, кв. 7",
            "г. Томск, пр-т Ленина, д. 30, кв. 2"
        };

        /// <summary>
        /// Создаёт покупателя со случайными именем и адресом доставки.
        /// </summary>
        public static Customer Create()
        {
            string fullname = $"{_lastNames[_random.Next(_lastNames.Length)]} " +
                               $"{_firstNames[_random.Next(_firstNames.Length)]} " +
                               $"{_patronymics[_random.Next(_patronymics.Length)]}";
            string address = _addresses[_random.Next(_addresses.Length)];

            return new Customer(fullname, address);
        }
    }
}
