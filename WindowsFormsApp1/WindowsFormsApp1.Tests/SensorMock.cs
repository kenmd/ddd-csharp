using Domain.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1.Tests
{
    /// <summary>
    /// this is sample plain mock class without Moq
    /// </summary>
    internal sealed class SensorMock : ISensorRepository
    {
        public MeasureValue GetData()
        {
            return MeasureValue.of(1.23456f);
        }
    }
}
