using System;
using System.IO;
using System.Windows.Forms;


namespace OscarPlayer
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {

                string[] files = Directory.GetFiles(folder.SelectedPath);
                
                foreach (string item in files)
                {
                    int pos = item.LastIndexOf(@"\");
                    this.lstItem.Items.Add(item.Substring(pos+1));
                }
                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstItem.Items.Clear();
        }


    }
}
