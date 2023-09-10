using DataAccessLayer.Models.Matches;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WinPresentationFoundation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Representation representation = new Representation();
        private Dictionary<string, string>? playerImageLink = new Dictionary<string, string>();
        private OpenFileDialog ofd = new OpenFileDialog();
        private bool isMen = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Localize();
            InitDragAndDrop();
            LoadSelectedCountry();
            LoadFavourites();
            LoadSelectedGender();
            CheckDataSource();
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
            SetDefaultImage();
        }

        private void SetDefaultImage()
        {
            pbPlayer.Stretch = Stretch.Uniform;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"Resources/NoImage.png", UriKind.Relative); 
            pbPlayer.Source = bitmap;

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
                        playerImageLink.Add(item.Name, @"Resources/NoImage.png");
                        lbAllPlayers.Items.Add(item.Name + " - " + item.ShirtNumber + " - " + item.Position + " - " + (item.Captain ? "Captain" : ""));
                    }
                }

                lbInfo.Content = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading selected country JSON");
            }
            LoadImages();
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
                            string player = item.Name + " - " + item.ShirtNumber + " - " + item.Position + " - " + (item.Captain ? "Captain" : "");
                            if (!lbFavPlayers.Items.Contains(player + " *"))
                            {
                                playerImageLink.Add(item.Name, @"Resources/NoImage.png");
                                lbAllPlayers.Items.Add(player);
                            }

                        }
                    }

                    lbInfo.Content = String.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading selected country API");
                }
                LoadImages();
            }
        }

        private void LoadImages()
        {
            if (File.Exists(Utilities.Constants.PLAYER_IMG))
            {
                using (StreamReader reader = new StreamReader(Utilities.Constants.PLAYER_IMG))
                {
                    if (reader != null)
                    {
                        try
                        {
                            // Load the initial values from a file
                            string[] players = File.ReadAllLines(Utilities.Constants.PLAYER_IMG);

                            foreach (var item in players)
                            {
                                string[] parts = item.Split(Utilities.Constants.DEL);
                                if (parts[1] == String.Empty)
                                {
                                    playerImageLink[parts[0]] = @"Resources/NoImage.png";
                                }
                                else
                                {
                                    playerImageLink[parts[0]] = @"Resources/NoImage.png";
                                }
                            }
                        }
                        catch (FileNotFoundException ex)
                        {
                            MessageBox.Show($"Error loading player images:");
                        }
                    }
                }
            }
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
                    MessageBox.Show($"Error loading favourite players");
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

        private void Localize()
        {
            using (StreamReader reader = new StreamReader(Utilities.Constants.INIT_SETTINGS))
            {
                string line = File.ReadAllText(Utilities.Constants.INIT_SETTINGS);
                string[] parts = line.Split('\n');

                if (line != null)
                {
                    if (!bool.Parse(parts[1]))
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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
        }

        private void btnRankings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
