using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Генератор случайных товаров для тестирования приложения.
    /// </summary>
    public static class ItemFactory
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private static readonly Random _random = new();

        /// <summary>
        /// Набор реальных названий товаров.
        /// </summary>
        private static readonly string[] _names =
        {
            "Ноутбук ASUS VivoBook 15",
            "Смартфон Samsung Galaxy A54",
            "Наушники Sony WH-1000XM5",
            "Клавиатура Logitech MX Keys",
            "Мышь Razer DeathAdder V3",
            "Монитор LG UltraGear 27\"",
            "Кофеварка Philips Series 3200",
            "Робот-пылесос Xiaomi Mi Robot",
            "Чайник электрический Bosch TWK",
            "Рюкзак Xiaomi Classic Business",
            "Фитнес-браслет Xiaomi Mi Band 8",
            "Портативная колонка JBL Flip 6"
        };

        /// <summary>
        /// Набор реальных описаний товаров.
        /// </summary>
        private static readonly string[] _infos =
        {
            "Стильный и функциональный, отлично подходит для повседневного использования.",
            "Высокое качество сборки и надёжность проверенного производителя.",
            "Компактный размер и продуманный дизайн для максимального удобства.",
            "Отличное соотношение цены и качества, подходит для дома и офиса.",
            "Современные технологии обеспечивают долгий срок службы.",
            "Популярная модель с широким набором функций и приятной ценой."
        };

        /// <summary>
        /// Создаёт товар со случайными названием, описанием и стоимостью.
        /// </summary>
        public static Item Create()
        {
            string name = _names[_random.Next(_names.Length)];
            string info = _infos[_random.Next(_infos.Length)];
            double cost = _random.Next(100, 100000) + Math.Round(_random.NextDouble(), 2);

            return new Item(name, info, cost);
        }
    }
}
