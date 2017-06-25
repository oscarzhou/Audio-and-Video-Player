using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;




namespace OscarPlayer
{
    public partial class FrmMain : Form
    {
        private Playlist _objPlaylist = new Playlist();
        private IPlayer _objPlayer = null;

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
                    this.lbxPlaylist.Items.Add(this._objPlaylist.AddPathToList((string)file));
                }
            }
            SaveListInfoToText(this._objPlaylist);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lbxPlaylist.Items.Clear();
            this._objPlaylist.ClearList();
            SaveListInfoToText(this._objPlaylist);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._objPlaylist.DeletePathFromList(this.lbxPlaylist.SelectedIndex);
            this.lbxPlaylist.Items.Remove(this.lbxPlaylist.SelectedItem);
            SaveListInfoToText(this._objPlaylist);
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
                    PlaySound(_objPlaylist.ReadPathsFromList()[lbxPlaylist.SelectedIndex]);        
                }
                
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopSound();
        }

        #endregion
 

        #region Save and load data

        private void SaveListInfoToText(Playlist objPlaylist)
        {
            FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, objPlaylist);
            fs.Close();

        }

        private void LoadListInfoFromText()
        {
            if (File.Exists(Playlist._strPlayListPath))
            {
                FileStream fs = new FileStream(Playlist._strPlayListPath, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Playlist objPlaylist = (Playlist)formatter.Deserialize(fs);
                foreach (string item in objPlaylist.ReadPathsFromList())
                {
                    this.lbxPlaylist.Items.Add(this._objPlaylist.AddPathToList(item));
                }
                fs.Close();
            }
        }
        

        #endregion

        #region Audio operation

        private void PlaySound(string path)
        {
            if (_objPlayer != null)
            {
                return;
            }

            int pos = path.LastIndexOf(@".", StringComparison.Ordinal);
            string fileType = path.Substring(pos + 1);

            if (fileType.ToLower().Equals("wav"))
            {
                _objPlayer = new WAVPlayer();
            }
            else if (fileType.ToLower().Equals("mp3") || fileType.ToLower().Equals("wma"))
            {
                _objPlayer = new MP3Player();
                
            }
            _objPlayer.PlaySound(path);
            
        }


        private void StopSound()
        {
            if (_objPlayer != null )
            {
                _objPlayer.StopSound();
                _objPlayer = null;
            }
        }

        #endregion

        

        
        
    }

}
