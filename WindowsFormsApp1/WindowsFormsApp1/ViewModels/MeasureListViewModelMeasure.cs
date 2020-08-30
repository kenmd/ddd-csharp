using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ViewModels
{
    public class MeasureListViewModelMeasure
    {
        private MeasureEntity measureEntity;

        public string MeasureDate => measureEntity.MeasureDate.DisplayValue;
        public string MeasureValue => measureEntity.MeasureValue.DisplayValue;

        public MeasureListViewModelMeasure(MeasureEntity measureEntity)
        {
            this.measureEntity = measureEntity;
        }
    }
}
