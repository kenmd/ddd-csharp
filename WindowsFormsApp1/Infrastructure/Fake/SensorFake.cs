using Domain.Helpers;
using Domain.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Fake
{
    internal sealed class SensorFake : ISensorRepository
    {
        private Random random = new Random();

        public MeasureValue GetData()
        {
            return MeasureValue.of(random.Next(0, 3) + random.NextDouble().ToSingle());
        }
    }
}
