using Domain.Entities;
using Domain.Exceptions;
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
    public class MeasureSaveViewModelTest
    {
        [Fact]
        public void SaveMeasureTest()
        {
            // this also use Mock but with CallBase
            // viewModel = new MeasureSaveViewModel();

            var repositoryMock = new Mock<IMeasureRepository>();
            var viewModelMock = new Mock<MeasureSaveViewModel>(repositoryMock.Object);

            viewModelMock.CallBase = true;  // mock only one virtual method
            viewModelMock.Setup(x => x.GetDateTime()).Returns("2017/01/03 13:00:00".ToDate());

            var viewModel = viewModelMock.Object;

            // check initial data when open the screen
            viewModel.MeasureDate.Should().Be("2017/01/03 13:00:00".ToDate());
            viewModel.MeasureValue.Should().Be("");
            viewModel.UnitLabel.Should().Be("m/s");

            // when saving data
            viewModel.MeasureDate = "2017/01/03 12:50:00".ToDate();
            viewModel.MeasureValue = "1.23456";

            // verify the values to be saved are good
            repositoryMock.Setup(x => x.Save(It.IsAny<MeasureEntity>()))
                .Callback<MeasureEntity>(saveValue =>
                {
                    // saveValue.MeasureId.Should().Be("?");
                    saveValue.MeasureDate.Value.Should().Be("2017/01/03 12:50:00".ToDate());
                    saveValue.MeasureValue.Value.Should().Be(1.23456f);
                });

            viewModel.Save();

            // verify all tests are tested
            repositoryMock.VerifyAll();
        }

        [Fact]
        public void SaveMeasureErrorTest()
        {
            var repositoryMock = new Mock<IMeasureRepository>();
            var viewModelMock = new Mock<MeasureSaveViewModel>(repositoryMock.Object);

            viewModelMock.Setup(x => x.GetDateTime()).Returns("2017/01/03 13:00:00".ToDate());

            var viewModel = viewModelMock.Object;

            Action action = () => { viewModel.Save(); };

            action.Should().Throw<MessageException>()
                .WithMessage("計測値を入力してください");
        }
    }
}
