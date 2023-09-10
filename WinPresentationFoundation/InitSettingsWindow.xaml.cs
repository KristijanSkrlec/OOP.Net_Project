using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccessLayer.Models;

namespace WinPresentationFoundation
{
    /// <summary>
    /// Interaction logic for InitSettingsWindow.xaml
    /// </summary>
    public partial class InitSettingsWindow : Window
    {
        public InitSettingsWindow()
        {
            InitializeComponent();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            SaveChoices();
            ShowWindow(new MainWindow());
        }

        private void ShowWindow(MainWindow mainWindow)
        {
            Thread thread = new Thread(OpenNewForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            this.Close();
        }

        private void OpenNewForm()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindow mainWindow = new MainWindow(); // Replace with the name of your new form
                mainWindow.Show();
            });
        }

        private void SaveChoices()
        {
            try
            {
                // Save the initial values to a file
                using (StreamWriter writer = new StreamWriter(Utilities.Constants.INIT_SETTINGS))
                {
                    writer.WriteLine($"{rbMale.IsChecked}");
                    writer.WriteLine($"{rbEnglish.IsChecked}");
                }

                using (StreamWriter writer = new StreamWriter(Utilities.Constants.INIT_COUNTRY))
                {
                    writer.WriteLine($"{cbRepresentations.SelectedItem}");
                }

            }
            catch (Exception)
            {
                MessageBox.Show($"Error saving initial data:");
            }
        }

        private void Initial_Settings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChoices();
            CheckDataSource();
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
                //lbInfo.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show($"Error fetching JSON data:");
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
                    //lbInfo.Text = string.Empty;

                }
                catch (Exception)
                {
                    MessageBox.Show($"Error fetching API data:");
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
                ShowWindow(new MainWindow());
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
                        rbMale.IsChecked = bool.Parse(values[0]);
                        rbFemale.IsChecked = !rbMale.IsChecked;

                        rbEnglish.IsChecked = bool.Parse(values[1]);
                        rbCroatian.IsChecked = !rbEnglish.IsChecked;
                    }

                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Error loading initial values");
            }
        }

        private void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        }
        private void SetDefaults()
        {
            SetCulture(Utilities.Constants.EN);
            rbMale.IsChecked = true;
            rbEnglish.IsChecked = true;
        }
    }
}
