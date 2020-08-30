using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public static class Guard
    {
        public static void IsNullOrEmptyMessage(string value, string message)
        {
            IsNullOrEmptyMessage(value, message, ExceptionType.Information);
        }

        public static void IsNullOrEmptyMessage(string value, string message, ExceptionType exceptionType)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new MessageException(exceptionType, message);
            }
        }
    }
}
