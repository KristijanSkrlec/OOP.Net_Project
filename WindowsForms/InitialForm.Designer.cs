namespace WindowsForms
{
    partial class InitialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
            this.btnContinue = new System.Windows.Forms.Button();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.gbLanguage = new System.Windows.Forms.GroupBox();
            this.rbCroatian = new System.Windows.Forms.RadioButton();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.cbRepresentations = new System.Windows.Forms.ComboBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.gbGender.SuspendLayout();
            this.gbLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // gbGender
            // 
            resources.ApplyResources(this.gbGender, "gbGender");
            this.gbGender.Controls.Add(this.rbFemale);
            this.gbGender.Controls.Add(this.rbMale);
            this.gbGender.Name = "gbGender";
            this.gbGender.TabStop = false;
            // 
            // rbFemale
            // 
            resources.ApplyResources(this.rbFemale, "rbFemale");
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.TabStop = true;
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            resources.ApplyResources(this.rbMale, "rbMale");
            this.rbMale.Name = "rbMale";
            this.rbMale.TabStop = true;
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // gbLanguage
            // 
            resources.ApplyResources(this.gbLanguage, "gbLanguage");
            this.gbLanguage.Controls.Add(this.rbCroatian);
            this.gbLanguage.Controls.Add(this.rbEnglish);
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.TabStop = false;
            // 
            // rbCroatian
            // 
            resources.ApplyResources(this.rbCroatian, "rbCroatian");
            this.rbCroatian.Name = "rbCroatian";
            this.rbCroatian.TabStop = true;
            this.rbCroatian.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            resources.ApplyResources(this.rbEnglish, "rbEnglish");
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.TabStop = true;
            this.rbEnglish.UseVisualStyleBackColor = true;
            // 
            // cbRepresentations
            // 
            resources.ApplyResources(this.cbRepresentations, "cbRepresentations");
            this.cbRepresentations.FormattingEnabled = true;
            this.cbRepresentations.Name = "cbRepresentations";
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lbInfo.Name = "lbInfo";
            // 
            // InitialForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.cbRepresentations);
            this.Controls.Add(this.gbLanguage);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.btnContinue);
            this.Name = "InitialForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitialForm_FormClosing);
            this.Load += new System.EventHandler(this.InitialForm_Load);
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.gbLanguage.ResumeLayout(false);
            this.gbLanguage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnContinue;
        private GroupBox gbGender;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private GroupBox gbLanguage;
        private RadioButton rbCroatian;
        private RadioButton rbEnglish;
        private ComboBox cbRepresentations;
        private Label lbInfo;
    }
}