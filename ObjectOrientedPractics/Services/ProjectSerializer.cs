using Newtonsoft.Json;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Сервисный класс для сохранения и загрузки данных приложения в JSON-файлы.
    /// </summary>
    public static class ProjectSerializer
    {
        /// <summary>
        /// Сохраняет список товаров в файл по указанному пути.
        /// </summary>
        /// <param name="items">Список товаров для сохранения.</param>
        /// <param name="path">Путь к файлу.</param>
        public static void SaveItems(List<Item> items, string path)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Загружает список товаров из файла. Если файл отсутствует, возвращает пустой список.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        public static List<Item> LoadItems(string path)
        {
            if (!File.Exists(path))
            {
                return new List<Item>();
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
        }

        /// <summary>
        /// Сохраняет список покупателей в файл по указанному пути.
        /// </summary>
        /// <param name="customers">Список покупателей для сохранения.</param>
        /// <param name="path">Путь к файлу.</param>
        public static void SaveCustomers(List<Customer> customers, string path)
        {
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Загружает список покупателей из файла. Если файл отсутствует, возвращает пустой список.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        public static List<Customer> LoadCustomers(string path)
        {
            if (!File.Exists(path))
            {
                return new List<Customer>();
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
        }
    }
}
