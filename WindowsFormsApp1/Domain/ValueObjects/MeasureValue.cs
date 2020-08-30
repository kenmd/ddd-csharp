using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public sealed class MeasureValue : ValueObject<MeasureValue>
    {
        public static readonly string UnitName = "m/s";

        public float Value { get; private set; }
        public string DisplayValue => Math.Round(Value, 2) + UnitName;

        private MeasureValue() { }

        public static MeasureValue of(float value)
        {
            return new MeasureValue() { Value = value };
        }

        protected override bool EqualsCore(MeasureValue other)
        {
            return this.Value == other.Value;
        }
    }
}
