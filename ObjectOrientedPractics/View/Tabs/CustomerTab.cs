using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        /// Возвращает и задаёт список покупателей вкладки. При присвоении обновляет список на экране.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;

                CustomersListBox.Items.Clear();
                foreach (var customer in _customers)
                {
                    CustomersListBox.Items.Add(customer);
                }

                ClearFields();
            }
        }


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
        }


        /// <summary>
        /// Считывает значения из полей ввода, проверяет их и, если всё верно,
        /// создаёт нового покупателя и добавляет его в список. Если значение
        /// какого-либо поля некорректно, поле подсвечивается красным и покупатель не создаётся.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValueValidator.AssertNotEmpty(FullNameTextBox.Text, "Fullname");
                ValueValidator.AssertStringOnLength(FullNameTextBox.Text, 200, "Fullname");
                FullNameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                FullNameTextBox.BackColor = Color.MistyRose;
                return;
            }

            var source = AddressControl.Address;
            var address = new Address(
                source.Index,
                source.Country,
                source.City,
                source.Street,
                source.Building,
                source.Apartment);

            var customer = new Customer(FullNameTextBox.Text, address);
            _customers.Add(customer);
            CustomersListBox.Items.Add(customer);

            CustomersListBox.ClearSelected();
            ClearFields();
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
                AddressControl.Address = customer.Address;
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
                }
                catch (ArgumentException)
                {
                    FullNameTextBox.BackColor = Color.MistyRose;
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
            AddressControl.Address = new Address();
        }


        private void AddressControl_Load(object sender, EventArgs e)
        {

        }
    }
}
