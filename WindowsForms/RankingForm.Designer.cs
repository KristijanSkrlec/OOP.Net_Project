namespace WindowsForms
{
    partial class Rankings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rankings));
            this.lbRepresentation = new System.Windows.Forms.ListBox();
            this.lbRepInfo = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.btnRankYellow = new System.Windows.Forms.Button();
            this.btnRankGoals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRepresentation
            // 
            resources.ApplyResources(this.lbRepresentation, "lbRepresentation");
            this.lbRepresentation.FormattingEnabled = true;
            this.lbRepresentation.Name = "lbRepresentation";
            // 
            // lbRepInfo
            // 
            resources.ApplyResources(this.lbRepInfo, "lbRepInfo");
            this.lbRepInfo.Name = "lbRepInfo";
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.ForeColor = System.Drawing.Color.Red;
            this.lbInfo.Name = "lbInfo";
            // 
            // lbPlayers
            // 
            resources.ApplyResources(this.lbPlayers, "lbPlayers");
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.Name = "lbPlayers";
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.InitialImage = global::WindowsForms.Properties.Resources.NoImage;
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // btnRankYellow
            // 
            resources.ApplyResources(this.btnRankYellow, "btnRankYellow");
            this.btnRankYellow.Name = "btnRankYellow";
            this.btnRankYellow.UseVisualStyleBackColor = true;
            this.btnRankYellow.Click += new System.EventHandler(this.btnRankYellow_Click);
            // 
            // btnRankGoals
            // 
            resources.ApplyResources(this.btnRankGoals, "btnRankGoals");
            this.btnRankGoals.Name = "btnRankGoals";
            this.btnRankGoals.UseVisualStyleBackColor = true;
            this.btnRankGoals.Click += new System.EventHandler(this.btnRankGoals_Click);
            // 
            // Rankings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRankGoals);
            this.Controls.Add(this.btnRankYellow);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.lbPlayers);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbRepInfo);
            this.Controls.Add(this.lbRepresentation);
            this.Name = "Rankings";
            this.Load += new System.EventHandler(this.Rankings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbRepresentation;
        private Label lbRepInfo;
        private Label lbInfo;
        private ListBox lbPlayers;
        private PictureBox pbPlayer;
        private Button btnRankYellow;
        private Button btnRankGoals;
    }
}