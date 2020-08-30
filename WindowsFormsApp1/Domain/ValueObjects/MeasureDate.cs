using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public sealed class MeasureDate : ValueObject<MeasureDate>
    {
        public DateTime Value { get; private set; }
        public string DisplayValue => Value.ToString("yyyy/MM/dd HH:mm:ss");

        private MeasureDate() { }

        public static MeasureDate of(DateTime value)
        {
            return new MeasureDate() { Value = value };
        }

        protected override bool EqualsCore(MeasureDate other)
        {
            return this.Value == other.Value;
        }
    }
}
