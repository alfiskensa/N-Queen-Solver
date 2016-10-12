using System;
using System.Windows.Forms;

namespace ChronoBacktrackCS
{
    public partial class ChronoBacktrackForm : Form
    {
        int seed = 1;

        public ChronoBacktrackForm()
        {
            InitializeComponent();

            button1.Click += new EventHandler(ButtonOnClick);
        }

        void ButtonOnClick(Object obj, EventArgs ea)
        {
            int n = Convert.ToInt32(comboBox1.SelectedItem);
            Form form = new DrawSolutionForm(n, seed);

            form.Show();
            seed++;
        }
    }
}
