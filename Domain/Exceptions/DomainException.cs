using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    //DomainException is a custom exception class that inherits from the Exception class and has a list of errors as a public property.
    //This class is used to represent Domain layer specific exceptions.
    public class DomainException : Exception
    {
        internal List<string> _errors;
        public List<string> Errors => _errors;

        public DomainException()
        { }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors=errors;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }



        public DomainException(string message) : base(message)
        { }
    }

}
