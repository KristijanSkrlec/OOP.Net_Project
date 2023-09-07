using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Utilities
{
    static class Constants
    {
       public static string dataSource = ConfigurationManager.AppSettings["DataSource"];

       public static string INIT_SETTINGS = @"..\..\..\ConfigurationFiles\InitSettings.txt";
       public static string INIT_COUNTRY = @"..\..\..\ConfigurationFiles\InitCountry.txt";
       public static string FAV_PLAYERS = @"..\..\..\ConfigurationFiles\FavPlayers.txt";
       public static string PLAYER_IMG = @"..\..\..\ConfigurationFiles\PlayerImg.txt";

       public static string MEN_TEAMS_URL = "https://worldcup-vua.nullbit.hr/men/teams";
       public static string WOMEN_TEAMS_URL = "https://worldcup-vua.nullbit.hr/women/teams";
       
       public static string MEN_MATCHES_URL = "https://worldcup-vua.nullbit.hr/men/matches";
       public static string WOMEN_MATCHES_URL = "https://worldcup-vua.nullbit.hr/women/matches";

       public static string MEN_TEAMS_JSON = @"..\..\..\..\DataAccessLayer\JSON\men\teams.json";
       public static string WOMEN_TEAMS_JSON = @"..\..\..\..\DataAccessLayer\JSON\women\teams.json";

       public static string MEN_MATCHES_JSON = @"..\..\..\..\DataAccessLayer\JSON\men\matches.json";
       public static string WOMEN_MATCHES_JSON = @"..\..\..\..\DataAccessLayer\JSON\women\matches.json";

       public static string HR = "hr-HR";
       public static string EN = "en-US";

        public static char DEL = '|';

    }
}
