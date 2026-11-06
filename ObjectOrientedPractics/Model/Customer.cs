using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Покупатель.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        private string _fullname = string.Empty;

        /// <summary>
        /// Корзина покупателя.
        /// </summary>
        private Cart _cart = new Cart();

        /// <summary>
        /// Заказы покупателя.
        /// </summary>
        private List<Order> _orders = new();

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private Address _address = new Address();

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Возвращает и задаёт полное имя покупателя. Не более 200 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Имя пустое или длиннее 200 символов.</exception>
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                ValueValidator.AssertNotEmpty(value, "Fullname");
                ValueValidator.AssertStringOnLength(value, 200, "Fullname");
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт адрес доставки.
        /// </summary>
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value ?? new Address();
            }
        }

        /// <summary>
        /// Возвращает и задаёт корзину покупателя.
        /// </summary>
        public Cart Cart
        {
            get { return _cart; }
            set { _cart = value ?? new Cart(); }
        }

        /// <summary>
        /// Возвращает и задаёт список заказов покупателя.
        /// </summary>
        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value ?? new List<Order>(); }
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Customer"/>.
        /// </summary>
        public Customer()
        {
            _id = IdGenerator.GetNextId();
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">Полное имя покупателя. Не более 200 символов.</param>
        /// <param name="address">Адрес доставки.</param>
        public Customer(string fullname, Address address)
        {
            FullName = fullname;
            Address = address;
            _id = IdGenerator.GetNextId();
        }

        /// <summary>
        /// Возвращает строковое представление покупателя.
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }
    }
}