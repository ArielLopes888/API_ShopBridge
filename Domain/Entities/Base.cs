using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //The Base class presented in the code is an abstract class that serves as a base for other classes
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _errors; // The _errors list is an internal list of strings that stores error messages that can be generated during object validation.
        public IReadOnlyCollection<string> Errors => _errors; //The Errors property is a read-only property that returns the list of errors stored in the _errors list.
        public abstract bool Validate(); //abstract method that must be implemented by derived classes to perform object data validation.
    }
}
