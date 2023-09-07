using DataAccessLayer.Models;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace WindowsForms
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            LoadChoices();
            CheckDataSource();
        }
        private void InitialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            SaveChoices();
            ShowForm(new MainForm());
        }
        private void CheckDataSource()
        {
            if (Utilities.Constants.dataSource == "API")
            {
                LoadCountriesAPI();
            }
            else if (Utilities.Constants.dataSource == "JSON")
            {
                LoadCountriesJSON();
            }
        }
        private void LoadCountriesJSON()
        {
            try
            {
                // Read the JSON data from a file (replace with your actual file path)
                string jsonFilePath = @"..\..\..\..\DataAccessLayer\JSON\men\teams.json";
                string jsonData = File.ReadAllText(jsonFilePath);

                // Deserialize the JSON data
                List<Representation> reps = Representation.FromJson(jsonData);

                // Populate the combo box with team names
                foreach (Representation rep in reps)
                {
                    cbRepresentations.Items.Add(rep.Country + " (" + rep.FifaCode + ")");
                }

                // Set the selected index and clear the info label
                cbRepresentations.SelectedIndex = 0;
                lbInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching JSON data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadCountriesAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fetch the data from the API
                    string response = await client.GetStringAsync(Utilities.Constants.MEN_TEAMS_URL);

                    // Deserialize the JSON data
                    List<Representation> reps = Representation.FromJson(response);

                    // Populate the combo box with team names
                    foreach (Representation rep in reps)
                    {
                        cbRepresentations.Items.Add(rep.Country + " (" + rep.FifaCode + ")");
                    }
                    cbRepresentations.SelectedIndex = 0;
                    lbInfo.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching API data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadChoices()
        {
            if (!File.Exists(Utilities.Constants.INIT_SETTINGS) || !File.Exists(Utilities.Constants.INIT_COUNTRY))
            {
                SetDefaults();
                return;
            }
            else
            {
                SetValues();
                ShowForm(new MainForm());
            }

        }
        private void SetValues()
        {
            try
            {
                // Load the initial values from a file
                using (StreamReader reader = new StreamReader(Utilities.Constants.INIT_SETTINGS))
                {
                    string line = reader.ReadToEnd();
                    // Split the line into two values
                    string[] values = line.Split("\n");

                    if (line != null)
                    {
                        if (bool.Parse(values[1]))
                        {
                            SetCulture(Utilities.Constants.EN);
                        }
                        else
                        {
                            SetCulture(Utilities.Constants.HR);
                        }

                        // Parse the values and store them
                        rbMale.Checked = bool.Parse(values[0]);
                        rbFemale.Checked = !rbMale.Checked;

                        rbEnglish.Checked = bool.Parse(values[1]);
                        rbCroatian.Checked = !rbEnglish.Checked;

                    }

                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Error loading initial values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetDefaults()
        {
            SetCulture(Utilities.Constants.EN);
            rbMale.Checked = true;
            rbEnglish.Checked = true;
        }
        private void SetCulture(string language)
        {
            CultureInfo culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.Controls.Clear();
            InitializeComponent();
        }
        private void SaveChoices()
        {
            //MessageBox.Show("save choices");
            try
            {
                // Save the initial values to a file
                using (StreamWriter writer = new StreamWriter(Utilities.Constants.INIT_SETTINGS))
                {
                    writer.WriteLine($"{rbMale.Checked}");
                    writer.WriteLine($"{rbEnglish.Checked}");
                }

                using (StreamWriter writer = new StreamWriter(Utilities.Constants.INIT_COUNTRY))
                {
                    writer.WriteLine($"{cbRepresentations.SelectedItem}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving initial values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ShowForm(Form form)
        {
            Thread thread = new Thread(OpenNewForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            void OpenNewForm()
            {
                Application.Run(new MainForm());
            }

            this.Close();
        }
    }
}