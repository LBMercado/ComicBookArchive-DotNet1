﻿using System;
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
    public class ComicBook
    {
        //data members
        private string[] pagePath; //paths of each page image in comic, sorted in order based on page number
        private string comicPath; //path of the comic book directory (cached)
        private string archivePath; //path to the .cbz/.cbr comic book (archive)

        public ComicBook()
        {
            //set data members
            archivePath = comicPath = ComicTitle = ComicSubTitle = ComicIssue = "";
            ComicDateAdded = ComicDateReleased = DateTime.Now;
            Publisher = ComicSynopsis = "";
            ComicAuthors = null;
            ComicGenres = null;
            Rating = 0.0F;
            ViewCount = PageCount = 0;
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
                    InvalidImageException exc = new InvalidImageException("Specified file is not an image: " + pagePath[index]);
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
        /// <exception cref="ComicArchivePagePathsNotSetException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public string GetPagePath(int pageIndex)
        {
            if (comicPath == "")
            {
                ComicArchivePagePathsNotSetException exc = new ComicArchivePagePathsNotSetException("No comic archive path has been set yet.");
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
        /// set the page count manually instead of the SetComicPath method,
        /// use sparingly
        /// </summary>
        public void Override_SetPageCount(int pgCount)
        {
            PageCount = pgCount;
        }

        /// <summary>
        /// set the path of the comic book directory (cached)
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
        /// set the path of the comic book archive
        /// </summary>
        /// <param name="archivePath">
        /// filename and path to the cbz/cbr comic book archive
        /// </param>
        public void SetArchivePath(string archivePath)
        {
            if (File.Exists(archivePath))
                this.archivePath = archivePath;
            else
            {
                FileNotFoundException exc = new FileNotFoundException("Archive path set for comic book: <" + archivePath + "> is invalid.");
                throw exc;
            }
        }

        /// <summary>
        /// get the path to the comic directory
        /// </summary>
        /// <returns>
        /// empty string if not set, otherwise the path
        /// </returns>
        public string GetComicPath()
        {
            return comicPath;
        }

        /// <summary>
        /// get the path to the comic archive
        /// </summary>
        /// <returns>
        /// empty string if not set, otherwise the path
        /// </returns>
        public string GetArchivePath()
        {
            return archivePath;
        }

        /// <summary>
        /// rates the comic book, this takes the average of it and the current rating
        /// if no one has rated it yet
        /// </summary>
        public void RateComicBook(float rating)
        {
            //succeeding ratings
            if (ViewCount > 1)
                Rating = (Rating + rating) / 2;
            //first rating
            else
                Rating = rating;
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
        /// the date that the comic book was added to the application
        /// </summary>
        public DateTime ComicDateAdded { get; set; }

        /// <summary>
        /// the actual date that the comic book was released
        /// </summary>
        public DateTime ComicDateReleased { get; set; }

        /// <summary>
        /// synopsis or short summary of the comic's plot
        /// </summary>
        public string ComicSynopsis { get; set; }

        /// <summary>
        /// author/s of the comic book
        /// </summary>
        public string[] ComicAuthors { get; set; }

        /// <summary>
        /// genre that the comic book belongs
        /// </summary>
        public string[] ComicGenres { get; set; }

        /// <summary>
        /// rating of the comic book
        /// </summary>
        public float Rating { get; protected set; }

        /// <summary>
        /// number of user views on this comic book
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// publisher of the comic book
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// get number of pages of the comic book
        /// </summary>
        public int PageCount { get; private set; }
    }
}
