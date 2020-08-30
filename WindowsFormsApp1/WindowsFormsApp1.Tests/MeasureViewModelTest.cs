using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using WindowsFormsApp1.ViewModels;
using FluentAssertions;
using Moq;
using Domain.Repositories;
using Domain.ValueObjects;

namespace WindowsFormsApp1.Tests
{
    public class MeasureViewModelTest
    {
        [Fact]
        public void GetDataTest()
        {
            // SensorMock class can be used here but Mock is more flexible
            var sensorMock = new Mock<ISensorRepository>();
            var viewModel = new MeasureViewModel(sensorMock.Object);

            viewModel.MeasureValue.Should().Be("--");

            sensorMock.Setup(x => x.GetData()).Returns(MeasureValue.of(1.23456f));
            viewModel.Measure();
            viewModel.MeasureValue.Should().Be("1.23m/s");

            sensorMock.Setup(x => x.GetData()).Returns(MeasureValue.of(2.2f));
            viewModel.Measure();
            viewModel.MeasureValue.Should().Be("2.2m/s");
        }
    }
}
