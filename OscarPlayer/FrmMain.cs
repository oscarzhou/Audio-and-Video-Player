using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace OscarPlayer
{
    public partial class FrmMain : Form
    {
        private readonly string _strPlayListPath = "";
        public FrmMain()
        {

            _strPlayListPath = Directory.GetCurrentDirectory() + "/Playlist/Playlist.txt";
            InitializeComponent();
            LoadListInfoFromText();
        }

        #region Button operation
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            
            if (folder.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folder.SelectedPath).Where(name => name.EndsWith(".mp3") || name.EndsWith(".wma"));

                foreach (var file in files.ToList())
                {
                    int pos = ((string) file).LastIndexOf(@"\", StringComparison.Ordinal);
                    this.lstItem.Items.Add(file.Substring(pos + 1));
                }
            }
            SaveListInfoToText(this.lstItem);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstItem.Items.Clear();
            SaveListInfoToText(this.lstItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.lstItem.Items.Remove(this.lstItem.SelectedItem);
            SaveListInfoToText(this.lstItem);
        }
        

        #endregion
 

        #region Save and load data

        private void SaveListInfoToText(ListBox listBox)
        {
            FileStream fs = new FileStream(_strPlayListPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            foreach (object item in listBox.Items)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            fs.Close();

        }

        private void LoadListInfoFromText()
        {
            if (File.Exists(_strPlayListPath))
            {
                FileStream fs = new FileStream(_strPlayListPath, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Unicode);
                //                List<string> playlist = new List<string>();
                string item = "";
                while ((item = sr.ReadLine()) != null)
                {
                    //                    playlist.Add(item);
                    this.lstItem.Items.Add(item);
                }
                sr.Close();
                fs.Close();
            }


        }
        

        #endregion
        
    }
}
