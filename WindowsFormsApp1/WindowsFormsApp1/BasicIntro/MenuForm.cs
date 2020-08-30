using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void UserSaveFormButton_Click(object sender, EventArgs e)
        {
            using (var f = new UserSaveForm())
            {
                f.ShowDialog();
            }
        }

        private void UserListFormButton_Click(object sender, EventArgs e)
        {
            using (var f = new UserListForm())
            {
                f.ShowDialog();
            }
        }
    }
}
