using Domain.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ViewModels
{
    public class MeasureListViewModel : ViewModelBase
    {
        private IMeasureRepository measureRepository;

        public MeasureListViewModel() : this(Factories.CreateMeasureRepository())
        {
        }

        public MeasureListViewModel(IMeasureRepository measureRepository)
        {
            this.measureRepository = measureRepository;

            foreach (var entity in measureRepository.GetData())
            {
                Measures.Add(new MeasureListViewModelMeasure(entity));
            }
        }

        public BindingList<MeasureListViewModelMeasure> Measures { get; set; }
            = new BindingList<MeasureListViewModelMeasure>();
    }
}
