using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class InvalidComicArchiveException : Exception
    {
        public InvalidComicArchiveException() { }
        public InvalidComicArchiveException(string message)
        : base(message) { }
    }
}
