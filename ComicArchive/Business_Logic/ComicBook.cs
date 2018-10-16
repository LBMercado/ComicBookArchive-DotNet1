using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComicArchive.Business_Logic
{
    /// <summary>
    /// access a comic book directory
    /// </summary>
    class ComicBook
    {
        //data members
        private string[] pagePath; //paths of each page image in comic, sorted in order based on page number
        private string comicPath; //path of the comic book directory

        public ComicBook()
        {
            comicPath = ComicTitle = ComicSubTitle = ComicIssue = "";
            PageCount = 0;
        }

        /// <summary>
        /// specify the paths of the images for each page of the comic book
        /// </summary>
        /// <param name="pagePath">
        /// an array of strings representing the paths of each image
        /// </param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="InvalidImage"></exception>
        private void SetPagePaths(string[] pagePath)
        {
            //set number of pages
            PageCount = pagePath.Length;
            //initialize pagePath array
            this.pagePath = new string[PageCount];

            //check if each pagePath indeed does specify an image
            for (int index = 0; index < PageCount; index++)
            {
                //throw an error if file does not exist
                if (!File.Exists(pagePath[index]))
                {
                    FileNotFoundException exc = new FileNotFoundException("Specified file path is invalid: " + pagePath[index]);
                    throw exc;
                }
                //throw an error if file is not an image
                else if (!ImageChecker.IsImageExtension(Path.GetExtension(pagePath[index])))
                {
                    InvalidImage exc = new InvalidImage("Specified file is not an image: " + pagePath[index]);
                    throw exc;
                }
                //path has been verified as an image
                else
                {
                    this.pagePath[index] = pagePath[index];
                }
            }
        }

        /// <summary>
        /// get the path of the image specified by the index
        /// </summary>
        /// <param name="pageIndex">
        /// get the path of the image at pageIndex,
        /// range is from 0 -> PageCount - 1
        /// </param>
        /// <returns></returns>
        /// <exception cref="ComicArchivePagePathsNotSet"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public string GetPagePath(int pageIndex)
        {
            if (comicPath == "")
            {
                ComicArchivePagePathsNotSet exc = new ComicArchivePagePathsNotSet("No comic archive path has been set yet.");
                throw exc;
            }

            if (pageIndex <= PageCount && pageIndex >= 0)
                return pagePath[pageIndex];
            else
            {
                IndexOutOfRangeException exc = new IndexOutOfRangeException("Attempting to access an out of range page in comic book.");
                throw exc;
            }
        }

        /// <summary>
        /// set the path of the comic book directory
        /// </summary>
        /// <param name="comicPath">
        /// path specifying the location of the comic book directory containing the images of the comic book
        /// </param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void SetComicPath(string comicPath)
        {
            if (!Directory.Exists(comicPath))
            {
                DirectoryNotFoundException exc = new DirectoryNotFoundException("Specified directory path is invalid: " + comicPath);
                throw exc;
            }
            //verified as a directory for comic path
            this.comicPath = comicPath;

            //get the files inside the directory and set the pages of the comic book
            string[] fileList = Directory.GetFiles(comicPath);
            Array.Sort(fileList, StringComparer.InvariantCulture);
            SetPagePaths(fileList);
        }

        /// <summary>
        /// get the path to the comic archive
        /// </summary>
        /// <returns>
        /// empty string if not set, otherwise the path
        /// </returns>
        public string GetComicPath()
        {
            return comicPath;
        }

        /// <summary>
        /// the title of the comic book
        /// </summary>
        public string ComicTitle { get; set; }

        /// <summary>
        /// the subtitle of the comic book
        /// </summary>
        public string ComicSubTitle { get; set; }

        /// <summary>
        /// the issue title and/or number of the comic book
        /// </summary>
        public string ComicIssue { get; set; }

        /// <summary>
        /// get number of pages of the comic book
        /// </summary>
        public int PageCount { get; private set; }
    }

    public class ImageChecker
    {
        private static readonly string[] _validExtensions = { ".jpg", ".bmp", ".gif", ".png", ".jpeg" }; //  etc

        public static bool IsImageExtension(string ext)
        {
            return _validExtensions.Contains(ext.ToLower(), StringComparer.OrdinalIgnoreCase);
        }
    }

    public class InvalidImage : Exception
    {
        public InvalidImage()
        {

        }
        public InvalidImage(string message)
        : base(message)
        {

        }
    }

    public class InvalidComicArchive : Exception
    {
        public InvalidComicArchive()
        {

        }
        public InvalidComicArchive(string message)
        : base(message)
        {

        }
    }

    public class ComicArchivePagePathsNotSet : Exception
    {
        public ComicArchivePagePathsNotSet()
        {

        }
        public ComicArchivePagePathsNotSet(string message)
        : base(message)
        {

        }
    }
}
