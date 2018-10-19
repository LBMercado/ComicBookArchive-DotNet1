using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComicArchive.Business_Logic;
using ComicArchive.Data_Access;
using ComicArchive.Application_Interface;

namespace ComicArchive.User_Interface
{
    public partial class ChartsUI : Form
    {
        //constants
        private const string cbResourceDirectory = @"Resources/comicbooks";

        //data members
        private ComicAccess comicManager;

        public ChartsUI()
        {
            InitializeComponent();
            comicManager = new ComicAccess();

            var cbList = comicManager.GetComicBookList();
            cbList = ComicSortingInterface.SortBy(cbList, SortComicOption.ViewCount, Application_Interface.SortOrder.Descending);
            foreach (var cb in cbList)
            {
                lstBxComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
            }
        }

        private void lstBxComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            //highligh selection made in lstBxComics
            if (lstBxComics.SelectedItem != null)
            {
                Trace.WriteLine("Selection Index Changed: " + lstBxComics.SelectedIndices[0].ToString());
                int selectedIndex = lstBxComics.SelectedIndices[0];
                string selectedItem = lstBxComics.SelectedItem.ToString();

                string cbFullPath = Path.GetFullPath(Path.Combine(@"Resources", @"comicbooks", selectedItem));
                ComicBook selectedComic;
                selectedComic = comicManager.GetComicBook(cbFullPath);

                //enable textboxes/labels
                ComicInfo_Enabled(true);

                //set values in textboxes/labels
                ComicInfo_SetValues(selectedComic);
            }
            //highlight selection disappeared from lstBxComics
            else
            {
                Trace.WriteLine("Selection Index Changed: " + "NULL");
                //hide the controls and disable the textboxes
                ComicInfo_Enabled(false);
            }
        }

        private void ComicInfo_Enabled(bool enabled)
        {
            //reset text
            txtBxComicTitle.ResetText();
            txtBxComicSubTitle.ResetText();
            txtBxComicIssue.ResetText();
            txtBxDateAdded.ResetText();
            txtBxDateReleased.ResetText();
            richTxtBxSynopsis.ResetText();
            txtBxAuthors.ResetText();
            txtBxGenre.ResetText();
            txtBxPublisher.ResetText();

            //reset cover 
            if (picBxComicCover.Image != null)
            {
                picBxComicCover.Image.Dispose();
                picBxComicCover.Image = null;
            }

            //enable/disable
            txtBxComicTitle.Enabled = enabled;
            txtBxComicSubTitle.Enabled = enabled;
            txtBxComicIssue.Enabled = enabled;
            txtBxDateReleased.Enabled = enabled;
            txtBxDateAdded.Enabled = enabled;
            richTxtBxSynopsis.Enabled = enabled;
            txtBxAuthors.Enabled = enabled;
            txtBxGenre.Enabled = enabled;
            txtBxPublisher.Enabled = enabled;
            lblViewCount.Visible = enabled;
            lblAvgRating.Visible = enabled;
        }

        private void ComicInfo_SetValues(ComicBook cb)
        {
            txtBxComicTitle.Text = cb.ComicTitle;
            txtBxComicSubTitle.Text = cb.ComicSubTitle;
            txtBxComicIssue.Text = cb.ComicIssue;
            txtBxDateAdded.Text = cb.ComicDateAdded.ToShortDateString();
            txtBxDateReleased.Text = cb.ComicDateReleased.ToShortDateString();
            richTxtBxSynopsis.Text = cb.ComicSynopsis;

            if (cb.ComicAuthors != null)
            {
                txtBxAuthors.ResetText();
                txtBxAuthors.Text = string.Join(",", cb.ComicAuthors);
            }

            if (cb.ComicGenres != null)
            {
                txtBxGenre.ResetText();
                txtBxGenre.Text = string.Join(",", cb.ComicGenres);
            }

            txtBxPublisher.Text = cb.Publisher;

            lblViewCount.Text = "# of Views: " + cb.ViewCount.ToString();
            lblAvgRating.Text = "Average Rating: " + cb.Rating.ToString();
            lblNumPages.Text = "# of Pages: " + cb.PageCount.ToString() + " Pages";

            if (picBxComicCover.Image != null)
                picBxComicCover.Image.Dispose();
            picBxComicCover.Image = comicManager.GetComicFrontCover(cb.GetArchivePath());
        }
    }
}
