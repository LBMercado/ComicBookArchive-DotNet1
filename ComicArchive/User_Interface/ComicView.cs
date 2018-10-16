using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicArchive
{
    public partial class ComicView : Form
    {
        //data members
        private ComicReader comReader;
        private string comicPath;
        private ProgressDialog progDialog;
        private BackgroundWorker bgWorker;
        private bool backgroundProcessDone;

        public ComicView(string comicPath)
        {
            this.comicPath = comicPath;
            InitializeComponent();
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
        }

        private void btnGoToNext_Click(object sender, EventArgs e)
        {
            comReader.NextPage();
            picBxComicScreen.Image.Dispose();
            picBxComicScreen.Image = comReader.GetCurrentPage();
            lblPageNumber.Text = "Page " + comReader.GetCurrentPageNumber() + " of " + comReader.GetPageCount().ToString();
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
        }

        private void ComicView_Load(object sender, EventArgs e)
        {
            comReader = new ComicReader(comicPath);

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
                comReader.OpenComic();
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
            lblTitle.Text = comReader.GetTitle();
        }

        private void ComicView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dispose image
            picBxComicScreen.Image.Dispose();
        }
    }
}
