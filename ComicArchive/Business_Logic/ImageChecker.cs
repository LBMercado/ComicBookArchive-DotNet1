using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class ImageChecker
    {
        private static readonly string[] _validExtensions = { ".jpg", ".bmp", ".gif", ".png", ".jpeg" }; //  etc

        public static bool IsImageExtension(string ext)
        {
            return _validExtensions.Contains(ext.ToLower(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
