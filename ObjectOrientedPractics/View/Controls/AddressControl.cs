using ObjectOrientedPractics.Model;
using System.ComponentModel;

namespace ObjectOrientedPractics.View.Controls
{
    /// <summary>
    /// Элемент управления для просмотра и редактирования адреса.
    /// </summary>
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Редактируемый адрес.
        /// </summary>
        private Address _address = new Address();

        /// <summary>
        /// Подсказка с текстом ошибки.
        /// </summary>
        private readonly ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Возвращает и задаёт адрес. При присвоении поля заполняются данными адреса.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value ?? new Address();
                ShowAddress();
            }
        }

        /// <summary>
        /// Создаёт экземпляр <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();

            IndexTextBox.TextChanged += IndexTextBox_TextChanged;
            CountryTextBox.TextChanged += CountryTextBox_TextChanged;
            CityTextBox.TextChanged += CityTextBox_TextChanged;
            StreetTextBox.TextChanged += StreetTextBox_TextChanged;
            BuildingTextBox.TextChanged += BuildingTextBox_TextChanged;
            ApartmentTextBox.TextChanged += ApartmentTextBox_TextChanged;

            ShowAddress();
        }

        /// <summary>
        /// Показывает данные адреса в полях.
        /// </summary>
        private void ShowAddress()
        {
            IndexTextBox.Text = _address.Index.ToString();
            CountryTextBox.Text = _address.Country;
            CityTextBox.Text = _address.City;
            StreetTextBox.Text = _address.Street;
            BuildingTextBox.Text = _address.Building;
            ApartmentTextBox.Text = _address.Apartment;
        }

        /// <summary>
        /// Применяет значение через действие. Подсвечивает поле при ошибке.
        /// </summary>
        /// <param name="textBox">Поле ввода.</param>
        /// <param name="apply">Действие записи значения в адрес.</param>
        private void TryApply(TextBox textBox, Action apply)
        {
            try
            {
                apply();
                textBox.BackColor = Color.White;
                _toolTip.SetToolTip(textBox, string.Empty);
            }
            catch (ArgumentException ex)
            {
                textBox.BackColor = Color.MistyRose;
                _toolTip.SetToolTip(textBox, ex.Message);
            }
        }

        private void IndexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(IndexTextBox.Text, out int index))
            {
                TryApply(IndexTextBox, () => _address.Index = index);
            }
            else
            {
                IndexTextBox.BackColor = Color.MistyRose;
                _toolTip.SetToolTip(IndexTextBox, "Индекс должен быть числом");
            }
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            TryApply(CountryTextBox, () => _address.Country = CountryTextBox.Text);
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            TryApply(CityTextBox, () => _address.City = CityTextBox.Text);
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            TryApply(StreetTextBox, () => _address.Street = StreetTextBox.Text);
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            TryApply(BuildingTextBox, () => _address.Building = BuildingTextBox.Text);
        }

        private void ApartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            TryApply(ApartmentTextBox, () => _address.Apartment = ApartmentTextBox.Text);
        }

        private void CityTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void StreetTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}