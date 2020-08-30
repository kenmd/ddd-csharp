using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Fake
{
    internal sealed class MeasureFake : IMeasureRepository
    {
        private static List<MeasureEntity> entities;

        static MeasureFake()
        {
            entities = new List<MeasureEntity>
            {
                new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f),
                new MeasureEntity("guidB", "2017/01/01 14:00:00".ToDate(), 2.23456f),
            };
        }

        public IReadOnlyList<MeasureEntity> GetData()
        {
            return entities;
        }

        public MeasureEntity GetLatest()
        {
            return new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f);
        }

        public void Save(MeasureEntity measureEntity)
        {
            var index = entities.FindIndex(x => x.MeasureId == measureEntity.MeasureId);

            if (index >= 0)
            {
                entities[index] = measureEntity;
                return;
            }

            entities.Add(measureEntity);
        }
    }
}
