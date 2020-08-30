using Domain.Helpers;
using Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Tests
{
    public class MeasureDateTest
    {
        [Fact]
        public void EqualsTest()
        {
            var vo1 = MeasureDate.of("2020-08-29".ToDate());
            var vo2 = MeasureDate.of("2020-08-29".ToDate());

            vo1.Equals(vo2).Should().BeTrue();
        }

        [Fact]
        public void EqualEqualTest()
        {
            var vo1 = MeasureDate.of("2020-08-29".ToDate());
            var vo2 = MeasureDate.of("2020-08-29".ToDate());

            (vo1 == vo2).Should().BeTrue();
        }
    }
}
