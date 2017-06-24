using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;




namespace OscarPlayer
{
    public partial class FrmMain : Form
    {
        private List<string> lstPath = new List<string>();
        private SoundPlayer player;
        private WMPLib.WindowsMediaPlayer wplayer;
        private Playlist playlist = new Playlist();

        public FrmMain()
        {

            InitializeComponent();
            LoadListInfoFromText();
        }

        #region Button operation
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open the Browser Dialog
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folder.SelectedPath).Where(name => name.EndsWith(".mp3") || name.EndsWith(".wma") || name.EndsWith(".wav"));
                
                foreach (var file in files.ToList())
                {
                    this.lbxPlaylist.Items.Add(this.playlist.AddPathToList((string)file));
                }
            }
            SaveListInfoToText(this.playlist);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lbxPlaylist.Items.Clear();
            this.playlist.ClearList();
            SaveListInfoToText(this.playlist);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.playlist.DeletePathFromList(this.lbxPlaylist.SelectedIndex);
            this.lbxPlaylist.Items.Remove(this.lbxPlaylist.SelectedItem);
            SaveListInfoToText(this.playlist);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (this.lbxPlaylist.Items.Count == 0)
            {
                MessageBox.Show("Please loading the playlist!");
                return;
            }
            else
            {
                if (this.lbxPlaylist.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item!");
                }
                else
                {
                    PlaySound(lstPath[lbxPlaylist.SelectedIndex]);        
                }
                
            }
            
        }

        #endregion
 

        #region Save and load data

        private void SaveListInfoToText(Playlist objPlaylist)
        {
            //FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            //foreach (string item in objPlaylist.ReadPathsFromList())
            //{
            //    sw.WriteLine(item);
            //}
            //sw.Close();
            //fs.Close();
            FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, objPlaylist);
            fs.Close();

        }

        private void LoadListInfoFromText()
        {
            if (File.Exists(Playlist._strPlayListPath))
            {
                //FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Open);
                //StreamReader sr = new StreamReader(fs, Encoding.Unicode);
                //string item = "";
                //while ((item = sr.ReadLine()) != null)
                //{
                //    this.lbxPlaylist.Items.Add(this.playlist.AddPathToList((string)item));
                //}
                //sr.Close();
                //fs.Close();
                FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Playlist objPlaylist = (Playlist)formatter.Deserialize(fs);
                foreach (string item in objPlaylist.ReadPathsFromList())
                {
                    this.lbxPlaylist.Items.Add(this.playlist.AddPathToList(item));
                }
                fs.Close();
            }
        }
        

        #endregion

        #region Audio operation

        private void PlaySound(string path)
        {
            
            int pos = path.LastIndexOf(@".", StringComparison.Ordinal);
            string fileType = path.Substring(pos + 1);
            
            
            if (fileType.ToLower().Equals("wav"))
            {
                player = new SoundPlayer();
                player.SoundLocation = path;
                player.Load();
                player.Play();    
            }
            else if (fileType.ToLower().Equals("mp3") || fileType.ToLower().Equals("wma"))
            {
                wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = path;
                wplayer.controls.play();
            }
            
        }


        private void StopSound()
        {
            if (player.IsLoadCompleted)
            {
                
            }
        }

        #endregion

        
        
    }

}
