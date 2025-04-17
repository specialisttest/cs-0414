using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsProject
{
    public class MyException : ArgumentOutOfRangeException
    {
        public int InvalidData { get; init; }

        public MyException(int invalidData, string? message = null, Exception? innerException = null)
            : base(message, innerException)
        { 
            InvalidData = invalidData;  
        }
    }
}
