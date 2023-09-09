using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
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
using WindowsForms.Properties;

namespace WindowsForms
{
    public partial class Rankings : Form
    {
        private Representation representation = new Representation();
        Dictionary<string, int> playerGoals = new Dictionary<string, int>();
        Dictionary<string, int> playerYellows = new Dictionary<string, int>();

        public Rankings()
        {
            InitializeComponent();
        }

        private void Rankings_Load(object sender, EventArgs e)
        {
            CheckLanguage();
            LoadRepresentation();
            LoadPlayersAPI();
        }

        private void LoadRepresentation()
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

                lbRepInfo.Text = lbRepInfo.Text + " " + representation.Country;
            }
        }

        private async void LoadPlayersAPI()
        {
            using (HttpClient client = new HttpClient())
            {

                string response;
                try
                {
                    //if (isMen)
                    //{
                    //    response = await client.GetStringAsync(Utilities.Constants.MEN_MATCHES_URL);
                    //}
                    //else
                    //{
                    //    response = await client.GetStringAsync(Utilities.Constants.WOMEN_MATCHES_URL);
                    //}

                    // Deserialize the JSON data
                    response = await client.GetStringAsync(Utilities.Constants.MEN_MATCHES_URL);

                    List<Matches> matches = Matches.FromJson(response);
                    TeamStatistics teamStatistics = new TeamStatistics();

                    // Find the match that corresponds to the selected country
                    Matches selectedMatch = matches.First(match => match.HomeTeamCountry == representation.Country);
                    teamStatistics.Country = representation.Country;

                    if (selectedMatch != null)
                    {
                        // Get the starting eleven players from the selected match
                        List<StartingEleven> startingElevens = selectedMatch.HomeTeamStatistics.StartingEleven;

                        // Populate the combo box with team names
                        foreach (var item in startingElevens)
                        {
                            string player = item.Name;
                            //lbRepresentation.Items.Add(player);
                        }

                        var orderedMatches = matches.OrderBy(x => x.Attendance).Reverse();

                        foreach (var item in orderedMatches)
                        {
                            var homeTeam = item.HomeTeam;
                            var awayTeam = item.AwayTeam;
                            var homeTeamStat = item.HomeTeamStatistics;
                            var AwayTeamStat = item.AwayTeamStatistics;

                            if (item.HomeTeamCountry == representation.Country)
                            {
                                if (Thread.CurrentThread.CurrentCulture.Name == Utilities.Constants.HR)
                                {
                                    lbRepresentation.Items.Add("Lokacija: " + item.Location);
                                    lbRepresentation.Items.Add("Gledatelji: " + item.Attendance);
                                    lbRepresentation.Items.Add("Domaci Tim: " + homeTeam.Country);
                                    lbRepresentation.Items.Add("Gostujuci Tim: " + awayTeam.Country);
                                    lbRepresentation.Items.Add("Domaci Tim Dodavanja: " + homeTeamStat.NumPasses);
                                    lbRepresentation.Items.Add("Gostujuci Tim Dodavanja: " + AwayTeamStat.NumPasses);
                                }
                                lbRepresentation.Items.Add("Location: " + item.Location);
                                lbRepresentation.Items.Add("Attendance: " + item.Attendance);
                                lbRepresentation.Items.Add("Home Team: " + homeTeam.Country);
                                lbRepresentation.Items.Add("Away Team: " + awayTeam.Country);
                                lbRepresentation.Items.Add("Home Team Passes: " + homeTeamStat.NumPasses);
                                lbRepresentation.Items.Add("Away Team Passes: " + AwayTeamStat.NumPasses);
                                lbRepresentation.Items.Add("----------------------------------------------");
                            }
                        }


                        foreach (var item in matches)
                        {
                            if (item.HomeTeamCountry == representation.Country)
                            {
                                foreach (var temp in item.HomeTeamEvents)
                                {
                                    if (temp.TypeOfEvent == TypeOfEvent.Goal)
                                    {
                                        if (!playerGoals.ContainsKey(temp.Player))
                                        {
                                            playerGoals[temp.Player] = 0;
                                        }

                                        playerGoals[temp.Player]++;
                                    }
                                }

                                foreach (var temp in item.AwayTeamEvents)
                                {
                                    if (temp.TypeOfEvent == TypeOfEvent.Goal)
                                    {
                                        if (!playerGoals.ContainsKey(temp.Player))
                                        {
                                            playerGoals[temp.Player] = 0;
                                        }
                                        playerGoals[temp.Player]++;

                                    }
                                }

                            }
                        }

                        foreach (var item in matches)
                        {
                            if (item.HomeTeamCountry == representation.Country)
                            {
                                foreach (var temp in item.HomeTeamEvents)
                                {
                                    if (temp.TypeOfEvent == TypeOfEvent.YellowCard)
                                    {
                                        if (!playerYellows.ContainsKey(temp.Player))
                                        {
                                            playerYellows[temp.Player] = 0;
                                        }

                                        playerYellows[temp.Player]++;
                                    }
                                }

                                foreach (var temp in item.AwayTeamEvents)
                                {
                                    if (temp.TypeOfEvent == TypeOfEvent.YellowCard)
                                    {
                                        if (!playerYellows.ContainsKey(temp.Player))
                                        {
                                            playerYellows[temp.Player] = 0;
                                        }
                                        playerYellows[temp.Player]++;

                                    }
                                }

                            }
                        }



                    }

                    lbInfo.Text = String.Empty;
                    pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPlayer.Image = Resources.NoImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading selected country API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void btnRankGoals_Click(object sender, EventArgs e)
        {
            var orderedPlayers = playerGoals.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Reverse();

            lbPlayers.Items.Clear();
            foreach (var player in orderedPlayers)
            {
                lbPlayers.Items.Add(player.Key + " - " + player.Value);
            }
            lbPlayers.Items.Add("----------------------------------------------");
        }

        private void btnRankYellow_Click(object sender, EventArgs e)
        {

            var orderedPlayers = playerYellows.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Reverse();

            lbPlayers.Items.Clear();
            foreach (var player in orderedPlayers)
            {
                lbPlayers.Items.Add(player.Key + " - " + player.Value);
            }
            lbPlayers.Items.Add("----------------------------------------------");
        }
    }
}
