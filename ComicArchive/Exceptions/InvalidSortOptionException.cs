using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Exceptions
{
    class InvalidSortOptionException : Exception
    {
        public InvalidSortOptionException() : base()
        { }
        public InvalidSortOptionException(string msg) : base(msg)
        { }
    }
}
