using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComicArchive.Business_Logic
{
    public class ComicLibrary
    {
        //rating here is defined unique per user

        //data members
        private List<UserComicBook> comicBook;

        public ComicLibrary()
        {
            comicBook = new List<UserComicBook>();
            Count = 0;
        }

        //methods
        public bool ComicBookExists(string archivePath)
        {
            return comicBook.Any(
                cb => Path.GetFullPath(cb.GetArchivePath()) == Path.GetFullPath(archivePath)
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivePath">
        /// filename and path to the cbr/cbz comic archive
        /// </param>
        /// <returns>
        /// UserComicBook object if comic book exists, null otherwise
        /// </returns>
        public UserComicBook GetComicBook(string archivePath)
        {
            archivePath = Path.GetFullPath(archivePath);
            if (ComicBookExists(archivePath))
            {
                var returnCb = comicBook.Where(cb => cb.GetArchivePath() == archivePath).Single();
                int indexOfReturnCb = comicBook.IndexOf(returnCb);
                comicBook[indexOfReturnCb].ViewCount++;
                comicBook[indexOfReturnCb].LastViewed = DateTime.Now;

                return returnCb;
            }
                
            else
                return null;
        }

        public UserComicBook[] GetAllComicBooks()
        {
            return comicBook.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newComicBook"></param>
        /// <returns>
        /// true if comic book doesn't exist, false otherwise
        /// </returns>
        public bool AddComicBook(UserComicBook newComicBook)
        {
            if (!ComicBookExists(newComicBook.GetArchivePath()))
            {
                comicBook.Add(newComicBook);
                Count++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// true if comic book exists, false otherwise
        /// </returns>
        /// <param name="archivePath">
        /// filename and path to the cbr/cbz comic archive
        /// </param>
        public bool RemoveComicBook(string archivePath)
        {
            archivePath = Path.GetFullPath(archivePath);
            if (ComicBookExists(archivePath))
            {
                var cbToRemove = comicBook.Where(cb => cb.GetArchivePath() == archivePath).Single();
                comicBook.Remove(cbToRemove);
                Count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// rates the comic book
        /// </summary>
        /// <param name="archivePath">
        /// filename and path to the cbr/cbz comic archive
        /// </param>
        /// <returns>
        /// true if comic book exists, false otherwise
        /// </returns>
        public bool RateComicBook(string archivePath, int rating)
        {
            archivePath = Path.GetFullPath(archivePath);
            if (ComicBookExists(archivePath))
            {
                var cbToRate = comicBook.Where(cb => cb.GetArchivePath() == archivePath).Single();
                int indexOfCbToRate = comicBook.IndexOf(cbToRate);

                comicBook[indexOfCbToRate].RateComicBook(rating);

                return true;
            }
            else
            {
                return false;
            }
        }

        //properties

        /// <summary>
        /// number of comic books in library
        /// </summary>
        public int Count { get; private set; }
    }
}
