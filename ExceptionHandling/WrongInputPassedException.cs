using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class WrongInputPassedException: Exception
    {
        public WrongInputPassedException(string message) : base(message)
        {
        }
        
        public WrongInputPassedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
