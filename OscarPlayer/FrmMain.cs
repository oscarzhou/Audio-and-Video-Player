using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace OscarPlayer
{
    public partial class FrmMain : Form
    {
        #region Paramters declaration

        private readonly Playlist _objPlaylist = new Playlist();
        private IPlayer _objPlayer = null;
        private int _curVol = 0;

        //private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        //private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        //private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        //private const int WM_APPCOMMAND = 0x319;


        private readonly CoreAudioDevice _defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;


        #endregion

        #region reference extern library
        

        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        #endregion


        public FrmMain()
        {

            InitializeComponent();
            LoadListInfoFromText();
            btnPlay.Visible = true;
            btnResume.Visible = false;
            btnPause.Visible = true;

            // Determine if the system volume is muted
            if (_defaultPlaybackDevice.IsMuted)
            {
                chkMute.Checked = true;
            }
            else
            {
                chkMute.Checked = false;
            }
            tbVolume.Enabled = !chkMute.Checked;
            
            // Set the current volume
            AdjustCurrentVolume();

        }

        #region Control operation
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open the Browser Dialog
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folder.SelectedPath).Where(name => name.EndsWith(".mp3") || name.EndsWith(".wma") || name.EndsWith(".wav"));
                
                foreach (var file in files.ToList())
                {
                    this.lbxPlaylist.Items.Add(this._objPlaylist.ParsePathToFile((string)file));
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
            btnPlay.Visible = true;
            btnResume.Visible = false;
            btnPause.Visible = true;
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopSound();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            PauseSound();
            btnPlay.Visible = false;
            btnResume.Visible = true;
            btnPause.Visible = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            ResumeSound();
            btnPlay.Visible = true;
            btnResume.Visible = false;
            btnPause.Visible = true;
        }

        private void lbxPlaylist_DoubleClick(object sender, EventArgs e)
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
            btnPlay.Visible = true;
            btnResume.Visible = false;
            btnPause.Visible = true;
        }


        private void chkMute_CheckedChanged(object sender, EventArgs e)
        {
            tbVolume.Enabled = !chkMute.Checked;
            _defaultPlaybackDevice.ToggleMute();
            //SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr) APPCOMMAND_VOLUME_MUTE);
            
        }


        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            SetVolume(tbVolume.Value);

        }

        private void btnNextItem_Click(object sender, EventArgs e)
        {
            int nextItem = 0;
            if (lbxPlaylist.SelectedIndex != lbxPlaylist.Items.Count - 1)
            {
                nextItem = lbxPlaylist.SelectedIndex + 1;
            }
            else
            {
                nextItem = 0;
            }
            PlaySound(_objPlaylist.ReadPathsFromList()[nextItem]);

            lbxPlaylist.SelectedIndex = nextItem;
            lbxPlaylist.Focus();
            btnPlay.Visible = true;
            btnResume.Visible = false;
            btnPause.Visible = true;

        }



        #endregion
 

        #region Save and load data

        private void SaveListInfoToText(Playlist objPlaylist)
        {
            if (!File.Exists(Playlist._strPlayListPath))
            {
                Directory.CreateDirectory(objPlaylist.GetDirectory());
                 
                
            }
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
                    this.lbxPlaylist.Items.Add(this._objPlaylist.ParsePathToFile(item));
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
                StopSound();
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

        private void PauseSound()
        {
            if (_objPlayer != null)
            {
                _objPlayer.PauseSound();
            }
        }

        private void ResumeSound()
        {
            if (_objPlayer != null)
            {
                _objPlayer.ResumeSound();
            }
        }

        private void SetVolume(int volume)
        {
            _defaultPlaybackDevice.Volume = volume;
            lbVolume.Text = "Vol. " + volume.ToString();

            //int nextVol = tbVolume.Value;

            //if (this.curVol > nextVol)
            //{
            //    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr) APPCOMMAND_VOLUME_DOWN);
            //    this.curVol = nextVol;
            //}
            //else
            //{
            //    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            //    this.curVol = nextVol;

            //}

        }

        private int  GetVolume()
        {
            return (int)_defaultPlaybackDevice.Volume;
        }

        private void AdjustCurrentVolume()
        {
            _curVol = GetVolume();
            SetVolume(_curVol);
            tbVolume.Value = _curVol;
            lbVolume.Text = "Vol. " + _curVol.ToString();
        }

        #endregion

     

        

        
        
    }

}
