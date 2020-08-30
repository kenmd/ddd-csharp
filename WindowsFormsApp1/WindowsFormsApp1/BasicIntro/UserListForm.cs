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
using static System.Text.Encoding;

namespace WindowsFormsApp1
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();

            InitializeDataGrid();

            UserDataGrid.Columns[0].HeaderText = "ID";
            UserDataGrid.Columns[1].HeaderText = "メール送信";
            UserDataGrid.Columns[2].HeaderText = "メールアドレス";
            UserDataGrid.Columns[3].HeaderText = "プラン";
            UserDataGrid.Columns[4].HeaderText = "有効無効";
        }

        private void InitializeDataGrid()
        {
            if (!File.Exists("save.csv"))
                return;

            var dtos = new List<UserInfoDto>();

            var lines = File.ReadAllLines("save.csv", GetEncoding("utf-8"));

            foreach (var line in lines)
            {
                var row = line.Split(',');

                var dto = new UserInfoDto()
                {
                    Id = row[0],
                    MailSend = row[1],
                    MailAddress = row[2],
                    Plan = row[3],
                    EnableText = row[4],
                };

                dtos.Add(dto);
            }

            UserDataGrid.DataSource = dtos;
        }
    }
}
