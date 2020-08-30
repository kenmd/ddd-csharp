using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public static class Extensions
    {
        public static float ToSingle(this double value)
        {
            return Convert.ToSingle(value);
        }

        public static DateTime ToDate(this string value)
        {
            return Convert.ToDateTime(value);
        }
    }
}
