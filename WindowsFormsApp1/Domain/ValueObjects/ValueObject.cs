﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        public override bool Equals(object obj)
        {
            // the original code is generated by Visual Studio
            return obj is T value && EqualsCore(value);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
