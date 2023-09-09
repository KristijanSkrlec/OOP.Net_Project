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
        }

        private void CheckLanguage()
        {
            string[] strings = File.ReadAllLines(Utilities.Constants.INIT_SETTINGS);
            if (bool.Parse(strings[1]))
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
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(SettingsForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(language));
            }
            this.Controls.Clear();
            InitializeComponent();
        }

    }
}
