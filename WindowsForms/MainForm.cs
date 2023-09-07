using DataAccessLayer.Models.Matches;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Globalization;

namespace WindowsForms
{
    public partial class MainForm : Form
    {
        private Representation representation = new Representation();
        private Dictionary<string, string>? playerImageLink = new Dictionary<string, string>();
        private OpenFileDialog ofd = new OpenFileDialog();
        private bool isMen = true;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Localize();
            InitDragAndDrop();
            LoadSelectedCountry();
            LoadFavourites();
            LoadSelectedGender();
            CheckDataSource();
        }
        private void LoadFavourites()
        {

            if (File.Exists(Utilities.Constants.FAV_PLAYERS))
            {
                try
                {
                    // Load the initial values from a file

                    string[] players = File.ReadAllLines(Utilities.Constants.FAV_PLAYERS);

                    foreach (var player in players)
                    {
                        lbFavPlayers.Items.Add(player);
                    }

                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"Error loading favourite players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFavourites();
        }
        private void Localize()
        {
            using (StreamReader reader = new StreamReader(Utilities.Constants.INIT_SETTINGS))
            {
                string line = File.ReadAllText(Utilities.Constants.INIT_SETTINGS);
                string[] parts = line.Split('\n');

                if (line != null)
                {
                    if (bool.Parse(parts[1]))
                    {
                        SetCulture(Utilities.Constants.HR);
                    }
                    else
                    {
                        SetCulture(Utilities.Constants.EN);
                    }
                }
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
        private void LoadSelectedGender()
        {
            using (StreamReader reader = new StreamReader(Utilities.Constants.INIT_SETTINGS))
            {
                string line = File.ReadAllText(Utilities.Constants.INIT_SETTINGS);
                string[] parts = line.Split('\n');

                if (line != null)
                {
                    if (bool.Parse(parts[0]))
                    {
                        isMen = true;
                    }
                    else
                    {
                        isMen = false;
                    }
                }
            }
        }
        private void CheckDataSource()
        {
            if (Utilities.Constants.dataSource == "API")
            {
                LoadPlayersAPI();
            }
            else if (Utilities.Constants.dataSource == "JSON")
            {
                LoadPlayersJSON();
            }
        }
        private void LoadPlayersJSON()
        {
            try
            {
                string jsonFilePath;
                if (isMen)
                {
                    jsonFilePath = Utilities.Constants.MEN_MATCHES_JSON; 
                }
                else
                {
                    jsonFilePath = Utilities.Constants.WOMEN_MATCHES_JSON; // Replace with the actual file path
                }

                // Read the JSON data from the file
                string jsonData = File.ReadAllText(jsonFilePath);

                // Deserialize the JSON data
                List<Matches> matches = Matches.FromJson(jsonData);

                // Find the match that corresponds to the selected country
                Matches selectedMatch = matches.FirstOrDefault(match => match.HomeTeamCountry == representation.Country);

                if (selectedMatch != null)
                {
                    // Get the starting eleven players from the selected match
                    List<StartingEleven> startingElevens = selectedMatch.HomeTeamStatistics.StartingEleven;

                    // Populate the combo box with team names
                    foreach (var item in startingElevens)
                    {
                        lbAllPlayers.Items.Add(item.Name + " - " + item.ShirtNumber + " - " + item.Position + " - " + (item.Captain ? "Captain" : ""));
                    }
                }

                lbInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading selected country: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadPlayersAPI()
        {
            using (HttpClient client = new HttpClient())
            {

                string response;
                try
                {

                    if (isMen)
                    {
                        response = await client.GetStringAsync(Utilities.Constants.MEN_MATCHES_URL);
                    }
                    else
                    {
                        response = await client.GetStringAsync(Utilities.Constants.WOMEN_MATCHES_URL);
                    }

                    // Deserialize the JSON data
                    List<Matches> matches = Matches.FromJson(response);

                    // Find the match that corresponds to the selected country
                    Matches selectedMatch = matches.First(match => match.HomeTeamCountry == representation.Country);

                    if (selectedMatch != null)
                    {
                        // Get the starting eleven players from the selected match
                        List<StartingEleven> startingElevens = selectedMatch.HomeTeamStatistics.StartingEleven;

                        // Populate the combo box with team names
                        foreach (var item in startingElevens)
                        {
                            //lbFavPlayers.Items.Add(item.GetType());
                            lbAllPlayers.Items.Add(item.Name + " - " + item.ShirtNumber + " - " + item.Position + " - " + (item.Captain ? "Captain" : ""));
                        }
                    }

                    lbInfo.Text = String.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading selected country: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void LoadSelectedCountry()
        {
            using (StreamReader reader = new StreamReader(Utilities.Constants.INIT_COUNTRY))
            {
                string line = File.ReadAllText(Utilities.Constants.INIT_COUNTRY);
                string[] parts = line.Split(' ');

                if (line != null)
                {
                    if (parts.Length == 2)
                    {
                        representation.Country = parts[0];
                        representation.FifaCode = parts[1];
                    }
                    else if (parts.Length == 3)
                    {
                        representation.Country = parts[0] + " " + parts[1];
                        representation.FifaCode = parts[2];
                    }
                }
            }
        }
        private void InitDragAndDrop()
        {
            lbAllPlayers.AllowDrop = true;
            lbFavPlayers.AllowDrop = true;
        }
        private void SaveFavourites()
        {
            //MessageBox.Show("save choices");
            try
            {
                // Save the initial values to a file
                using (StreamWriter writer = new StreamWriter(Utilities.Constants.FAV_PLAYERS))
                {
                    foreach (var player in lbFavPlayers.Items)
                    {
                        writer.WriteLine($"{player}");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving initial values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void AddImage()
        {
            InitOpenFileDialog();
            ShowImage();
        }
        private void ShowImage()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPlayer.Image = new Bitmap(ofd.FileName);
            }
            pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            //var bmp = new Bitmap();

        }
        private void InitOpenFileDialog()
        {
            // This returns something like C:\Users\Username:
            string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
            // Now let's get C:\Users\Username\Downloads:
            string downloadFolder = Path.Combine(userRoot, "Downloads");

            ofd.Filter = "Pictures|*.jpeg;*.jpg;*.png;|All files|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Load picture...";
            ofd.InitialDirectory = downloadFolder;

        }
        ////////////////////////////////////////////////////////////////////////////////
        private void lbAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string draggedItem = e.Data.GetData(DataFormats.Text).ToString().Substring(0, e.Data.GetData(DataFormats.Text).ToString().Length - 2);

                // Check if the item is not already in lbAllPlayers
                if (!lbAllPlayers.Items.Contains(draggedItem))
                {
                    lbAllPlayers.Items.Add(draggedItem);
                }

                // Remove the item from lbFavPlayers
                lbFavPlayers.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
        }

        private void lbAllPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbAllPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lbAllPlayers.SelectedItem != null)
                {
                    // Set the selected index to the currently selected item
                    lbAllPlayers.SelectedIndex = lbAllPlayers.Items.IndexOf(lbAllPlayers.SelectedItem);
                    // Start drag and drop operation
                    lbAllPlayers.DoDragDrop(lbAllPlayers.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Handle right-click behavior, if needed
                AddImage();
            }
        }

        private void lbFavPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                if (lbFavPlayers.Items.Count == 3)
                {
                    MessageBox.Show("Maximum amount of players added.");
                    return;
                }

                // Check if the item is not already in lbFavPlayers
                string draggedItem = e.Data.GetData(DataFormats.Text).ToString();
                if (!lbFavPlayers.Items.Contains(draggedItem))
                {
                    lbFavPlayers.Items.Add(draggedItem + " *");
                }

                // Remove the item from lbAllPlayers
                lbAllPlayers.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
        }

        private void lbFavPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbFavPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lbFavPlayers.SelectedItem != null)
                {
                    // Set the selected index to the currently selected item
                    lbFavPlayers.SelectedIndex = lbFavPlayers.Items.IndexOf(lbFavPlayers.SelectedItem);
                    // Start drag and drop operation
                    lbFavPlayers.DoDragDrop(lbFavPlayers.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Handle right-click behavior, if needed
            }
        }

        private void lbAllPlayers_DragLeave(object sender, EventArgs e)
        {

        }
    }
}
