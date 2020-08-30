using Domain.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests
{
    public class MeasureValueTest
    {
        [Fact]
        public void EqualsTest()
        {
            var vo1 = MeasureValue.of(1.23456f);
            var vo2 = MeasureValue.of(1.23456f);

            vo1.Equals(vo2).Should().BeTrue();
        }

        [Fact]
        public void EqualEqualTest()
        {
            var vo1 = MeasureValue.of(1.23456f);
            var vo2 = MeasureValue.of(1.23456f);

            (vo1 == vo2).Should().BeTrue();
        }
    }
}
