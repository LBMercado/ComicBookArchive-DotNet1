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
        private ComicReader comReader;
        public ComicView(string comicPath)
        {
            InitializeComponent();
            comReader = new ComicReader(comicPath);
            picBxComicScreen.SizeMode = PictureBoxSizeMode.AutoSize;
            panelComicScreen.AutoScroll = true;
            picBxComicScreen.Image = comReader.GetCurrentPage();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoToPrevious_Click(object sender, EventArgs e)
        {
            comReader.PreviousPage();
            picBxComicScreen.Image = comReader.GetCurrentPage();
        }

        private void btnGoToNext_Click(object sender, EventArgs e)
        {
            comReader.NextPage();
            picBxComicScreen.Image = comReader.GetCurrentPage();
        }
    }
}
