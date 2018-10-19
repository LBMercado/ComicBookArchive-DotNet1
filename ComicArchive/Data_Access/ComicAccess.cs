using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;
using System.Diagnostics;
using System.Xml.Linq;
using System.Drawing;
using SevenZip;

namespace ComicArchive.Data_Access
{
    /// <summary>
    /// provides a means of accessing and setting/reading comic book information
    /// </summary>
    public class ComicAccess : DataAccess
    {
        //data members
        private List<ComicBook> comicBookList;
        private string tempPath;

        /// <summary>
        /// provides a means of accessing and setting/reading comic book records
        /// </summary>
        /// <param name="comicBookRecordFileName">
        /// name of the XML file containing the comic book records
        /// </param>
        /// <param name="tempPath">
        /// path to directory for temporary storage of extracted files from the comics
        /// </param>
        public ComicAccess(string comicBookRecordFileName = "cbInfo.xml", string tempPath = "temp") : base(comicBookRecordFileName)
        {
            //set data members
            comicBookList = new List<ComicBook>();
            this.tempPath = Path.Combine(tempPath, "cover_cache");
            Directory.CreateDirectory(this.tempPath);

            //check if the comic book xml file exists
            if (PathIsValid())
            {
                //if it exists, get information from comics to load comic book information database
                ReadComicBookRecords();
                //cache the covers of the comic books
                ExtractCoversToCache();
            }
            //else, initialize new comic book records XML file, zero comic books imported
            else
            {
                CreateDataDirectory();
                ComicBookCount = 0;
            }
        }

        /// <summary>
        /// create the comic book records file + directory, does nothing if it already exists
        /// </summary>
        public new void CreateDataDirectory()
        {
            XDocument xdocument;
            Directory.CreateDirectory(root);

            xdocument = new XDocument(new XElement("ComicBooks"));
            xdocument.Save(filePath);
        }

