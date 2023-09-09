using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WindowsForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CheckLanguage();
            this.KeyPreview = true;
        }

        private void CheckLanguage()
        {
            string[] strings = File.ReadAllLines(Utilities.Constants.INIT_SETTINGS);
            if (!bool.Parse(strings[1]))
            {
                SetCulture(Utilities.Constants.HR);
            }
            else
            {
                SetCulture(Utilities.Constants.EN);
            }
        }

        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.Controls.Clear();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveData();
                btnSave.PerformClick();
                MessageBox.Show("Saved Changes");
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("Discarded Changes");
                this.Close();
            }
        }

        private void SaveData()
        {
            //throw new NotImplementedException();
        }
    }
}
