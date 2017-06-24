using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;



namespace OscarPlayer
{
    public partial class FrmMain : Form
    {
        private readonly string _strPlayListPath = "";
        private List<string> lstPath = new List<string>();

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
                var files = Directory.GetFiles(folder.SelectedPath).Where(name => name.EndsWith(".mp3") || name.EndsWith(".wma") || name.EndsWith(".wav"));
                
                foreach (var file in files.ToList())
                {
                    int pos = ((string) file).LastIndexOf(@"\", StringComparison.Ordinal);
                    this.lstItem.Items.Add(file.Substring(pos + 1));
                    lstPath.Add((string)file);   
                }
            }
            SaveListInfoToText(lstPath);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstItem.Items.Clear();
            lstPath.Clear();
            SaveListInfoToText(lstPath);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstPath.RemoveAt(this.lstItem.SelectedIndex);
            this.lstItem.Items.Remove(this.lstItem.SelectedItem);
            SaveListInfoToText(lstPath);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (this.lstItem.Items.Count == 0)
            {
                MessageBox.Show("Please loading the playlist!");
                return;
            }
            else
            {
                if (this.lstItem.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item!");
                }
                else
                {
                    PlaySound(lstPath[lstItem.SelectedIndex]);        
                }
                
            }
            
        }

        #endregion
 

        #region Save and load data

        private void SaveListInfoToText(List<string> listPath)
        {
            FileStream fs = new FileStream(_strPlayListPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            foreach (string item in listPath)
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
                    int pos = item.LastIndexOf(@"\", StringComparison.Ordinal);
                    this.lstItem.Items.Add(item.Substring(pos + 1));
                    lstPath.Add(item);
                }
                sr.Close();
                fs.Close();
            }


        }
        

        #endregion

        #region Play sound

        private void PlaySound(string path)
        {
            
            int pos = path.LastIndexOf(@".", StringComparison.Ordinal);
            string fileType = path.Substring(pos + 1);
            
            
            if (fileType.ToLower().Equals("wav"))
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = path;
                player.Load();
                player.Play();    
            }
            else if (fileType.ToLower().Equals("mp3") || fileType.ToLower().Equals("wma"))
            {
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = path;
                wplayer.controls.play();
            }
            
        }

        #endregion

        
        
    }

}
