using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionType ExceptionType { get; }

        public ExceptionBase(ExceptionType exceptionType, string message) : base(message)
        {
            ExceptionType = exceptionType;
        }
    }
}
