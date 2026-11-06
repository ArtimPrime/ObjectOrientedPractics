using Newtonsoft.Json;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Заказ покупателя.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id заказа.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        private readonly DateTime _created;

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Товары заказа.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Возвращает Id заказа.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public DateTime Created
        {
            get { return _created; }
        }

        /// <summary>
        /// Возвращает и задаёт адрес доставки.
        /// </summary>
        public Address Address
        {
            get { return _address; }
            set { _address = value ?? new Address(); }
        }

        /// <summary>
        /// Возвращает и задаёт список товаров заказа.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// Возвращает и задаёт статус заказа.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Возвращает общую стоимость товаров заказа. Для пустого списка возвращает 0.0.
        /// </summary>
        public double Amount
        {
            get
            {
                if (_items == null || _items.Count == 0)
                {
                    return 0.0;
                }

                double sum = 0.0;
                foreach (var item in _items)
                {
                    sum += item.Cost;
                }

                return sum;
            }
        }

        /// <summary>
        /// Создаёт новый заказ со статусом <see cref="OrderStatus.New"/>.
        /// </summary>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Товары заказа.</param>
        public Order(Address address, List<Item> items)
        {
            _id = IdGenerator.GetNextId();
            _created = DateTime.Now;
            _address = address ?? new Address();
            _items = items;
            Status = OrderStatus.New;
        }

        /// <summary>
        /// Восстанавливает заказ из сохранённых данных.
        /// </summary>
        /// <param name="id">Id заказа.</param>
        /// <param name="created">Дата создания.</param>
        /// <param name="address">Адрес доставки.</param>
        /// <param name="items">Товары заказа.</param>
        /// <param name="status">Статус заказа.</param>
        [JsonConstructor]
        public Order(int id, DateTime created, Address address, List<Item> items, OrderStatus status)
        {
            _id = id;
            _created = created;
            _address = address ?? new Address();
            _items = items;
            Status = status;
        }
    }
}