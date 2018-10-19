using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Exceptions
{
    public class InvalidComicArchivePathException : Exception
    {
        public InvalidComicArchivePathException() { }

        public InvalidComicArchivePathException(string message) : base(message) { }
    }
}
