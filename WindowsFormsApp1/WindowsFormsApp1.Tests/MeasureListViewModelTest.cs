using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp1.ViewModels;
using Xunit;

namespace WindowsFormsApp1.Tests
{
    public class MeasureListViewModelTest
    {
        [Fact]
        public void GetMeasuresTest()
        {
            var measureMock = new Mock<IMeasureRepository>();
            var measures = new List<MeasureEntity> {
                new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f),
                new MeasureEntity("guidB", "2017/01/01 14:00:00".ToDate(), 2.23456f),
            };
            measureMock.Setup(x => x.GetData()).Returns(measures);

            var viewModel = new MeasureListViewModel(measureMock.Object);

            viewModel.Measures.Count.Should().Be(2);

            viewModel.Measures[0].MeasureDate.Should().Be("2017/01/01 13:00:00");
            viewModel.Measures[0].MeasureValue.Should().Be("1.23m/s");
        }
    }
}
