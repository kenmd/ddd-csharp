using Domain.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ViewModels
{
    public class LatestViewModel : ViewModelBase
    {
        private IMeasureRepository measureRepository;
        private string measureDate = "";
        private string measureValue = "";

        public string MeasureDate
        {
            get { return measureDate; }
            set { SetProperty(ref measureDate, value); }
        }

        public string MeasureValue
        {
            get { return measureValue; }
            set { SetProperty(ref measureValue, value); }
        }

        public LatestViewModel() : this(Factories.CreateMeasureRepository())
        {
        }

        public LatestViewModel(IMeasureRepository measureRepository)
        {
            this.measureRepository = measureRepository;

            var entity = measureRepository.GetLatest();
            MeasureDate = entity.MeasureDate.DisplayValue;
            MeasureValue = entity.MeasureValue.DisplayValue;
        }
    }
}
