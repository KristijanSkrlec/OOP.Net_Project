namespace WindowsForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbAllPlayers = new System.Windows.Forms.ListBox();
            this.lbFavPlayers = new System.Windows.Forms.ListBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAllPlayers
            // 
            this.lbAllPlayers.FormattingEnabled = true;
            resources.ApplyResources(this.lbAllPlayers, "lbAllPlayers");
            this.lbAllPlayers.Name = "lbAllPlayers";
            this.lbAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbAllPlayers_DragDrop);
            this.lbAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbAllPlayers_DragEnter);
            this.lbAllPlayers.DragLeave += new System.EventHandler(this.lbAllPlayers_DragLeave);
            this.lbAllPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbAllPlayers_MouseDown);
            // 
            // lbFavPlayers
            // 
            this.lbFavPlayers.FormattingEnabled = true;
            resources.ApplyResources(this.lbFavPlayers, "lbFavPlayers");
            this.lbFavPlayers.Name = "lbFavPlayers";
            this.lbFavPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFavPlayers_DragDrop);
            this.lbFavPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbFavPlayers_DragEnter);
            this.lbFavPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFavPlayers_MouseDown);
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbInfo.ForeColor = System.Drawing.Color.Red;
            this.lbInfo.Name = "lbInfo";
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbFavPlayers);
            this.Controls.Add(this.lbAllPlayers);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbAllPlayers;
        private ListBox lbFavPlayers;
        private Label lbInfo;
        private PictureBox pbPlayer;
        private Button btnSettings;
    }
}