using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class ComicArchivePagePathsNotSetException : Exception
    {
        public ComicArchivePagePathsNotSetException() { }
        public ComicArchivePagePathsNotSetException(string message)
        : base(message) { }
    }
}
