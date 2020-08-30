using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MessageBoxButtons;
using static System.Windows.Forms.MessageBoxIcon;
using static System.Windows.Forms.DialogResult;
using static System.Text.Encoding;

namespace WindowsFormsApp1
{
    public partial class UserSaveForm : Form
    {
        public UserSaveForm()
        {
            InitializeComponent();

            MailCheckBoxChanged();
            BusinessRadioButtonChanged();

            string[] list = { "有効", "無効" };
            EnableComboBox.Items.AddRange(list);
            EnableComboBox.SelectedIndex = 0;
        }

        private void MailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MailCheckBoxChanged();
        }

        private void MailCheckBoxChanged()
        {
            MailAddressTextBox.Enabled = MailCheckBox.Checked;
            MailAddressLabel.Enabled = MailCheckBox.Checked;
        }

        private void BusinessRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BusinessRadioButtonChanged();
        }

        private void BusinessRadioButtonChanged()
        {
            NoteLabel.Visible = BusinessRadioButton.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("保存しますか？", "確認", YesNo, Question);

            if (result != Yes)
            {
                StatusText.Text = "キャンセルしました";
                return;
            }

            using (var sw = new StreamWriter("save.csv", true, GetEncoding("utf-8")))
            {
                sw.Write(IdTextBox.Text + ",");
                sw.Write(MailCheckBox.Checked + ",");
                sw.Write(MailAddressTextBox.Text + ",");
                sw.Write(BusinessRadioButton.Checked ? "1," : "0,");
                sw.Write(EnableComboBox.Text);
                sw.WriteLine("");
            }

            StatusText.Text = "保存しました";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
