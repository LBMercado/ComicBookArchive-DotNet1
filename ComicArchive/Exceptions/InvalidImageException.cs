using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class InvalidImageException : Exception
    {
        public InvalidImageException() { }
        public InvalidImageException(string message)
        : base(message) { }
    }
}
