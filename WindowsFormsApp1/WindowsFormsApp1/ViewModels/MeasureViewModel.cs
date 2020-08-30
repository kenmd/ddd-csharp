using Domain.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ViewModels
{
    public class MeasureViewModel : ViewModelBase
    {
        private string _measureValue = "--";
        private ISensorRepository sensorRepository;

        public string MeasureValue
        {
            get { return _measureValue; }
            set { SetProperty(ref _measureValue, value); }
        }

        public MeasureViewModel() : this(Factories.CreateSensorRepository())
        {
        }

        public MeasureViewModel(ISensorRepository sensorRepository)
        {
            this.sensorRepository = sensorRepository;
        }

        public void Measure()
        {
            var measureValue = sensorRepository.GetData();
            MeasureValue = measureValue.DisplayValue;
        }
    }
}
