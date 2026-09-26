using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Вкладка со списком товаров и редактированием выбранного товара.
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _items = new();

        /// <summary>
        /// Создаёт экземпляр <see cref="ItemsTab"/>.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();

            IdTextBox.ReadOnly = true;

            AddButton.Click += AddButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            CostTextBox.TextChanged += CostTextBox_TextChanged;
            DescriptionTextBox.TextChanged += DescriptionTextBox_TextChanged;
        }

        /// <summary>
        /// Создаёт новый товар и добавляет его в список.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var item = new Item("New item", "Description", 0);
            _items.Add(item);
            ItemsListBox.Items.Add(item);
            ItemsListBox.SelectedItem = item;
        }

        /// <summary>
        /// Удаляет выбранный товар из списка.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item)
            {
                int index = ItemsListBox.SelectedIndex;
                _items.Remove(item);
                ItemsListBox.Items.Remove(item);

                if (ItemsListBox.Items.Count > 0)
                    ItemsListBox.SelectedIndex = Math.Min(index, ItemsListBox.Items.Count - 1);
                else
                    ClearFields();
            }
        }

        /// <summary>
        /// Отображает данные выбранного товара в полях редактирования.
        /// </summary>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item)
            {
                IdTextBox.Text = item.Id.ToString();
                CostTextBox.Text = item.Cost.ToString();
                NameTextBox.Text = item.Name;
                DescriptionTextBox.Text = item.Info;
            }
        }

        /// <summary>
        /// Обновляет название товара и подсвечивает поле при ошибке валидации.
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item)
            {
                try
                {
                    item.Name = NameTextBox.Text;
                    NameTextBox.BackColor = Color.White;

                    int index = ItemsListBox.SelectedIndex;
                    ItemsListBox.Items[index] = item;
                }
                catch (ArgumentException)
                {
                    NameTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Обновляет стоимость товара и подсвечивает поле при ошибке валидации или неверном формате.
        /// </summary>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item)
            {
                if (double.TryParse(CostTextBox.Text, out double cost))
                {
                    try
                    {
                        item.Cost = cost;
                        CostTextBox.BackColor = Color.White;
                    }
                    catch (ArgumentException)
                    {
                        CostTextBox.BackColor = Color.MistyRose;
                    }
                }
                else
                {
                    CostTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Обновляет описание товара и подсвечивает поле при ошибке валидации.
        /// </summary>
        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item)
            {
                try
                {
                    item.Info = DescriptionTextBox.Text;
                    DescriptionTextBox.BackColor = Color.White;
                }
                catch (ArgumentException)
                {
                    DescriptionTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Очищает поля редактирования товара.
        /// </summary>
        private void ClearFields()
        {
            IdTextBox.Clear();
            CostTextBox.Clear();
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
        }
    }
}
