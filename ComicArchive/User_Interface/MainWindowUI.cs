using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComicArchive.Business_Logic;
using ComicArchive.Application_Interface;
using ComicArchive.Data_Access;

namespace ComicArchive.User_Interface
{
    public partial class MainWindowUI : Form
    {
        //constants
        private const string accountFileName = @"accounts.xml";
        private const string cbResourceDirectory = @"Resources/comicbooks";

        //data members
        private User loggedInUser;
        private ExtendedAccountAccess accountManager;

        //UIs
        private Login loginUi;
        private HomeUI homeUi;
        private ChartsUI chartsUi;
        private LibraryUI libraryUi;

        public MainWindowUI(Login loginUi, User loggedInUser)
        {
            InitializeComponent();
            accountManager = new ExtendedAccountAccess(accountFileName);
            this.loggedInUser = accountManager.ReadAllUserAccounts()
                .Where(user => user.Id == loggedInUser.Id).Single();
            this.loginUi = loginUi;
        }

        private void MainWindowUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginUi.Show();
        }

        private void MainWindowUI_Load(object sender, EventArgs e)
        {
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartsUi != null)
            {
                chartsUi.Close();
                chartsUi = null;
            }
            if (libraryUi != null)
            {
                libraryUi.Close();
                libraryUi = null;
            }

            if (homeUi == null)
            {
                homeUi = new HomeUI(loggedInUser);
                homeUi.MdiParent = this;
                homeUi.Show();
            }
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (homeUi != null)
            {
                homeUi.Close();
                homeUi = null;
            }
            if (chartsUi != null)
            {
                chartsUi.Close();
                chartsUi = null;
            }

            if (libraryUi == null)
            {
                libraryUi = new LibraryUI(loggedInUser);
                libraryUi.MdiParent = this;
                libraryUi.Show();
            }
        }

        private void chartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (homeUi != null)
            {
                homeUi.Close();
                homeUi = null;
            }
            if (libraryUi != null)
            {
                libraryUi.Close();
                libraryUi = null;
            }

            if (chartsUi == null)
            {
                chartsUi = new ChartsUI();
                chartsUi.MdiParent = this;
                chartsUi.Show();
            }
        }
    }
}
