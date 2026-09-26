using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Вкладка со списком покупателей и редактированием выбранного покупателя.
    /// </summary>
    public partial class CustomerTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers = new();

        /// <summary>
        /// Путь к файлу, в котором хранятся сохранённые покупатели.
        /// </summary>
        private readonly string _dataPath = Path.Combine(Application.StartupPath, "customers.json");

        /// <summary>
        /// Создаёт экземпляр <see cref="CustomerTab"/>.
        /// </summary>
        public CustomerTab()
        {
            InitializeComponent();

            IdTextBox.ReadOnly = true;

            AddButton.Click += AddButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            CustomersListBox.SelectedIndexChanged += CustomersListBox_SelectedIndexChanged;
            FullNameTextBox.TextChanged += FullNameTextBox_TextChanged;
            AddressTextBox.TextChanged += AddressTextBox_TextChanged;

            _customers = ProjectSerializer.LoadCustomers(_dataPath);
            foreach (var customer in _customers)
            {
                CustomersListBox.Items.Add(customer);
            }
        }

        /// <summary>
        /// Сохраняет текущий список покупателей в файл.
        /// </summary>
        private void SaveCustomers()
        {
            ProjectSerializer.SaveCustomers(_customers, _dataPath);
        }

        /// <summary>
        /// Считывает значения из полей ввода, проверяет их и, если всё верно,
        /// создаёт нового покупателя и добавляет его в список. Если значение
        /// какого-либо поля некорректно, поле подсвечивается красным и покупатель не создаётся.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            try
            {
                ValueValidator.AssertStringOnLength(FullNameTextBox.Text, 200, "Fullname");
                FullNameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                FullNameTextBox.BackColor = Color.MistyRose;
                isValid = false;
            }

            try
            {
                ValueValidator.AssertStringOnLength(AddressTextBox.Text, 500, "Address");
                AddressTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                AddressTextBox.BackColor = Color.MistyRose;
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            var customer = new Customer(FullNameTextBox.Text, AddressTextBox.Text);
            _customers.Add(customer);
            CustomersListBox.Items.Add(customer);

            CustomersListBox.ClearSelected();
            ClearFields();
            SaveCustomers();
        }

        /// <summary>
        /// Создаёт случайного покупателя с помощью <see cref="CustomerFactory"/> и добавляет его в список.
        /// Подключи этот обработчик к кнопке Generate на этой вкладке (как ты уже сделал на вкладке Items).
        /// </summary>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var customer = CustomerFactory.Create();
            _customers.Add(customer);
            CustomersListBox.Items.Add(customer);
            CustomersListBox.SelectedItem = customer;
            SaveCustomers();
        }

        /// <summary>
        /// Обработчик отрисовки правой панели сплиттера (создан дизайнером автоматически).
        /// </summary>
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Удаляет выбранного покупателя из списка.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer customer)
            {
                int index = CustomersListBox.SelectedIndex;
                _customers.Remove(customer);
                CustomersListBox.Items.Remove(customer);

                if (CustomersListBox.Items.Count > 0)
                    CustomersListBox.SelectedIndex = Math.Min(index, CustomersListBox.Items.Count - 1);
                else
                    ClearFields();

                SaveCustomers();
            }
        }

        /// <summary>
        /// Отображает данные выбранного покупателя в полях редактирования.
        /// </summary>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer customer)
            {
                IdTextBox.Text = customer.Id.ToString();
                FullNameTextBox.Text = customer.FullName;
                AddressTextBox.Text = customer.Address;
            }
        }

        /// <summary>
        /// Обновляет полное имя покупателя и подсвечивает поле при ошибке валидации.
        /// Срабатывает только когда в списке выбран существующий покупатель.
        /// </summary>
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer customer)
            {
                try
                {
                    customer.FullName = FullNameTextBox.Text;
                    FullNameTextBox.BackColor = Color.White;

                    int index = CustomersListBox.SelectedIndex;
                    CustomersListBox.Items[index] = customer;
                    SaveCustomers();
                }
                catch (ArgumentException)
                {
                    FullNameTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Обновляет адрес доставки покупателя и подсвечивает поле при ошибке валидации.
        /// Срабатывает только когда в списке выбран существующий покупатель.
        /// </summary>
        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer customer)
            {
                try
                {
                    customer.Address = AddressTextBox.Text;
                    AddressTextBox.BackColor = Color.White;
                    SaveCustomers();
                }
                catch (ArgumentException)
                {
                    AddressTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Очищает поля редактирования покупателя.
        /// </summary>
        private void ClearFields()
        {
            IdTextBox.Clear();
            FullNameTextBox.Clear();
            AddressTextBox.Clear();
        }
    }
}
