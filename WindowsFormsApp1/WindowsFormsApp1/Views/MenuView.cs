using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void MeasureButton_Click(object sender, EventArgs e)
        {
            using (var f = new MeasureView())
            {
                f.ShowDialog();
            }
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            using(var f = new LatestView())
            {
                f.ShowDialog();
            }
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            using(var f = new MeasureListView())
            {
                f.ShowDialog();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var f = new MeasureSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
