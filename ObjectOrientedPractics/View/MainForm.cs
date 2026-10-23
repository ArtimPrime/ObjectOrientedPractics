using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Путь к файлу с данными магазина.
        /// </summary>
        private readonly string _dataPath = Path.Combine(Application.StartupPath, "store.json");

        /// <summary>
        /// Данные магазина: товары и покупатели.
        /// </summary>
        private Store _store;

        /// <summary>
        /// Создаёт экземпляр <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _store = ProjectSerializer.LoadStore(_dataPath);

            itemsTab1.Items = _store.Items;
            customerTab1.Customers = _store.Customers;

            FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// Сохраняет данные магазина при закрытии окна.
        /// </summary>
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            ProjectSerializer.SaveStore(_store, _dataPath);
        }

        private void itemsTab1_Load(object sender, EventArgs e)
        {
        }

        private void customerTab1_Load(object sender, EventArgs e)
        {
        }
    }
}