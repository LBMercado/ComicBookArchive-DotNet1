using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComicArchive.Data_Access;
using ComicArchive.Business_Logic;

namespace ComicArchive
{
    public partial class ComicView : Form
    {
        //constants
        private const string accountFileName = @"accounts.xml";
        private const string cbResourceDirectory = @"Resources/comicbooks";

        //data members
        private ComicReader comReader;
        private string comicPath;
        private ProgressDialog progDialog;
        private BackgroundWorker bgWorker;
        private bool backgroundProcessDone;
        private User loggedInUser;
        private UserComicBook myCb;
        private Bookmark myBm;
        private ExtendedAccountAccess accountManager;

        public ComicView(string comicPath, User loggedInUser)
        {
            this.comicPath = comicPath;
            this.loggedInUser = loggedInUser;
            InitializeComponent();
            accountManager = new ExtendedAccountAccess(accountFileName);
            //bookmarks
            myCb = loggedInUser.MyComicLibrary.GetComicBook(comicPath);
            myCb.ViewCount--;
            myBm = myCb.BookMark;
            foreach (var bmPage in myCb.BookMark.GetPageNums())
            {
                cmbBxBookmark.Items.Add(bmPage.ToString());
            }
            lblTitle.Text = myCb.ComicTitle + " : " + myCb.ComicSubTitle + "\n" + myCb.ComicIssue;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoToPrevious_Click(object sender, EventArgs e)
        {
            comReader.PreviousPage();
            picBxComicScreen.Image.Dispose();
            picBxComicScreen.Image = comReader.GetCurrentPage();
            lblPageNumber.Text = "Page "+ comReader.GetCurrentPageNumber() +" of " + comReader.GetPageCount().ToString();
            PageChanged();
        }

        private void btnGoToNext_Click(object sender, EventArgs e)
        {
            comReader.NextPage();
            picBxComicScreen.Image.Dispose();
            picBxComicScreen.Image = comReader.GetCurrentPage();
            lblPageNumber.Text = "Page " + comReader.GetCurrentPageNumber() + " of " + comReader.GetPageCount().ToString();
            PageChanged();
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

        private void btnGoToFirst_Click(object sender, EventArgs e)
        {
            if (!comReader.IsAtCover())
            {
                comReader.GoToCover();
                picBxComicScreen.Image.Dispose();
                picBxComicScreen.Image = comReader.GetCurrentPage();
                lblPageNumber.Text = "Page 1 of " + comReader.GetPageCount().ToString();
            }
            PageChanged();
        }

        private void btnGoToLast_Click(object sender, EventArgs e)
        {
            if (!comReader.IsLastPage())
            {
                comReader.GoToLast();
                picBxComicScreen.Image.Dispose();
                picBxComicScreen.Image = comReader.GetCurrentPage();
                lblPageNumber.Text = "Page " + comReader.GetPageCount().ToString() + " of " + comReader.GetPageCount().ToString();
            }
            PageChanged();
        }

        private void ComicView_Load(object sender, EventArgs e)
        {
            comReader = new ComicReader();

            //start of background thread stuff
            progDialog = new ProgressDialog();
            backgroundProcessDone = false;
            bgWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            comReader.ReportProgress += ComicReader_ReportProgress;

            bgWorker.DoWork += delegate (object s, DoWorkEventArgs args)
            {
                comReader.OpenComicBook(comicPath);
            };

            bgWorker.RunWorkerAsync();
            progDialog.ShowDialog();
            //end of background thread stuff

            //wait for comic book to load
            while (!backgroundProcessDone) ;

            picBxComicScreen.SizeMode = PictureBoxSizeMode.Zoom;
            panelComicScreen.AutoScroll = true;
            picBxComicScreen.Image = comReader.GetCurrentPage();

            lblPageNumber.Text = "Page 1 of " + comReader.GetPageCount().ToString();
        }

        private void ComicView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dispose image
            picBxComicScreen.Image.Dispose();
        }

        private void cmbBxBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBxBookmark.SelectedText != "")
            {
                //go to nth page
                int pageNum = int.Parse(cmbBxBookmark.SelectedText);

                comReader.GoToPage(pageNum);
                picBxComicScreen.Image.Dispose();
                picBxComicScreen.Image = comReader.GetCurrentPage();
                lblPageNumber.Text = "Page " + comReader.GetPageCount().ToString() + " of " + comReader.GetPageCount().ToString();
            }
            PageChanged();
        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            myBm.AddPageNum(comReader.GetCurrentPageNumber());
            RefreshBookmarks();

            //write changes
            loggedInUser.MyComicLibrary.RemoveComicBook(myCb.GetArchivePath());
            myCb.BookMark = myBm;
            loggedInUser.MyComicLibrary.AddComicBook(myCb);
            accountManager.WriteComicLibrary(loggedInUser.Id, loggedInUser.MyComicLibrary);
        }

        private void PageChanged()
        {
            if (myBm.GetPageNums().Contains(comReader.GetCurrentPageNumber()))
            {
                btnBookmark.Enabled = false;
                btnRemBookmark.Enabled = true;
            }
            else
            {
                btnBookmark.Enabled = true;
                btnRemBookmark.Enabled = false;
            }
        }

        private void RefreshBookmarks()
        {
            myCb.ViewCount--;
            myBm = myCb.BookMark;
            foreach (var bmPage in myCb.BookMark.GetPageNums())
            {
                cmbBxBookmark.Items.Add(bmPage.ToString());
            }
        }

        private void btnRemBookmark_Click(object sender, EventArgs e)
        {
            myBm.DelPageNum(comReader.GetCurrentPageNumber());
            RefreshBookmarks();

            //write changes
            loggedInUser.MyComicLibrary.RemoveComicBook(myCb.GetArchivePath());
            myCb.BookMark = myBm;
            loggedInUser.MyComicLibrary.AddComicBook(myCb);
            accountManager.WriteComicLibrary(loggedInUser.Id, loggedInUser.MyComicLibrary);
        }
    }
}
