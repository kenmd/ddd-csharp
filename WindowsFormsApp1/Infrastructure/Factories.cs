using Domain.Repositories;
using Infrastructure.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class Factories
    {
        public static ISensorRepository CreateSensorRepository()
        {
            return new SensorFake();
        }

        public static IMeasureRepository CreateMeasureRepository()
        {
            return new MeasureFake();
        }
    }
}
