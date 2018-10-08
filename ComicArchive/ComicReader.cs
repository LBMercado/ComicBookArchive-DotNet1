using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SevenZip;

namespace ComicArchive
{
    class ComicReader
    {
        //data members
        private string[] pagePath; //paths of each page image in comic, sorted in order based on page number
        private string comicPath; //path of the comic archive (.cbz/.cbr)
        private string comicTitle, comicSubTitle, comicIssue; //name of the comic, subtitle, and issue name
        private string tempPath; //path to store temporary extracted archives
        private int pageCount, currentPage; //number of pages & current page
        //NOTE: current page IS NOT array index, subtract 1 to make it array-compatible

        /// <summary>
        /// Initialize a comic reader, opens the file on demand
        /// </summary>
        /// <param name="comicPath">
        /// The directory/path where the comic is found
        /// </param>
        /// <param name="tempPath">
        /// Temporary storage for extracted files from the comic
        /// </param>
        public ComicReader(string comicPath, string tempPath = "temp")
        {
            //create temp folder
            this.tempPath = tempPath;
            Directory.CreateDirectory(tempPath);

            //create archive in temporary folder pertaining to comic, and make it the new tempPath
            tempPath = Path.Combine(tempPath,
                new FileInfo(comicPath).Name);
            Directory.CreateDirectory(tempPath);

            this.comicPath = comicPath;

            //direct the program to the dependency: 7z.dll
            SevenZipBase.SetLibraryPath(Path.Combine(Environment.CurrentDirectory,"7z.dll"));

            //extract archive to temporary folder
            using (var extractor = new SevenZipExtractor(comicPath))
            {
                //don't include folders in the page count
                pageCount = extractor.ArchiveFileData.Count(file => !file.IsDirectory);
                pagePath = new string[pageCount];

                //write and get all image paths
                int pagePathIndexAdjust = 0;
                for (var i = 0; i < extractor.ArchiveFileData.Count; i++)
                {
                    if (!extractor.ArchiveFileData[i].IsDirectory)
                    {
                        pagePath[i - pagePathIndexAdjust] = Path.Combine(tempPath, extractor.ArchiveFileData[i].FileName);
                        extractor.ExtractFiles(tempPath, extractor.ArchiveFileData[i].Index);
                    }
                    else
                    {
                        pagePathIndexAdjust++;
                    }
                }
            }
            //sort the pagePath as a good measure
            Array.Sort(pagePath, StringComparer.InvariantCulture);

            //set current page as cover page(first page)
            currentPage = 1;

            comicTitle = comicSubTitle = comicIssue = "";
        }

        /// <summary>
        /// Opens a new comic, this closes the current one
        /// </summary>
        /// <param name="comicPath"></param>
        public void OpenNewComic(string comicPath)
        {
            tempPath = Path.GetFullPath(Path.Combine(tempPath, @"..\")); //go one level up

            //create archive in temporary folder pertaining to comic, and make it the new tempPath
            tempPath = Path.Combine(tempPath,
                new FileInfo(comicPath).Name);
            Directory.CreateDirectory(tempPath);

            this.comicPath = comicPath;

            //direct the program to the dependency: 7z.dll
            SevenZipBase.SetLibraryPath(Path.Combine(Environment.CurrentDirectory, "7z.dll"));

            //extract archive to temporary folder
            using (var extractor = new SevenZipExtractor(comicPath))
            {
                //don't include folders in the page count
                pageCount = extractor.ArchiveFileData.Count(file => !file.IsDirectory);
                pagePath = new string[pageCount];

                //write and get all image paths
                int pagePathIndexAdjust = 0;
                for (var i = 0; i < extractor.ArchiveFileData.Count; i++)
                {
                    if (!extractor.ArchiveFileData[i].IsDirectory)
                    {
                        pagePath[i - pagePathIndexAdjust] = Path.Combine(tempPath, extractor.ArchiveFileData[i].FileName);
                        extractor.ExtractFiles(tempPath, extractor.ArchiveFileData[i].Index);
                    }
                    else
                    {
                        pagePathIndexAdjust++;
                    }
                }
            }
            //sort the pagePath as a good measure
            Array.Sort(pagePath, StringComparer.InvariantCulture);

            //set current page as cover page(first page)
            currentPage = 1;

            comicTitle = comicSubTitle = comicIssue = "";

        }

        /// <summary>
        /// return number of pages of the comic
        /// </summary>
        /// <returns></returns>
        public int GetPageCount()
        {
            return pageCount;
        }

        /// <summary>
        /// return an image instance of the current page in the comic
        /// </summary>
        /// <returns></returns>
        public Image GetCurrentPage()
        {
            Image comicImg = Image.FromFile(pagePath[currentPage - 1]);
            int width = comicImg.Width;
            int height = comicImg.Height;
            return comicImg;
        }

        /// <summary>
        /// increment currentPage
        /// </summary>
        public void NextPage()
        {
            if (currentPage < pageCount)
                currentPage++;
        }

        /// <summary>
        /// decrement currentPage
        /// </summary>
        public void PreviousPage()
        {
            if (currentPage > 0)
                currentPage--;
        }

        /// <summary>
        /// checks if current page is equal to the number of pages
        /// </summary>
        /// <returns></returns>
        public bool IsLastPage()
        {
            if (currentPage == pageCount)
                return true;
            else
                return false;
        }

        /// <summary>
        /// checks if current page is 1
        /// </summary>
        /// <returns></returns>
        public bool IsAtCover()
        {
            if (currentPage == 1)
                return true;
            else
                return false;
        }
    }
}
