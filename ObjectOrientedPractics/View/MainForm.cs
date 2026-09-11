using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var item = new Item();

            MessageBox.Show(item.Name);
        }
    }
}
