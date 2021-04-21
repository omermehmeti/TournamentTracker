using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TTracker.DataAccess;
using TTracker.Models;

namespace TTracker
{
    public static class GlobalConfig
    {

        public const string Prizesfile = "PrizeModels.csv";
        public const string Playersfile = "PlayerModels.csv";
        public const string Teamsfile = "TeamModel.csv";
        public const string Tournamentsfile = "TournamentModels.csv";
        public const string MatchupsFile = "MatchupsModels.csv";
        public const string MatchupEntriesFile = "MatchupEntriesModels.csv";
        public static IDataConnection Connections { get; private set; } 
        public static void InitializeConnections1(DatabaseType db)
        {
            
            if (db==DatabaseType.MySql)
            {
                //do Something
                MysqlConnector Mysql = new MysqlConnector();
                Connections=Mysql;
            }
           else if (db ==DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connections=text;
                //do something
            }
        

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
                

        }
    }
}
