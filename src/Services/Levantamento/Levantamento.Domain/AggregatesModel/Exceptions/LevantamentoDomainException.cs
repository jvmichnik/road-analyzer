using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.AggregatesModel.Exceptions
{
    public class LevantamentoDomainException : Exception
    {
        public LevantamentoDomainException()
        { }

        public LevantamentoDomainException(string message)
            : base(message)
        { }

        public LevantamentoDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
