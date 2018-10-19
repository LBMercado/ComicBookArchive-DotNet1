using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SevenZip;
using ComicArchive.Business_Logic;
using ComicArchive.Exceptions;

namespace ComicArchive.Data_Access
{
    /// <summary>
    /// provides a means of accessing and reading comic books via user interface
    /// </summary>
    public class ComicReader
    {
        //data members
        private ComicBook comicBook;
        private string archivePath; //path of the comic archive (.cbz/.cbr)
        private string tempPath; //path to store temporary extracted archives
        private int currentPage; //current page in the comic book
        //NOTE: current page IS NOT array index, subtract 1 to make it array-compatible

        /// <summary>
        /// initialize a comic reader, opens the file on demand
        /// </summary>
        /// <param name="archivePath">
        /// the directory/path where the comic is found
        /// </param>
        /// <param name="tempPath">
        /// temporary storage for extracted files from the comic
        /// </param>
        public ComicReader(string archivePath = "", string tempPath = "temp")
        {
            comicBook = null;
            this.archivePath = archivePath;
            this.tempPath = tempPath;
        }

        /// <summary>
        /// Open the comic based on comicPath, this closes the current one
        /// </summary>
        public void OpenComic()
        {
            //throw an error if the archive path is invalid
            if (!ArchivePathIsValid())
            {
                InvalidComicArchivePathException exc = new InvalidComicArchivePathException("Set archivePath is invalid.");
                throw exc;
            }
            
            //set extract folder in temporary folder pertaining to comic, and make it the new tempPath
            //this will be the cache for the comic book
            tempPath = Path.Combine(tempPath,
                Path.GetFileNameWithoutExtension(archivePath));

            //open a new comic book
            comicBook = new ComicBook();

            //check if comic book has already been cached to temp folder
            if (Directory.Exists(tempPath) && Directory.GetFiles(tempPath).Length != 0)
            {
                //don't extract anymore, load the comic book from cache
                comicBook.SetComicPath(tempPath);
                //set current page as cover page(first page)
                currentPage = 1;
                //nothing to report
                ReportProgress?.Invoke(this, new ProgressArgs
                {
                    TotalProcessed = 100,
                    TotalRecords = 100,
                    Description = "Done!",
                    IsDoneProcessing = true
                });
            }
            //comic book has not been cached yet, perform archive extraction
            else
            {
                //create extract folder in temporary folder pertaining to comic
                Directory.CreateDirectory(tempPath);

                //direct the program to the dependency: 7z.dll (7z64.dll for 64-bit)
                SevenZipBase.SetLibraryPath(Path.Combine(Environment.CurrentDirectory, "7z.dll"));

                //extract archive to temporary folder
                using (var extractor = new SevenZipExtractor(archivePath))
                {
                    //extract all images in temporary folder
                    for (var i = 0; i < extractor.ArchiveFileData.Count; i++)
                    {
                        //check if file to be extracted is an image
                        string fileToBeExtractedExtension = Path.GetExtension(extractor.ArchiveFileData[i].FileName);
                        if (ImageChecker.IsImageExtension(fileToBeExtractedExtension))
                        {
                            //extract the file
                            extractor.ExtractFiles(tempPath, extractor.ArchiveFileData[i].Index);
                        }

                        //report progress that a file has been processed
                        ReportProgress?.Invoke(this, new ProgressArgs
                        {
                            TotalProcessed = i + 1,
                            TotalRecords = extractor.ArchiveFileData.Count,
                            Description = "Extracting comic book to cache.",
                            IsDoneProcessing = false
                        });
                    }
                }

                //move images outside the directories, if there are any
                string[] comicDirs = Directory.GetDirectories(tempPath);
                if (comicDirs.Length != 0)
                {

                    string[] fileList;
                    foreach (var dir in comicDirs)
                    {
                        //get files in directory
                        fileList = Directory.GetFiles(dir);
                        //start a new report
                        //report progress that a file has been processed
                        ReportProgress?.Invoke(this, new ProgressArgs
                        {
                            TotalProcessed = 0,
                            TotalRecords = fileList.Length,
                            Description = "Rearranging comic book.",
                            IsDoneProcessing = false
                        });

                        int filesProcessed = 0;
                        //bring them to tempPath
                        foreach (var file in fileList)
                        {
                            string newFilePath = Path.Combine(tempPath, Path.GetFileName(file));
                            File.Move(file, newFilePath);
                            ReportProgress?.Invoke(this, new ProgressArgs
                            {
                                TotalProcessed = filesProcessed,
                                TotalRecords = fileList.Length,
                                Description = "Rearranging comic book.",
                                IsDoneProcessing = false
                            });
                            filesProcessed++;
                        }
                        //delete the directory
                        Directory.Delete(dir);
                    }
                }

                //set the comic book path
                comicBook.SetComicPath(tempPath);

                //set current page as cover page(first page)
                currentPage = 1;

                //end reporting
                ReportProgress?.Invoke(this, new ProgressArgs
                {
                    TotalProcessed = 100,
                    TotalRecords = 100,
                    Description = "Done!",
                    IsDoneProcessing = true
                });
                //go back to temp directory
                tempPath = Path.Combine(tempPath, @"..\");
            }
        }

        /// <summary>
        /// Closes the opened comic book, sets it to null
        /// </summary>
        public void CloseComic()
        {
            comicBook = null;
        }

        /// <summary>
        /// set the archivePath of the comic reader
        /// </summary>
        /// <param name="archivePath">
        /// filename and the path to the cbr/cbz archive
        /// </param>
        public void SetArchivePath(string archivePath)
        {
            this.archivePath = archivePath;
        }

        /// <summary>
        /// return number of pages of the comic
        /// </summary>
        /// <returns></returns>
        public int GetPageCount()
        {
            return comicBook.PageCount;
        }

        /// <summary>
        /// return an image instance of the current page in the comic
        /// </summary>
        /// <returns></returns>
        public Image GetCurrentPage()
        {
            Image comicImg = Image.FromFile(comicBook.GetPagePath(currentPage - 1));
            int width = comicImg.Width;
            int height = comicImg.Height;
            return comicImg;
        }

        /// <summary>
        /// return the current page number
        /// </summary>
        /// <returns></returns>
        public int GetCurrentPageNumber()
        {
            return currentPage;
        }

        /// <summary>
        /// increment currentPage
        /// </summary>
        public void NextPage()
        {
            if (currentPage < comicBook.PageCount)
                currentPage++;
        }

        /// <summary>
        /// decrement currentPage
        /// </summary>
        public void PreviousPage()
        {
            if (currentPage > 1)
                currentPage--;
        }

        /// <summary>
        /// checks if current page is equal to the number of pages
        /// </summary>
        /// <returns></returns>
        public bool IsLastPage()
        {
            if (currentPage == comicBook.PageCount)
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

        /// <summary>
        /// set currentPage to last page of comic book
        /// </summary>
        public void GoToLast()
        {
            currentPage = comicBook.PageCount;
        }

        /// <summary>
        /// set currentPage to first page of comic book
        /// </summary>
        public void GoToCover()
        {
            currentPage = 1;
        }

        /// <summary>
        /// get title of comic book
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return comicBook.ComicTitle + ": " + comicBook.ComicSubTitle;
        }

        /// <summary>
        /// returns the comic book that has been opened.
        /// </summary>
        /// <returns></returns>
        public ComicBook GetComicBook()
        {
            return comicBook;
        }

        /// <summary>
        /// clear the comic book cache
        /// </summary>
        public void ClearCache()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <summary>
        /// clears the cache for the specified cbr/cbz archive file, if it exists
        /// </summary>
        /// <param name="archivePath"></param>
        public void ClearCache(string archivePath)
        {
            string cacheDir = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(archivePath));
            if (Directory.Exists(cacheDir))
            {
                Directory.Delete(cacheDir, true);
            }
        }

        /// <summary>
        /// checks whether archivePath is pointing to a cbr/cbz file that exists
        /// </summary>
        /// <returns>
        /// true if archivePath is valid, false otherwise
        /// </returns>
        private bool ArchivePathIsValid()
        {
            if (File.Exists(archivePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Events_ComicReader
        //progress reporting methods
        public delegate void ReportProgressEventHandler(object sender, ProgressArgs args);

        public event ReportProgressEventHandler ReportProgress;

        public class ProgressArgs : EventArgs
        {
            public int TotalProcessed { get; set; }
            public int TotalRecords { get; set; }
            public string Description { get; set; }
            public bool IsDoneProcessing { get; set; }
        }
        #endregion
    }
}
