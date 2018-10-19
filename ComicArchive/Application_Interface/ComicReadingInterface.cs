using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;
using ComicArchive.Data_Access;
using ComicArchive.Exceptions;

namespace ComicArchive.Application_Interface
{
    /// <summary>
    /// provides an interface for reading comic book archives
    /// </summary>
    class ComicReadingInterface
    {
        //constants
        private const string accountFileName = @"accounts.xml";

        //data members
        private User loggedInUser;
        private ComicReader comicReader;
        private bool IsReadingComic;

        //progress reporting using ProgressDialog during
        //comic loading
        private ProgressDialog progDialog;
        private BackgroundWorker bgWorker;
        private bool backgroundProcessDone;

        /// <summary>
        /// provides an interface for reading comic book archives
        /// </summary>
        /// <param name="loggedInUser">
        /// the user who logged in
        /// </param>
        public ComicReadingInterface(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            IsReadingComic = false;
            comicReader = new ComicReader();
        }

        /// <summary>
        /// opens a new comic book for reading
        /// </summary>
        /// <param name="comicToOpen"></param>
        public void OpenComicBook(ComicBook comicToOpen)
        {
            //start of background thread stuff
            progDialog = new ProgressDialog();
            backgroundProcessDone = false;
            bgWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            comicReader.ReportProgress += ComicReader_ReportProgress;

            bgWorker.DoWork += delegate (object s, DoWorkEventArgs args)
            {
                comicReader.OpenComicBook(comicToOpen.GetArchivePath());
            };

            bgWorker.RunWorkerAsync();
            progDialog.ShowDialog();
            //end of background thread stuff

            //wait for comic book to load
            while (!backgroundProcessDone);
            IsReadingComic = true;
        }

        /// <summary>
        /// closes the current opened comic book
        /// </summary>
        public void CloseComicBook()
        {
            string archivePath = comicReader.GetComicBook().GetArchivePath();
            comicReader.CloseComic();
            IsReadingComic = false;
            comicReader.ClearCache(archivePath);
        }

        public ComicBook GetOpenedComicBook()
        {
            if (IsReadingComic)
                return comicReader.GetComicBook();
            else
                throw new NoComicOpenedException("User has not yet opened a comic book.");
        }

        public Image GetCurrentPageImage()
        {
            if (IsReadingComic)
                return comicReader.GetCurrentPage();
            else
                throw new NoComicOpenedException("User has not yet opened a comic book.");
        }

        public int GetCurrentPageNumber()
        {
            if (IsReadingComic)
                return comicReader.GetCurrentPageNumber();
            else
                throw new NoComicOpenedException("User has not yet opened a comic book.");
        }

        public void NextPage()
        {
            if (IsReadingComic)
                comicReader.NextPage();
        }

        public void PreviousPage()
        {
            if (IsReadingComic)
                comicReader.PreviousPage();
        }

        public void GoToCover()
        {
            if (IsReadingComic)
                comicReader.GoToCover();
        }

        public void GoToLast()
        {
            if (IsReadingComic)
                comicReader.GoToLast();
        }

        public int GetPageCount()
        {
            if (IsReadingComic)
                return comicReader.GetPageCount();
            else
                throw new NoComicOpenedException("User has not yet opened a comic book.");
        }

        /// <summary>
        /// clears the cache
        /// </summary>
        public void DoCleanup()
        {
            comicReader.ClearCache();
        }

        private void ComicReader_ReportProgress(object sender, ComicReader.ProgressArgs e)
        {
            progDialog.SetMaximumValueAsync(e.TotalRecords);
            progDialog.UpdateProgressAsync(e.TotalProcessed);
            progDialog.SetDescriptionAsync(e.Description);
            backgroundProcessDone = e.IsDoneProcessing;

            if (backgroundProcessDone)
                progDialog.BeginInvoke(new Action(() => progDialog.Close()));
        }
    }
}
