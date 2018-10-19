using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() { }
        public UserDoesNotExistException(string message)
        : base(message) { }
    }
}
