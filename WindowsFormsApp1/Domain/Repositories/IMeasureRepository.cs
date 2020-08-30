using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IMeasureRepository
    {
        MeasureEntity GetLatest();
        IReadOnlyList<MeasureEntity> GetData();
        void Save(MeasureEntity measureEntity);
    }
}
