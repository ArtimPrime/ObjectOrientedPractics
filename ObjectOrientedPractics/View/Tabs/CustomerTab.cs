using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

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
        }

        /// <summary>
        /// Создаёт нового покупателя и добавляет его в список.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer("New customer", "Address");
            _customers.Add(customer);
            CustomersListBox.Items.Add(customer);
            CustomersListBox.SelectedItem = customer;
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
                }
                catch (ArgumentException)
                {
                    FullNameTextBox.BackColor = Color.MistyRose;
                }
            }
        }

        /// <summary>
        /// Обновляет адрес доставки покупателя и подсвечивает поле при ошибке валидации.
        /// </summary>
        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer customer)
            {
                try
                {
                    customer.Address = AddressTextBox.Text;
                    AddressTextBox.BackColor = Color.White;
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
