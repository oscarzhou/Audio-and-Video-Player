namespace OscarPlayer
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxPlaylist = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lbCurrentProgress = new System.Windows.Forms.Label();
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.tbPlayProgress = new System.Windows.Forms.TrackBar();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxPlaylist
            // 
            this.lbxPlaylist.FormattingEnabled = true;
            this.lbxPlaylist.HorizontalScrollbar = true;
            this.lbxPlaylist.ItemHeight = 18;
            this.lbxPlaylist.Location = new System.Drawing.Point(51, 26);
            this.lbxPlaylist.Name = "lbxPlaylist";
            this.lbxPlaylist.Size = new System.Drawing.Size(245, 490);
            this.lbxPlaylist.TabIndex = 0;
            this.lbxPlaylist.DoubleClick += new System.EventHandler(this.lbxPlaylist_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(59, 522);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 43);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(221, 522);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(745, 522);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 43);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(849, 522);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 43);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(647, 523);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 43);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lbCurrentProgress
            // 
            this.lbCurrentProgress.AutoSize = true;
            this.lbCurrentProgress.Location = new System.Drawing.Point(1144, 492);
            this.lbCurrentProgress.Name = "lbCurrentProgress";
            this.lbCurrentProgress.Size = new System.Drawing.Size(62, 18);
            this.lbCurrentProgress.TabIndex = 7;
            this.lbCurrentProgress.Text = "label1";
            // 
            // chkMute
            // 
            this.chkMute.AutoSize = true;
            this.chkMute.Location = new System.Drawing.Point(1132, 533);
            this.chkMute.Name = "chkMute";
            this.chkMute.Size = new System.Drawing.Size(79, 22);
            this.chkMute.TabIndex = 9;
            this.chkMute.Text = "Mute?";
            this.chkMute.UseVisualStyleBackColor = true;
            this.chkMute.CheckedChanged += new System.EventHandler(this.chkMute_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(140, 523);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 42);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(745, 523);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 43);
            this.btnResume.TabIndex = 11;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // tbPlayProgress
            // 
            this.tbPlayProgress.Location = new System.Drawing.Point(334, 466);
            this.tbPlayProgress.Name = "tbPlayProgress";
            this.tbPlayProgress.Size = new System.Drawing.Size(792, 69);
            this.tbPlayProgress.TabIndex = 12;
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(978, 523);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(148, 69);
            this.tbVolume.TabIndex = 13;
            this.tbVolume.TickFrequency = 0;
            this.tbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 598);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkMute);
            this.Controls.Add(this.lbCurrentProgress);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbxPlaylist);
            this.Controls.Add(this.tbPlayProgress);
            this.Name = "FrmMain";
            this.Text = "OPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.tbPlayProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPlaylist;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lbCurrentProgress;
        private System.Windows.Forms.CheckBox chkMute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.TrackBar tbPlayProgress;
        private System.Windows.Forms.TrackBar tbVolume;
    }
}

