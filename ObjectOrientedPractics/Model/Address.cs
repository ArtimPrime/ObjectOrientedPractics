using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Адрес доставки.
    /// </summary>
    public class Address
    {
        /// <summary>Почтовый индекс.</summary>
        private int _index = 100000;

        /// <summary>Страна или регион.</summary>
        private string _country = string.Empty;

        /// <summary>Город.</summary>
        private string _city = string.Empty;

        /// <summary>Улица.</summary>
        private string _street = string.Empty;

        /// <summary>Номер дома.</summary>
        private string _building = string.Empty;

        /// <summary>Номер квартиры или помещения.</summary>
        private string _apartment = string.Empty;

        /// <summary>
        /// Возвращает и задаёт почтовый индекс. Шестизначное число.
        /// </summary>
        public int Index
        {
            get { return _index; }
            set
            {
                ValueValidator.AssertSixDigits(value, "Index");
                _index = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт страну. Не более 50 символов.
        /// </summary>
        public string Country
        {
            get { return _country; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 50, "Country");
                _country = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт город. Не более 50 символов.
        /// </summary>
        public string City
        {
            get { return _city; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 50, "City");
                _city = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт улицу. Не более 100 символов.
        /// </summary>
        public string Street
        {
            get { return _street; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 100, "Street");
                _street = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер дома. Не более 10 символов.
        /// </summary>
        public string Building
        {
            get { return _building; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 10, "Building");
                _building = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер квартиры. Не более 10 символов.
        /// </summary>
        public string Apartment
        {
            get { return _apartment; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 10, "Apartment");
                _apartment = value;
            }
        }

        /// <summary>
        /// Создаёт пустой экземпляр <see cref="Address"/>.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Почтовый индекс, шестизначное число.</param>
        /// <param name="country">Страна, до 50 символов.</param>
        /// <param name="city">Город, до 50 символов.</param>
        /// <param name="street">Улица, до 100 символов.</param>
        /// <param name="building">Номер дома, до 10 символов.</param>
        /// <param name="apartment">Номер квартиры, до 10 символов.</param>
        public Address(int index, string country, string city, string street,
            string building, string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }
    }
}