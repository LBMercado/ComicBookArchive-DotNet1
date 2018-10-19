using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;
using ComicArchive.Exceptions;

namespace ComicArchive.Application_Interface
{
    /// <summary>
    /// implements the sorting algorithms used to organize comic books
    /// </summary>
    public static class ComicSortingInterface
    {
        /// <summary>
        /// sort the comic book list based on selected sorting criteria
        /// </summary>
        /// <param name="comicBookList">
        /// List of ComicBook objects
        /// </param>
        /// <param name="sortOptions">
        /// Sorting criteria based on comic book property
        /// </param>
        /// <param name="sortOrder">
        /// Order in which the items should be sorted
        /// </param>
        /// <returns></returns>
        public static List<ComicBook> SortBy(List<ComicBook> comicBookList, 
                                            SortComicOption sortOptions,
                                            SortOrder sortOrder = SortOrder.Ascending)
        {
            if (comicBookList.Count() == 0)
                return comicBookList;

            switch (sortOptions)
            {
                case SortComicOption.Title:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicTitle).ToList();
                    break;
                case SortComicOption.Subtitle:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicSubTitle).ToList();
                    break;
                case SortComicOption.Issue:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicIssue).ToList();
                    break;
                case SortComicOption.Author:
                    comicBookList = comicBookList.Where(comicBook => comicBook.ComicAuthors != null)
                        .OrderBy(comicBook => string.Join(",", comicBook.ComicAuthors.OrderBy(name => name)))
                        .ToList();
                    break;
                case SortComicOption.Genre:
                    comicBookList = comicBookList.Where(comicBook => comicBook.ComicGenres != null)
                        .OrderBy(comicBook => string.Join(",", comicBook.ComicGenres.OrderBy(name => name)))
                        .ToList();
                    break;
                case SortComicOption.Publisher:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.Publisher).ToList();
                    break;
                case SortComicOption.RecentlyViewed:
                case SortComicOption.DateReleased:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicDateReleased).ToList();
                    break;
                case SortComicOption.DateAdded:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicDateAdded).ToList();
                    break;
                case SortComicOption.Rating:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.Rating).ToList();
                    break;
                case SortComicOption.ViewCount:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ViewCount).ToList();
                    break;
                default:
                    throw new InvalidSortOptionException("Provided sort option is invalid.");
            }

            switch(sortOrder)
            {
                case SortOrder.Ascending:
                    break;
                case SortOrder.Descending:
                    comicBookList.Reverse();
                    break;
                default:
                    throw new InvalidSortOptionException("Provided sort order is invalid.");
            }

            return comicBookList;
        }

        /// <summary>
        /// sort the user comic book list based on selected sorting criteria
        /// </summary>
        /// <param name="comicBookList">
        /// List of UserComicBook objects
        /// </param>
        /// <param name="sortOptions">
        /// Sorting criteria based on comic book property
        /// </param>
        /// <param name="sortOrder">
        /// Order in which the items should be sorted
        /// </param>
        /// <returns></returns>
        public static List<UserComicBook> SortBy(List<UserComicBook> comicBookList,
                                            SortComicOption sortOptions,
                                            SortOrder sortOrder = SortOrder.Ascending)
        {
            if (comicBookList.Count() == 0)
                return comicBookList;

            switch (sortOptions)
            {
                case SortComicOption.Title:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicTitle).ToList();
                    break;
                case SortComicOption.Subtitle:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicSubTitle).ToList();
                    break;
                case SortComicOption.Issue:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicIssue).ToList();
                    break;
                case SortComicOption.Author:
                    comicBookList = comicBookList.Where(comicBook => comicBook.ComicAuthors != null)
                        .OrderBy(comicBook => string.Join(",", comicBook.ComicAuthors.OrderBy(name => name.ToLower())))
                        .ToList();
                    break;
                case SortComicOption.Genre:
                    comicBookList = comicBookList.Where(comicBook => comicBook.ComicGenres != null)
                        .OrderBy(comicBook => string.Join(",", comicBook.ComicGenres.OrderBy(name => name.ToLower())))
                        .ToList();
                    break;
                case SortComicOption.Publisher:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.Publisher).ToList();
                    break;
                case SortComicOption.DateReleased:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicDateReleased).ToList();
                    break;
                case SortComicOption.DateAdded:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ComicDateAdded).ToList();
                    break;
                case SortComicOption.Rating:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.Rating).ToList();
                    break;
                case SortComicOption.ViewCount:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.ViewCount).ToList();
                    break;
                case SortComicOption.RecentlyViewed:
                    comicBookList = comicBookList.OrderBy(comicBook => comicBook.LastViewed).ToList();
                    break;
                default:
                    throw new InvalidSortOptionException("Provided sort option is invalid.");
            }

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    break;
                case SortOrder.Descending:
                    comicBookList.Reverse();
                    break;
                default:
                    throw new InvalidSortOptionException("Provided sort order is invalid.");
            }

            return comicBookList;
        }
    }

    public enum SortComicOption
    {
        Title,
        Subtitle,
        Issue,
        Author,
        Genre,
        Publisher,
        DateReleased,
        DateAdded,
        Rating,
        ViewCount,
        RecentlyViewed
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }
}
