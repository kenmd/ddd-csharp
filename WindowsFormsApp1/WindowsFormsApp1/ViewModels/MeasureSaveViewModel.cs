using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ViewModels
{
    public class MeasureSaveViewModel : ViewModelBase
    {
        private IMeasureRepository measureRepository;
        private DateTime measureDate;
        private string measureValue = "";

        public DateTime MeasureDate
        {
            get { return measureDate; }
            set { SetProperty(ref measureDate, value); }
        }

        public string MeasureValue
        {
            get { return measureValue; }
            set { SetProperty(ref measureValue, value); }
        }

        public string UnitLabel => Domain.ValueObjects.MeasureValue.UnitName;

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public MeasureSaveViewModel() : this(Factories.CreateMeasureRepository())
        {
            measureDate = GetDateTime();
        }

        public MeasureSaveViewModel(IMeasureRepository measureRepository)
        {
            this.measureRepository = measureRepository;
            measureDate = GetDateTime();
        }

        public void Save()
        {
            Guard.IsNullOrEmptyMessage(MeasureValue, "計測値を入力してください");

            var measureValue = Convert.ToSingle(MeasureValue);
            var entity = new MeasureEntity(Guid.NewGuid().ToString(), MeasureDate, measureValue);
            measureRepository.Save(entity);
        }
    }
}
