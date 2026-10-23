using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using System.ComponentModel;


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
        /// Возвращает и задаёт список товаров вкладки. При присвоении обновляет список на экране.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;

                ItemsListBox.Items.Clear();
                foreach (var item in _items)
                {
                    ItemsListBox.Items.Add(item);
                }

                ClearFields();
            }
        }



        /// <summary>
        /// Создаёт экземпляр <see cref="ItemsTab"/>.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();

            CategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
            CategoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;

            IdTextBox.ReadOnly = true;

            AddButton.Click += AddButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            CostTextBox.TextChanged += CostTextBox_TextChanged;
            DescriptionTextBox.TextChanged += DescriptionTextBox_TextChanged;

            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
        }


        /// <summary>
        /// Считывает значения из полей ввода, проверяет их и, если всё верно,
        /// создаёт новый товар и добавляет его в список. Если значение какого-либо
        /// поля некорректно, поле подсвечивается красным и товар не создаётся.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            try
            {
                ValueValidator.AssertNotEmpty(NameTextBox.Text, "Name");
                ValueValidator.AssertStringOnLength(NameTextBox.Text, 200, "Name");
                NameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                NameTextBox.BackColor = Color.MistyRose;
                isValid = false;
            }

            try
            {
                ValueValidator.AssertStringOnLength(DescriptionTextBox.Text, 1000, "Info");
                DescriptionTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                DescriptionTextBox.BackColor = Color.MistyRose;
                isValid = false;
            }

            double cost = 0;
            if (double.TryParse(CostTextBox.Text, out cost) && cost >= 0 && cost <= 100000)
            {
                CostTextBox.BackColor = Color.White;
            }
            else
            {
                CostTextBox.BackColor = Color.MistyRose;
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            Category category = CategoryComboBox.SelectedItem is Category selected
            ? selected
            : Category.Electronics;

            var item = new Item(NameTextBox.Text, DescriptionTextBox.Text, cost, category);
            _items.Add(item);
            ItemsListBox.Items.Add(item);

            ItemsListBox.ClearSelected();
            ClearFields();
        }

        /// <summary>
        /// Создаёт случайный товар с помощью <see cref="ItemFactory"/> и добавляет его в список.
        /// </summary>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var item = ItemFactory.Create();
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
                CategoryComboBox.SelectedItem = item.Category;
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is Item item && CategoryComboBox.SelectedItem is Category category)
            {
                item.Category = category;
            }
        }

        /// <summary>
        /// Обновляет название товара и подсвечивает поле при ошибке валидации.
        /// Срабатывает только когда в списке выбран существующий товар.
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
        /// Срабатывает только когда в списке выбран существующий товар.
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
        /// Срабатывает только когда в списке выбран существующий товар.
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
