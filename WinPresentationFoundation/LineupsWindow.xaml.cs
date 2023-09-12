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
using System.IO;

namespace WinPresentationFoundation
{
    /// <summary>
    /// Interaction logic for LineupsWindow.xaml
    /// </summary>
    public partial class LineupsWindow : Window
    {
        private Representation representation = new Representation();
        private Dictionary<string, string>? playerImageLink = new Dictionary<string, string>();
        public LineupsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSelectedCountry();
            SetPlayers();
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

        private async void SetPlayers()
        {
            using (HttpClient client = new HttpClient())
            {

                string response;
                try
                {
                    //if (isMen)
                    //{
                    response = await client.GetStringAsync(Utilities.Constants.MEN_MATCHES_URL);
                    //}
                    //else
                    //{
                    //    response = await client.GetStringAsync(Utilities.Constants.WOMEN_MATCHES_URL);
                    //}

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
                            //string player = item.Name + " - " + item.ShirtNumber + " - " + item.Position + " - " + (item.Captain ? "Captain" : "");
                            //if (!lbFavPlayers.Items.Contains(player + " *"))
                            //{
                            //    playerImageLink.Add(item.Name, @"Resources/NoImage.png");
                            //    lbAllPlayers.Items.Add(player);
                            //}

                        }
                    }

                    //lbInfo.Content = String.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading selected country API");
                }
                //LoadImages();
            }
        }
    }
}
