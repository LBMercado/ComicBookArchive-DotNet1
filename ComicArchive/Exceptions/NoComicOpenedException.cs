using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Exceptions
{
    class NoComicOpenedException : Exception
    {
        public NoComicOpenedException() { }
        public NoComicOpenedException(string msg): base(msg)
        { }
    }
}
