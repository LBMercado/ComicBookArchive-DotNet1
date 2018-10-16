using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ComicArchive
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
            loadProgBar.Step = 1;
        }

        public void SetDescriptionAsync(string desc)
        {
            lbl_info.BeginInvoke(
                new Action(() =>
                {
                    lbl_info.Text = desc;
                })
                );
        }

        public void UpdateProgressAsync(int prog)
        {
            loadProgBar.BeginInvoke(
                new Action(() =>
                {
                    loadProgBar.Value = prog;
                }
                ));
        }

        public void SetMaximumValueAsync(int maxVal)
        {
            if (maxVal > loadProgBar.Minimum)
                loadProgBar.BeginInvoke(
                new Action(() =>
                {
                    loadProgBar.Maximum = maxVal;
                }
                ));
            
        }

        public int GetMaximumValue()
        {
            return loadProgBar.Maximum;
        }

        public void SetMinimumValueAsync(int minVal)
        {
            if (minVal < loadProgBar.Maximum)
                loadProgBar.BeginInvoke(
                new Action(() =>
                {
                    loadProgBar.Minimum = minVal;
                }
                ));
        }

        public bool ProgressBarIsFull()
        {
            return loadProgBar.Value == loadProgBar.Maximum;
        }
    }
}
