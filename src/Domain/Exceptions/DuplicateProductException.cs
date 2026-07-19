using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException( string productName) :base($"Product '{productName}' already exists.")
        {

        }
    }
}
