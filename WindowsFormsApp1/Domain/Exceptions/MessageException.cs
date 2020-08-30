using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class MessageException : ExceptionBase
    {
        public MessageException(ExceptionType exceptionType, string message) : base(exceptionType, message)
        {
        }
    }
}
