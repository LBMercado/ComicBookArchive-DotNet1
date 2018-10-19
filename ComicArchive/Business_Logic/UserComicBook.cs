using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;

namespace ComicArchive.Business_Logic
{
    public class UserComicBook : ComicBook
    {
        //what's unique to UserComicBook?
        //  -rating is not an average
        //  -there is a last viewed date of the comic book
        //  -there is a bookmark

        //set rating to 0, implies no rating
        public UserComicBook() : base()
        {
            LastViewed = DateTime.Now;
            Rating = 0.0f;
        }

        public bool UserHasRated()
        {
            if (Rating == 0.0f)
                return true;
            else
                return false;
        }

        public static UserComicBook MorphToUserComicBook (ComicBook cb)
        {
            UserComicBook returnCb = new UserComicBook();
            returnCb.SetArchivePath(cb.GetArchivePath());
            returnCb.ComicAuthors = cb.ComicAuthors;
            returnCb.ComicDateAdded = cb.ComicDateAdded;
            returnCb.ComicDateReleased = cb.ComicDateReleased;
            returnCb.ComicGenres = cb.ComicGenres;
            returnCb.ComicIssue = cb.ComicIssue;
            returnCb.ComicSubTitle = cb.ComicSubTitle;
            returnCb.ComicSynopsis = cb.ComicSynopsis;
            returnCb.ComicTitle = cb.ComicTitle;
            returnCb.ViewCount = cb.ViewCount;
            returnCb.Override_SetPageCount(cb.PageCount);
            returnCb.Publisher = cb.Publisher;
            return returnCb;
        }

        /// <summary>
        /// sets the rating,
        /// sets rating if it ranges from 1 -> some number
        /// </summary>
        /// <param name="rating">
        /// rating of comic book, it ranges from 1 -> some number
        /// </param>
        public new void RateComicBook(float rating)
        {
            //rating is valid if it ranges from 1 -> some number
            if(Math.Abs(rating) >= 1.0f)
                Rating = rating;
        }

        //properties
        public DateTime LastViewed { get; set; }
        public Bookmark BookMark { get; set; }
    }
}