        /// <summary>
        /// extracts the first page of the comics in the list to cache
        /// </summary>
        private void ExtractCoversToCache()
        {
            //direct the program to the dependency: 7z.dll (7z64.dll for 64-bit ver.)
            SevenZipBase.SetLibraryPath(Path.Combine(Environment.CurrentDirectory, "7z.dll"));

            //extract cover pages of all comic books in the list
            foreach (var comicBook in comicBookList)
            {
                string archivePath = comicBook.GetArchivePath();
                //check if cover has been cached already
                bool fileExists = false;
                try
                {
                    string fileName = Directory.GetFiles(tempPath, Path.GetFileNameWithoutExtension(archivePath) + ".*").Single();
                    fileExists = true;
                }
                catch (InvalidOperationException exc)
                {
                    Trace.WriteLine("File pertaining to <" + Path.GetFileNameWithoutExtension(archivePath) + "> does not exist. Proceeding to extract.");
                }
                //skip if cover page has already been extracted
                if (fileExists)
                    continue;

                //else,
                //extract archive to temporary folder
                using (var extractor = new SevenZipExtractor(archivePath))
                {
                    //get the sorted archive file list to get the first image
                    //verify that the cover page is an image
                    var fileNames = extractor.ArchiveFileData
                        .Where(
                        file => ImageChecker.IsImageExtension(
                            Path.GetExtension(file.FileName)
                            )
                            );
                    fileNames = fileNames.OrderBy(file => file.FileName);

                    //set the page count
                    comicBook.Override_SetPageCount(fileNames.Count());

                    //extract first image only
                    extractor.ExtractFiles(tempPath, fileNames.First().Index);
                    string newFileName = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(archivePath)
                        + Path.GetExtension(fileNames.First().FileName));
                    //rename file to name of archive file
                    File.Move(Path.Combine(tempPath, fileNames.First().FileName), newFileName);

                    //have to make sure the image is not within another directory
                    string[] dirs = Directory.GetDirectories(tempPath);

                    if (dirs.Length != 0)
                    {
                        string[] fileList;
                        foreach (var dir in dirs)
                        {
                            //get files in directory
                            fileList = Directory.GetFiles(dir);

                            //bring them to tempPath
                            foreach (var file in fileList)
                            {
                                string newFilePath = Path.Combine(tempPath, Path.GetFileName(file));
                                File.Move(file, newFilePath);
                            }
                            //delete the directory
                            Directory.Delete(dir);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// reads all the comic book records in the comic book records XML file
        /// </summary>
        private void ReadComicBookRecords()
        {
            if (PathIsValid())
            {
                //clear current records
                comicBookList = new List<ComicBook>();
                ComicBookCount = 0;

                //load the comic book record xml file
                XDocument xDocument = XDocument.Load(filePath);

                //remove invalid records first if there are any
                var InvalidElement = xDocument.Descendants("ComicBook").Where(el => !File.Exists(el.Element("ArchivePath").Value)).ToList();

                foreach (var node in InvalidElement)
                    node.Remove();

                foreach (XElement bookRecord in xDocument.Descendants("ComicBook"))
                {
                    //get metadata information
                    //this is the path w/filename to the .cbz/.cbr, NOT THE CACHE
                    XElement archivePath = bookRecord.Element("ArchivePath");

                    //get required elements for comic book information
                    XElement titleRead = bookRecord.Element("Title");
                    XElement subtitleRead = bookRecord.Element("Subtitle");
                    XElement issueRead = bookRecord.Element("Issue");
                    XElement dateAddedRead = bookRecord.Element("Date_Added");
                    XElement dateReleasedRead = bookRecord.Element("Date_Released");
                    XElement synopsisRead = bookRecord.Element("Synopsis");
                    XElement genreRead = bookRecord.Element("Genre");
                    XElement publisherRead = bookRecord.Element("Publisher");
                    XElement viewCountRead = bookRecord.Element("View_Count");
                    XElement avgRatingRead = bookRecord.Element("Avg_Rating");

                    XElement AuthorsRead = bookRecord.Element("Authors");
                    List<string> AuthorRead = new List<string>();
                    //have to go down the authors, there could be multiple authors
                    //do so if there are any
                    if (AuthorsRead.Descendants().Count() != 0)
                        foreach (XElement author in AuthorsRead.Descendants())
                        {
                            AuthorRead.Add(author.Value);
                        }

                    //set comic book read information
                    ComicBook comicBookRead = new ComicBook();
                    comicBookRead.SetArchivePath(archivePath.Value);
                    comicBookRead.ComicTitle = titleRead.Value;
                    comicBookRead.ComicSubTitle = subtitleRead.Value;
                    comicBookRead.ComicIssue = issueRead.Value;
                    comicBookRead.ComicDateAdded = DateTime.Parse(dateAddedRead.Value);
                    comicBookRead.ComicDateReleased = DateTime.Parse(dateReleasedRead.Value);
                    comicBookRead.ComicSynopsis = synopsisRead.Value;
                    comicBookRead.ComicGenre = genreRead.Value;
                    comicBookRead.Publisher = publisherRead.Value;
                    comicBookRead.ViewCount = int.Parse(viewCountRead.Value);
                    comicBookRead.RateComicBook(float.Parse(avgRatingRead.Value));

                    if (AuthorRead.Count() != 0)
                        comicBookRead.ComicAuthors = AuthorRead.ToArray();
                    else
                        comicBookRead.ComicAuthors = null;

                    //add comic book information to list
                    comicBookList.Add(comicBookRead);

                    //increment count of comic books available
                    ComicBookCount++;
                }
                
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// writes a new comic book record to the comic book records XML file, 
        /// if it doesn't exist yet, based on its archivePath
        /// </summary>
        public void WriteComicBookRecord(ComicBook newComicBook)
        {
            if (PathIsValid())
            {
                //check if it already exists, ignore write if it does
                if (ComicBookRecordExists(newComicBook.GetArchivePath()))
                {
                    return;
                }
                //load the comic book record XML file
                XDocument xDocument = XDocument.Load(filePath);

                //Authors has child nodes
                XElement newAuthors = new XElement("Authors");
                //need to set the Authors element
                if (newComicBook.ComicAuthors != null)
                    foreach (var author in newComicBook.ComicAuthors)
                    {
                        newAuthors.Add(new XElement("Author", author));
                    }

                XElement newComicBookRecord = new XElement(
                    "ComicBook",
                        new XElement("ArchivePath", newComicBook.GetArchivePath()),
                        new XElement("Title", newComicBook.ComicTitle),
                        new XElement("Subtitle", newComicBook.ComicSubTitle),
                        new XElement("Issue", newComicBook.ComicIssue),
                        new XElement("Date_Added", newComicBook.ComicDateAdded.ToShortDateString()),
                        new XElement("Date_Released", newComicBook.ComicDateReleased.ToShortDateString()),
                        new XElement("Synopsis", newComicBook.ComicSynopsis),
                        new XElement("Genre", newComicBook.ComicGenre),
                        new XElement("Publisher", newComicBook.Publisher),
                        new XElement("View_Count", newComicBook.ViewCount.ToString()),
                        new XElement("Avg_Rating", newComicBook.Rating.ToString()),
                        newAuthors
                        );
                //add to root of comic book record XML file
                xDocument.Root.Add(newComicBookRecord);

                //save the changes made to the comic book record XML file
                xDocument.Save(filePath);

                //update current records to reflect changes
                ComicBookCount++;
                comicBookList.Add(newComicBook);
                ExtractCoversToCache();
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records write operation.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// updates the comic book based on the archivePath in the comic book records XML file
        /// </summary>
        /// <param name="updatedComicBook"></param>
        /// <returns>
        /// true if successful, false otherwise
        /// </returns>
        public bool UpdateComicBookRecord(ComicBook updatedComicBook)
        {
            if (PathIsValid())
            {
                //load the comic book record xml file
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement bookRecord in xDocument.Descendants("ComicBook"))
                {
                    //get metadata information
                    //this is the path w/filename to the .cbz/.cbr, NOT THE CACHE
                    XElement archivePathRead = bookRecord.Element("ArchivePath");

                    //get required elements for comic book information
                    XElement titleRead = bookRecord.Element("Title");
                    XElement subtitleRead = bookRecord.Element("Subtitle");
                    XElement issueRead = bookRecord.Element("Issue");
                    XElement dateAddedRead = bookRecord.Element("Date_Added");
                    XElement dateReleasedRead = bookRecord.Element("Date_Released");
                    XElement synopsisRead = bookRecord.Element("Synopsis");
                    XElement genreRead = bookRecord.Element("Genre");
                    XElement publisherRead = bookRecord.Element("Publisher");
                    XElement viewCountRead = bookRecord.Element("View_Count");
                    XElement avgRatingRead = bookRecord.Element("Avg_Rating");

                    XElement AuthorsRead = bookRecord.Element("Authors");
                    List<string> AuthorRead = new List<string>();
                    //have to go down the authors, there could be multiple authors
                    //do so if it is not empty
                    if (AuthorsRead.Descendants().Count() != 0)
                        foreach (XElement author in AuthorsRead.Descendants())
                        {
                            AuthorRead.Add(author.Value);
                        }

                    //check if matching metadata
                    if (archivePathRead.Value == updatedComicBook.GetArchivePath())
                    {
                        //update contents
                        titleRead.Value = updatedComicBook.ComicTitle;
                        subtitleRead.Value = updatedComicBook.ComicSubTitle;
                        issueRead.Value = updatedComicBook.ComicIssue;
                        dateAddedRead.Value = updatedComicBook.ComicDateAdded.ToShortDateString();
                        dateReleasedRead.Value = updatedComicBook.ComicDateReleased.ToShortDateString();
                        synopsisRead.Value = updatedComicBook.ComicSynopsis;
                        genreRead.Value = updatedComicBook.ComicGenre;
                        publisherRead.Value = updatedComicBook.Publisher;
                        viewCountRead.Value = updatedComicBook.ViewCount.ToString();
                        avgRatingRead.Value = updatedComicBook.Rating.ToString();

                        //remove authors, if not empty
                        if (AuthorsRead.Descendants().Count() != 0)
                            AuthorsRead.Descendants().Remove();
                        //re-add authors, if any
                        if (updatedComicBook.ComicAuthors != null)
                            foreach (string newAuthor in updatedComicBook.ComicAuthors)
                            {
                                AuthorsRead.Add(new XElement("Author", newAuthor));
                            }

                        //save changes in XML document
                        xDocument.Save(filePath);

                        //re-update current records to reflect changes
                        ReadComicBookRecords();

                        return true;
                    }
                    
                }
                return false;

            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// removes the comic book based on the archivePath in the comic book records XML file
        /// </summary>
        /// <param name="archivePath">
        /// path to the comic archive
        /// </param>
        /// <returns>
        /// true if successful, false otherwise
        /// </returns>
        public bool RemoveComicBookRecord(string archivePath)
        {
            if (PathIsValid())
            {
                //load the comic book record xml file
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement bookRecord in xDocument.Descendants("ComicBook"))
                {
                    //get metadata information
                    //this is the path w/filename to the .cbz/.cbr, NOT THE CACHE
                    XElement archivePathRead = bookRecord.Element("ArchivePath");

                    //check if matching metadata
                    if (archivePathRead.Value == archivePath)
                    {
                        //remove the parent node of this element
                        bookRecord.Remove();

                        //save changes in XML document
                        xDocument.Save(filePath);

                        //re-update current records to reflect changes
                        ReadComicBookRecords();
                        return true;
                    }

                }
                return false;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// returns a list of ComicBook objects, if there are any
        /// </summary>
        /// <returns>
        /// a list of ComicBook objects
        /// </returns>
        public List<ComicBook> GetComicBookList()
        {
            return comicBookList;
        }

        /// <summary>
        /// get specific comic book based on archivePath 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public ComicBook GetComicBook(string archivePath)
        {
            string fullArchPath = Path.GetFullPath(archivePath);
            //return a null if there is nothing to search
            if (comicBookList.Count == 0)
            {
                return null;
            }
            else if (!File.Exists(archivePath))
            {
                FileNotFoundException exc = new FileNotFoundException("Parameter archivePath = <"+ archivePath +"> is invalid.");
                throw exc;
            }

            //iterate through comic book records
            //and return matching value
            return comicBookList.First(comicBook => comicBook.GetArchivePath() == fullArchPath);
        }

        /// <summary>
        /// creates a new comic book record based on the cbz/cbr path specified
        /// </summary>
        /// <param name="archivePath">
        /// path to the cbz/cbr archive file
        /// </param>
        public void InitializeNewComicBook(string archivePath)
        {
            if (!File.Exists(archivePath))
            {
                Trace.WriteLine("Parameter archivePath = " + "<" + archivePath + ">" + " is invalid, cannot proceed with comic book records write process.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Parameter archivePath = " + "<" + archivePath + ">" + " is invalid, cannot proceed with comic book records write process."
                    );
                throw exc;
            }

            if (PathIsValid())
            {
                ComicBook newComicBook = new ComicBook();

                //set default init values for newComicBook
                newComicBook.SetArchivePath(archivePath);
                newComicBook.ComicTitle = Path.GetFileNameWithoutExtension(archivePath);
                newComicBook.ComicSubTitle = "";
                newComicBook.ComicIssue = "";
                newComicBook.ComicDateAdded = DateTime.Now;
                newComicBook.ComicDateReleased = DateTime.Now;
                newComicBook.ComicSynopsis = "";
                newComicBook.ComicGenre = "";
                newComicBook.ComicAuthors = null;
                newComicBook.Publisher = "";
                newComicBook.ViewCount = 0;
                newComicBook.RateComicBook(0.0f);

                WriteComicBookRecord(newComicBook);
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records write operation.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// test for existence of comic book record based on archivePath
        /// </summary>
        /// <param name="archivePath">
        /// path to the comic book archive
        /// </param>
        /// <returns>
        /// true if it exists in the records, false otherwise
        /// </returns>
        public bool ComicBookRecordExists(string archivePath)
        {
            if (!File.Exists(archivePath))
            {
                Trace.WriteLine("Parameter archivePath = " + "<" + archivePath + ">" + " is invalid, cannot proceed with comic book records verification process.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Parameter archivePath = " + "<" + archivePath + ">" + " is invalid, cannot proceed with comic bookrecords verification process."
                    );
                throw exc;
            }

            if (PathIsValid())
            {
                //load the comic book record xml file
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement bookRecord in xDocument.Descendants("ComicBook"))
                {
                    //get metadata information
                    //this is the path w/filename to the .cbz/.cbr, NOT THE CACHE
                    XElement archivePathRead = bookRecord.Element("ArchivePath");

                    //check if matching metadata
                    if (archivePathRead.Value == archivePath)
                    {
                        return true;
                    }

                }
                return false;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with comic book records access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " cannot proceed with comic book records access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// gets the first page of the comic specified by the archive path
        /// </summary>
        /// <returns>
        /// an image instance of the cover page of the comic
        /// </returns>
        public Image GetComicFrontCover(string archivePath)
        {
            if (File.Exists(archivePath))
                return Image.FromFile(Directory.GetFiles(tempPath, Path.GetFileNameWithoutExtension(archivePath) + ".*").Single());
            else
            {
                FileNotFoundException exc = new FileNotFoundException("Parameter archivePath = <" + archivePath + "> is invalid.");
                throw exc;
            }
        }

        /// <summary>
        /// number of comic books in the library
        /// </summary>
        public int ComicBookCount { get; private set; }
    }
}
