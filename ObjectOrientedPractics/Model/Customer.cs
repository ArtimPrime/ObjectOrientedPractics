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
        /// Полное имя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private string _address;

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id { get { return _id; } }

        /// <summary>
        /// Возвращает и задаёт полное имя покупателя.
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, "Fullname");
                _fullname = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт адрес доставки покупателя.
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 500, "Address");
                _address = value;
            }
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
        /// <param name="fullname">Полное имя покупателя. Должно быть меньше 200 символов.</param>
        /// <param name="address">Адрес доставки покупателя. Должен быть меньше 500 символов.</param>
        public Customer(string fullname, string address)
        {
            FullName = fullname;
            Address = address;
            _id = IdGenerator.GetNextId();
        }

        /// <summary>
        /// Возвращает полное имя покупателя.
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }
    } 
}
