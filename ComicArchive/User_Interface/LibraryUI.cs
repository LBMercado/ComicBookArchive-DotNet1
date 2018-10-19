using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ComicArchive.Business_Logic;
using ComicArchive.Data_Access;
using ComicArchive.Application_Interface;

namespace ComicArchive.User_Interface
{
    public partial class LibraryUI : Form
    {
        //constants
        private const string cbResourceDirectory = @"Resources/comicbooks";
        private const string accountFileName = @"accounts.xml";

        //data members
        private User loggedInUser;
        private ComicAccess comicManager;
        private ExtendedAccountAccess accountManager;
        private int setRating;

        public LibraryUI(User loggedInUser)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;
            comicManager = new ComicAccess();
            accountManager = new ExtendedAccountAccess(accountFileName);
        }

        private void LibraryUI_Load(object sender, EventArgs e)
        {
            ReloadLibrary();
        }

        private void ReloadLibrary()
        {
            lstBxSavedComics.Items.Clear();
            lstBxAvailableComics.Items.Clear();
            //load user's saved comic books into list view
            foreach (var cb in loggedInUser.MyComicLibrary.GetAllComicBooks())
            {
                lstBxSavedComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
            }
            List<ComicBook> availableComicBooks = comicManager.GetComicBookList()
                .Where(cb => !loggedInUser.MyComicLibrary.ComicBookExists(cb.GetArchivePath()))
                .ToList();
            foreach (var cb in availableComicBooks)
            {
                lstBxAvailableComics.Items.Add(Path.GetFileName(cb.GetArchivePath()));
            }
        }

        private void lstBxSavedComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxSavedComics.SelectedItem != null)
            {
                btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
            }
        }

        private void lstBxAvailableComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxAvailableComics.SelectedItem != null)
            {
                btnImport.Enabled = true;
            }
            else
            {
                btnImport.Enabled = false;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string fileName = lstBxAvailableComics.SelectedItem.ToString();
            
            //get comic book
            UserComicBook importedCb = UserComicBook.MorphToUserComicBook(comicManager.GetComicBook(Path.Combine(cbResourceDirectory, fileName)));
            Bookmark bm = new Bookmark(importedCb.PageCount);
            importedCb.BookMark = bm;
            //add to user library
            loggedInUser.MyComicLibrary.AddComicBook(importedCb);
            //write changes
            accountManager.WriteComicLibrary(loggedInUser.Id, loggedInUser.MyComicLibrary);
            //refresh to reflect changes
            ReloadLibrary();
            btnImport.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string fileName = lstBxSavedComics.SelectedItem.ToString();

            //get comic book
            ComicBook importedCb = comicManager.GetComicBook(Path.Combine(cbResourceDirectory, fileName));
            //remove from user library
            loggedInUser.MyComicLibrary.RemoveComicBook(importedCb.GetArchivePath());
            //write changes
            accountManager.WriteComicLibrary(loggedInUser.Id, loggedInUser.MyComicLibrary);
            //refresh to reflect changes
            ReloadLibrary();
            btnRemove.Enabled = false;
        }

        private void btnRate_Click(object sender, EventArgs e)
        {
            if (lstBxSavedComics.SelectedItem != null)
            {
                string fileName = lstBxSavedComics.SelectedItem.ToString();
                string cbzCompleteDir = Path.Combine(Directory.GetCurrentDirectory(), cbResourceDirectory, fileName);
                //rate
                loggedInUser.MyComicLibrary.RateComicBook(cbzCompleteDir, setRating);

                //also the public one
                var pubCb = comicManager.GetComicBook(cbzCompleteDir);
                pubCb.RateComicBook(setRating);

                //write changes
                accountManager.WriteComicLibrary(loggedInUser.Id, loggedInUser.MyComicLibrary);
                comicManager.UpdateComicBookRecord(pubCb);
            }
        }

        private void rdBtnRate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnRate1.Checked)
            {
                setRating = 1;
            }
            else if (rdBtnRate2.Checked)
            {
                setRating = 2;
            }
            else if (rdBtnRate3.Checked)
            {
                setRating = 3;
            }
            else if (rdBtnRate4.Checked)
            {
                setRating = 4;
            }
            else
            {
                setRating = 5;
            }
        }
    }
}
