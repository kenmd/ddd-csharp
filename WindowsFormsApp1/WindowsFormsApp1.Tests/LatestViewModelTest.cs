using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Helpers;
using WindowsFormsApp1.ViewModels;
using Xunit;

namespace WindowsFormsApp1.Tests
{
    public class LatestViewModelTest
    {
        [Fact]
        public void GetLatestTest()
        {
            var measureMock = new Mock<IMeasureRepository>();
            var measure = new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f);
            measureMock.Setup(x => x.GetLatest()).Returns(measure);

            var viewModel = new LatestViewModel(measureMock.Object);

            viewModel.MeasureDate.Should().Be("2017/01/01 13:00:00");
            viewModel.MeasureValue.Should().Be("1.23m/s");
        }
    }
}
