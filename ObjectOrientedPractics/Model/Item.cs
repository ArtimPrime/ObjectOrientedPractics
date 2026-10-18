using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id.
        /// </summary>
        private readonly int _id;
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;
        /// <summary>
        /// Описание.
        /// </summary>
        private string _info;
        /// <summary>
        /// Стоимость.
        /// </summary>
        private double _cost;

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>

        public int Id { get { return _id; } }

        /// <summary>
        /// Возвращает и задаёт имя товара.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                ValueValidator.AssertNotEmpty(value, nameof(Name));
                ValueValidator.AssertStringOnLength(value, 200, "Name");
                _name = value;
            }
        }
        /// <summary>
        /// Возвращает и задаёт описание товара.
        /// </summary>
        public string Info
        {
            get 
            { 
                return _info; 
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, "Info");
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт стоимость товара.
        /// </summary>
        /// <exception cref="ArgumentException">Значение должно быть в диапозоне до 100 000.</exception>
        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentException("Cost must be in range [0, 100 000]");
                }

                _cost = value;
            }

        }
        /// <summary>
        /// Создаёт экземпляр <see cref="Item"/>.
        /// </summary>
        public Item()
        {
            _id = IdGenerator.GetNextId();
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="Item"/>.
        /// </summary>
        /// <param name="name">Имя товара. Должно быть меньше 200 символом.</param>
        /// <param name="info">Описание товара. Не должно быть null.</param>
        /// <param name="cost">Стоимость товара. Должна быть в диапазоне [0, 100 000].</param>
        
        public Item(string name, string info, double cost)
        {
            Name = name;
            Info = info;
            Cost = cost;
            _id = IdGenerator.GetNextId();
        }

        /// <inheritdoc cref="ob"/>
        public override string ToString()
        {
            return Name;
        }
    }
    
}
