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
    public partial class LatestView : Form
    {
        public LatestView()
        {
            InitializeComponent();

            var viewModel = new LatestViewModel();

            // show MeasureDate in form title
            this.DataBindings.Add("Text", viewModel, nameof(viewModel.MeasureDate));
            // show MeasureValue in label
            MeasureValueLabel.DataBindings.Add("Text", viewModel, nameof(viewModel.MeasureValue));
        }
    }
}
