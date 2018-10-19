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
    /// implements the searching algorithms used to filter comic books
    /// </summary>
    public static class ComicSearchingInterface
    {
        /// <summary>
        /// filter the comic book list based on criteria
        /// </summary>
        /// <param name="comicBookList">
        /// List of ComicBook objects
        /// <param name="searchOption">
        /// search criteria based on comic book property
        /// </param>
        /// <param name="sortOrder">
        /// Order in which the items should be sorted
        /// </param>
        /// <returns></returns>
        public static List<ComicBook> Filter(List<ComicBook> comicBookList,
                                            string searchVal,
                                            SearchComicOption searchOption,
                                            MatchCase matchCase = MatchCase.No,
                                            SortOrder sortOrder = SortOrder.Ascending)
        {
            if (comicBookList.Count() == 0)
                return comicBookList;

            switch (searchOption)
            {
                case SearchComicOption.Title:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicTitle.ToLower().Contains(searchVal.ToLower())).ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicTitle == searchVal).ToList();
                    }
                    break;
                case SearchComicOption.Subtitle:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicSubTitle.ToLower().Contains(searchVal.ToLower())).ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicSubTitle == searchVal).ToList();
                    }
                    break;
                case SearchComicOption.Issue:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicIssue.ToLower().Contains(searchVal.ToLower())).ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(cb => cb.ComicIssue == searchVal).ToList();
                    }
                    break;
                case SearchComicOption.Author:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(comicBook => comicBook.ComicAuthors != null)
                        .Where(comicBook => string.Join("", comicBook.ComicAuthors).ToLower().Contains(searchVal.ToLower()))
                        .ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(comicBook => comicBook.ComicAuthors != null)
                        .Where(comicBook => comicBook.ComicAuthors.Any(author => author == searchVal))
                        .ToList();
                    }
                    break;
                case SearchComicOption.Genre:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(comicBook => comicBook.ComicGenres != null)
                        .Where(comicBook => string.Join("", comicBook.ComicGenres).ToLower().Contains(searchVal.ToLower()))
                        .ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(comicBook => comicBook.ComicGenres != null)
                        .Where(comicBook => comicBook.ComicGenres.Any(author => author == searchVal))
                        .ToList();
                    }
                    break;
                case SearchComicOption.Publisher:
                    if (matchCase == MatchCase.No)
                    {
                        comicBookList = comicBookList.Where(cb => cb.Publisher.ToLower().Contains(searchVal.ToLower())).ToList();
                    }
                    else
                    {
                        comicBookList = comicBookList.Where(cb => cb.Publisher == searchVal).ToList();
                    }
                    break;
                default:
                    throw new InvalidSearchOptionException("Provided search option is invalid.");
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

    public enum SearchComicOption
    {
        Title,
        Subtitle,
        Issue,
        Author,
        Genre,
        Publisher,
    }

    public enum MatchCase
    {
        Yes,
        No
    }
}
