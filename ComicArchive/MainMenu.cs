using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicArchive
{
    public partial class MainMenu : Form
    {
        //data members
        private Login ui_login;
        private List<FileInfo> comicInfo;

        public MainMenu(Login ui_Login)
        {
            FileInfo testComic;
            this.ui_login = ui_Login;
            InitializeComponent();
            //load cbzs/cbrs from archive
            //temporary placeholder for path of comics, change in final version to root folder
            string comicArchPath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources", @"comicbooks");
            //GetFiles on DirectoryInfo returns a FileInfo object.
            var comicFiles = new DirectoryInfo(comicArchPath.Replace('\\','/')).GetFiles();
            comicInfo = new List<FileInfo>();
            //store each file path
            //FileInfo has a Name property that only contains the filename part.
            foreach (var comicFile in comicFiles)
            {
                comicInfo.Add(comicFile);
                lstBxComics.Items.Add(comicFile.Name);
            }
            comicInfo.Sort((item1, item2) => item1.Name.CompareTo(item2.Name));
        }

        private void lstBxComics_DoubleClick(object sender, EventArgs e)
        {
            if (lstBxComics.SelectedItem != null)
            {
                //get selected item
                string comicPath = comicInfo.Find(comicInfoFile => 
                comicInfoFile.Name == lstBxComics.SelectedItem.ToString()).FullName;

                //open new comicView window
                ComicView ui_view = new ComicView(comicPath);
                ui_view.ShowDialog();
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            ui_login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ui_login.Close();
        }
    }
}
