using Domain.Exceptions;
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
    public partial class MeasureSaveView : BaseForm
    {
        public MeasureSaveView()
        {
            InitializeComponent();

            var viewModel = new MeasureSaveViewModel();

            MeasureDateTextBox.DataBindings.Add("Value", viewModel, nameof(viewModel.MeasureDate));
            MeasureValueTextBox.DataBindings.Add("Text", viewModel, nameof(viewModel.MeasureValue));
            UnitLabel.DataBindings.Add("Text", viewModel, nameof(viewModel.UnitLabel));

            SaveButton.Click += (sender, e) => {
                // validation logic should be in Domain inside Save() and catch here
                try
                {
                    viewModel.Save();
                    MessageBox.Show("Saved.");
                }
                catch (MessageException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }
    }
}
