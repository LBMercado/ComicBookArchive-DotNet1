using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Exceptions
{
    public class InvalidSearchOptionException :Exception
    {
        public InvalidSearchOptionException() : base()
        { }
        public InvalidSearchOptionException(string msg) : base(msg)
        { }
    }
}
