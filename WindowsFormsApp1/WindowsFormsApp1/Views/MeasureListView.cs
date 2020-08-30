using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ViewModels;

namespace WindowsFormsApp1.Views
{
    public partial class MeasureListView : BaseForm
    {
        public MeasureListView()
        {
            InitializeComponent();

            var viewModel = new MeasureListViewModel();

            MeasureDataGrid.DataBindings.Add("DataSource", viewModel, nameof(viewModel.Measures));
        }
    }
}
