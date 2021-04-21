using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using TTracker.Models;

namespace TTracker.DataAccess.TextHelper
{
    public static class TextConnectorProccessor
    {
        // load text file
        // covert text to list of prize model
        // find the max  id 
        /// ad a new record with new id = max+1
        /// convert prizes to a list of string 
        /// save list of strings to text file
        
        
        public static string FullFilePath(this string filename)
        {
            // 
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{filename}";
        }
        public static List<string> LoadFile(this string fullfilepath)
        {
            if (!File.Exists(fullfilepath))
            {
                return new List<string>();
            }
            return File.ReadAllLines(fullfilepath).ToList();
        }
        public static List<PersonModel> ConverttoPlayerModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.Cellphone = cols[4];
                output.Add(p);
            }
            return output;

        }
        public static List<TeamModel> CoverttoTeamModel(this List<string> lines,string peoplefilename)
        {
            // id,teamname,list of ids seperated by |
            // id,timname 3|2
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> players = peoplefilename.FullFilePath().LoadFile().ConverttoPlayerModel();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();
                t.Id =int.Parse( cols[0]);
                t.TeamName = cols[1];

                string[] playersids = cols[2].Split('|');

                foreach(string id in playersids)
                {
                    t.TeamMembers.Add(players.Where(x => x.Id == int.Parse(id)).First());
                }
                output.Add(t);
                
            }
            return output;

        }
        public static List<TournamentModel> ConvertToTournamentModel(this List<string> lines,
            string teamsfilename,
            string peoplefilename,
            string prizefilename)
        {
            //id,tournamentname,entryfee,(id,id,id teams),(id,id,id prizes ),{Round id^id^id | id^id^id | id^id^id }
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamsfilename.FullFilePath().LoadFile().CoverttoTeamModel(peoplefilename);
            List<PrizeModel> prizes = prizefilename.FullFilePath().LoadFile().ConverttoPrizeModel();
            List<MatchupModel> matches = GlobalConfig.MatchupsFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TournamentModel tm = new TournamentModel();
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);
                string[] teamsid = cols[3].Split('|');
                foreach(string id in teamsid)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }
                if (cols[4].Length > 0)
                {
                    string[] prizeid = cols[4].Split('|');
                    foreach (string pid in prizeid)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(pid)).First());
                    }
                }
                
                // TODO --implementing rounds Big deal

                string[] rounds = cols[5].Split('|');
                

                foreach(string round in rounds)
                {
                    string[] matchups = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();//  Big bugs BUGG
                    foreach (string matchupmodeltextid in matchups)
                    {
                        ms.Add(matches.Where(x=>x.Id==int.Parse(matchupmodeltextid)).First());
                    }
                    tm.Rounds.Add(ms);
                }
                output.Add(tm);

            }
            return output;

        }
        public static List<PrizeModel> ConverttoPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id =int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = double.Parse(cols[3]);
                p.PricePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static void SavetoTournamentFile(this List<TournamentModel> models,string filename)
        {
            List<string> lines = new List<string>();
            foreach(TournamentModel tm in models)
            {
                lines.Add($"{tm.Id},{tm.TournamentName},{tm.EntryFee},{TeamListToString(tm.EnteredTeams)},{PrizeListToString(tm.Prizes)},{ConvertRoundListTosString(tm.Rounds)}");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
        public static string ConvertRoundListTosString( List<List<MatchupModel>> rounds)
        {
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }
            foreach (List<MatchupModel> m in rounds)
            {
                output += $"{ConvertMatchupsListsToString(m)}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;

        }
        public static void SaveRoundsToFile(this TournamentModel model,string  MatchupsFile,string MatchupEntriesFile)
        {
            //Loop through each round 
            //Loop through each matchup
            //Save the matchup and get an id
            //Loop through each entry,get the id and save it
            foreach(List<MatchupModel> round in model.Rounds)
            {
                foreach ( MatchupModel matchup in round)
                {
                    //Load all the matchups from file
                    //Get the top id and add one
                    //Store the id
                    //Save the matchup record
                    //
                    matchup.SaveMatchupToFile(MatchupsFile,MatchupEntriesFile);
                    
                }

            }
        }
        public static MatchupModel LookUpMatchById(int id)
        {
            List<string> matches = GlobalConfig.MatchupsFile.FullFilePath().LoadFile();


            foreach (string  matchup in matches)
            {
                string[] cols = matchup.Split(',');

                if (cols[0]==id.ToString())
                {
                    List<string> matchinMatchups = new List<string>();
                    matchinMatchups.Add(matchup);
                    return matchinMatchups.ConvertToMatchupModels().First();
                     
                }
            }
            return null;
        }
        public static List<MatchupEntriesModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            List<MatchupEntriesModel> output = new List<MatchupEntriesModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupEntriesModel m = new MatchupEntriesModel();
                m.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    m.TeamCompeting = null;
                }
                else
                {
                    m.TeamCompeting = LookUpTeamById(int.Parse(cols[1]));
                }
               
                m.Score = double.Parse(cols[2]);
                int parentMid = 0;
                if (int.TryParse(cols[3],out parentMid))
                {
                    m.ParentMatching = LookUpMatchById(int.Parse(cols[3]));
                }
                else
                {
                    m.ParentMatching = null;
                }
                output.Add(m);
               
            }
            return output;
        }
        private static List<MatchupEntriesModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntriesModel> output = new List<MatchupEntriesModel>();
            List<string> entries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach(string id in ids)
            {
               foreach( string entry in entries)
                {
                    string[] cols = entry.Split(',');//","

                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntryModels();


            return output;
        }
        private static TeamModel LookUpTeamById(int team)
        {

            List<string> teams = GlobalConfig.Teamsfile.FullFilePath().LoadFile();
           
            foreach(string Team in teams)
            {
                string[] cols = Team.Split(',');

                if (cols[0] == team.ToString())
                {
                    List<string> matchinteams = new List<string>();
                    matchinteams.Add(Team);
                    return matchinteams.CoverttoTeamModel(GlobalConfig.Playersfile).First();
                }
            }
            return null;
            
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupModel match = new MatchupModel();
                match.Id = int.Parse(cols[0]);

                match.Entries = ConvertStringToMatchupEntryModels( cols[1]);
                if (cols[2].Length == 0)
                {
                    match.Winner = null;
                }
                else
                {
                    match.Winner = LookUpTeamById(int.Parse(cols[2]));
                }
              
                match.MatchupRound = int.Parse(cols[3]);
                output.Add(match);
            }

            return output;
        }
        public static void SaveMatchupEntrYModelToFile(this MatchupEntriesModel model,string MatchupEntriesFile)
        {
            List<MatchupEntriesModel> entries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            entries.Add(model);

            List<string> lines = new List<string>();

            foreach(MatchupEntriesModel mentry in entries)
            {
                string parentmatchup = "";
                if (mentry.ParentMatching != null)
                {
                    parentmatchup = mentry.ParentMatching.Id.ToString();
                }
                string teamcompeting = "";

                if (mentry.TeamCompeting != null)
                {
                    teamcompeting = mentry.TeamCompeting.Id.ToString();
                }


                lines.Add($"{mentry.Id},{teamcompeting},{mentry.Score},{parentmatchup}");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntriesFile.FullFilePath(), lines);
        }
        public static void UpdateMatchupEntrYModelToFile(this MatchupEntriesModel model)
        {
            List<MatchupEntriesModel> entries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            MatchupEntriesModel oldentry = new MatchupEntriesModel();

            foreach(MatchupEntriesModel me in entries)
            {
                if (me.Id == model.Id)
                {
                    oldentry = me;
                }
            }
            entries.Remove(oldentry);
            entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntriesModel mentry in entries)
            {
                string parentmatchup = "";
                if (mentry.ParentMatching != null)
                {
                    parentmatchup = mentry.ParentMatching.Id.ToString();
                }
                string teamcompeting = "";

                if (mentry.TeamCompeting != null)
                {
                    teamcompeting = mentry.TeamCompeting.Id.ToString();
                }


                lines.Add($"{mentry.Id},{teamcompeting},{mentry.Score},{parentmatchup}");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntriesFile.FullFilePath(), lines);
        }
        public static void SaveMatchupToFile(this MatchupModel matchup,string matchupfile, string MatchupEntriesFile)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupsFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            int currentid = 1;
            if (matchups.Count > 0)
            {
                currentid = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }
            matchup.Id = currentid;
            matchups.Add(matchup);
            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{""},{winner},{m.MatchupRound}");

            }
            File.WriteAllLines(GlobalConfig.MatchupsFile.FullFilePath(), lines);

            foreach (MatchupEntriesModel entriesModel in matchup.Entries)
            {
                entriesModel.SaveMatchupEntrYModelToFile(MatchupEntriesFile);
            }
             lines = new List<string>();

            foreach(MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner!=null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntriesToList(m.Entries)},{winner},{m.MatchupRound}");

            }
            File.WriteAllLines(GlobalConfig.MatchupsFile.FullFilePath(), lines);
        }
        public static void UpdateMatchuptoFile(this MatchupModel matchup)
        {

            List<MatchupModel> matchups = GlobalConfig.MatchupsFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            MatchupModel oldMatchup = new MatchupModel();
            foreach  (MatchupModel m in matchups)
            {
                if (m.Id == matchup.Id)
                {
                    oldMatchup = m;
                }
            }
            matchups.Remove(oldMatchup);

            matchups.Add(matchup);
            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{""},{winner},{m.MatchupRound}");

            }
            File.WriteAllLines(GlobalConfig.MatchupsFile.FullFilePath(), lines);

            foreach (MatchupEntriesModel entriesModel in matchup.Entries)
            {
                entriesModel.UpdateMatchupEntrYModelToFile();
            }
            lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntriesToList(m.Entries)},{winner},{m.MatchupRound}");

            }
            File.WriteAllLines(GlobalConfig.MatchupsFile.FullFilePath(), lines);
        }
        public static string ConvertMatchupEntriesToList(List<MatchupEntriesModel> entries)
        {

            string output = "";
            if (entries.Count == 0)
            {
                return "";
            }
            foreach(MatchupEntriesModel e in entries)
            {
                output += $"{e.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        public static string ConvertMatchupsListsToString(List<MatchupModel> matchups)
        {
            string output = "";
            if (matchups.Count == 0)
            {
                return "";
            }
            foreach (MatchupModel m in matchups)
            {
                output += $"{m.Id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        public static string PrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return "";
            }
            foreach (PrizeModel p in prizes)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string TeamListToString(List<TeamModel> teams)
        {
            string output = "";
            if (teams.Count == 0)
            {
                return "";
            }
            foreach (TeamModel p in teams)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;

        }
        public static void SaveToPrizeFile(this List<PrizeModel> models ,string filename)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PricePercentage }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
        public static void SaveToPlayersFile(this List<PersonModel> models, string filename)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.Cellphone }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
        public static void Savetoteamfile(this List<TeamModel> ekipet,string filename)
        {
            List<string> lines = new List<string>();
            foreach(TeamModel t in ekipet)
            {
                lines.Add($"{t.Id},{t.TeamName},{ConvertPlayerListToString(t.TeamMembers)}");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
        private static string ConvertPlayerListToString(List<PersonModel> people)
        {
            string output = "";
            if (people.Count == 0)
            {
                return "";
            }
            foreach(PersonModel p in people)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

    }
}
