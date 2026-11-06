namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Магазин. Хранит все товары и всех покупателей.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Товары.
        /// </summary>
        private List<Item> _items = new();

        /// <summary>
        /// Покупатели.
        /// </summary>
        private List<Customer> _customers = new();

        /// <summary>
        /// Возвращает и задаёт список товаров. Никогда не равен null.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value ?? new List<Item>(); }
        }

        /// <summary>
        /// Возвращает и задаёт список покупателей. Никогда не равен null.
        /// </summary>
        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value ?? new List<Customer>(); }
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Store"/> с пустыми списками.
        /// </summary>
        public Store()
        {
        }
    }
}