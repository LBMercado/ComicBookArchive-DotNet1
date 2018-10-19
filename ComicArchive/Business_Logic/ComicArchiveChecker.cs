using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class ComicArchiveChecker
    {
        private static readonly string[] _validExtensions = { ".cbz", ".cbr"}; //  etc

        public static bool IsComicArchiveExtension(string ext)
        {
            return _validExtensions.Contains(ext.ToLower(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
