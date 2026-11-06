namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Корзина товаров покупателя.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Товары в корзине.
        /// </summary>
        private List<Item> _items = new();

        /// <summary>
        /// Возвращает и задаёт список товаров в корзине.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// Возвращает общую стоимость товаров в корзине. Для пустой корзины возвращает 0.0.
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
        /// Создаёт пустую корзину.
        /// </summary>
        public Cart()
        {
        }
    }
}