using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;


namespace TTracker
{
    public static class TournamentLogic
    {
        //     Logic
        // Order the List of teams Randomly
        //Check If it is Big enough
        //2*2*2*2 
        // create our first round of matchups
        //Create other rounds after the first one

        public static void CreateRounds(TournamentModel Tournament)
        {
            
            List<TeamModel> RandomizedTeams = RandomizeTeamOrder(Tournament.EnteredTeams);
            int rounds = FindNumberOfRounds(RandomizedTeams.Count);
            int byes = NumberOfByes(rounds,RandomizedTeams.Count);
            Tournament.Rounds.Add(CreateFirstRound(byes, RandomizedTeams));
            CreateOtherRounds(Tournament, rounds);
            //UpdateTournamentResults(Tournament);
        }
        private static void CreateOtherRounds(TournamentModel tournament,int rounds)
        {
            int round = 2;
            List<MatchupModel> previosRound = tournament.Rounds[0];
            List<MatchupModel> currentround = new List<MatchupModel>();
            MatchupModel currMu = new MatchupModel();
            while (round <= rounds)
            {
                foreach(MatchupModel m in previosRound)
                {
                    currMu.Entries.Add(new MatchupEntriesModel { ParentMatching = m });
                    if (currMu.Entries.Count > 1)
                    {
                        currMu.MatchupRound = round;
                        currentround.Add(currMu);
                        currMu = new MatchupModel();
                    }
                }
                tournament.Rounds.Add(currentround);
                previosRound = currentround;
                currentround = new List<MatchupModel>();
                round += 1;
            }
        }
        public static void UpdateTournamentResults(TournamentModel tournament)
        {
            int startinground = tournament.CheckCurrenRound();
            List<MatchupModel> toScore = new List<MatchupModel>();
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel rm in round)
                {

                    if (  rm.Winner==null &&(rm.Entries.Any(x=>x.Score!=0)||rm.Entries.Count==1))
                    {
                        toScore.Add(rm);
                    }
                
                
                }

            }
            ScoreMatchups(toScore);
            AdvanceWinners(toScore,tournament);
            toScore.ForEach(x => GlobalConfig.Connections.UpdateMatchup(x));
            int endinground = tournament.CheckCurrenRound();
            if (endinground > startinground)
            {
                //Alert Use
                tournament.AlertUsersToNewRound();
            }



            //GlobalConfig.Connections.UpdateMatchup(m);
        }
        public static void AlertUsersToNewRound(this TournamentModel model)
        {
            int currentroundNumber = model.CheckCurrenRound();
            List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentroundNumber).First();

            foreach (MatchupModel item in currentRound)
            {
                foreach(MatchupEntriesModel me in item.Entries)
                {
                    foreach(PersonModel player in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(player, me.TeamCompeting.TeamName, item.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }



        }

        public static void AlertPersonToNewRound(PersonModel player, string teamCompeting, MatchupEntriesModel competitor)
        {
            if (player.EmailAddress.Length == 0)
            {
                return;
            }
            
           
            string subject = "";
            string to= "";
            StringBuilder body = new StringBuilder();
            if (competitor != null)
            {
                subject = $"You have a new Matchup with :{competitor.TeamCompeting.TeamName}";
                body.AppendLine("<h1>You have a new Match Up</h1>");
                body.Append(Environment.NewLine);
                body.Append("<strong> Competitor : </strong>");
                body.AppendLine(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a great time");
                body.AppendLine();
                body.AppendLine("~Tournament tracker");

            }
            else
            {
                subject = "You have a bye week";
                body.AppendLine("Enjoy your round off");
                body.AppendLine("Have a great time");
                body.AppendLine();
                body.AppendLine("~Tournament tracker");
            }
            to=player.EmailAddress;
            EmailLogic.SendEmail(to, subject, body.ToString());

        }

        private static int CheckCurrenRound(this TournamentModel model)
        {
            int output = 1;
            foreach(List<MatchupModel> round in model.Rounds)
            {
                if (round.All(x=>x.Winner!=null))
                {
                    output += 1;
                }
            }
            return output;
        }
        private static void AdvanceWinners(List<MatchupModel> matches, TournamentModel tournament)
        {
            foreach(MatchupModel m in matches)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntriesModel me in rm.Entries)
                        {
                            if (me.ParentMatching != null)
                            {
                                if (me.ParentMatching.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connections.UpdateMatchup(rm);
                                }
                            }

                        }
                    }
                }
            }

        }
        private static  void ScoreMatchups(List<MatchupModel> matches)
        {
            // 1 0r 0
            string greaterWins = System.Configuration.ConfigurationManager.AppSettings["greaterWins"];

            foreach(MatchupModel m in matches)
            {
                // check for bye week
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;

                }
                if (greaterWins == "0")
                {
                    // lowscorewins
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if(m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We dont allow ties in this Application");
                    }

                }
                else
                {
                    //high score wins
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We dont allow ties in this Application");
                    }
                }
            }
            
            
            //if (teamonescore > teamtwoscore)
            //{
            //    //Team One Wins
            //    m.Winner = m.Entries[0].TeamCompeting;
            //}
            //else if (teamtwoscore > teamonescore)
            //{
            //    m.Winner = m.Entries[1].TeamCompeting;
            //}
            //else
            //{
            //    MessageBox.Show("I do not handle Tie Games");
            //}

        }
        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams )
        {
            List<MatchupModel> output = new List<MatchupModel>();

            MatchupModel curr = new MatchupModel();


            foreach(TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntriesModel { TeamCompeting = team });
                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();
                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return output;
        }
        private static int NumberOfByes(int rounds ,int NumberOfTeams)
        {
            int output = 0;
            int TotalTeams = 1;
            for(int i = 1; i <= rounds; i++)
            {
                TotalTeams *= 2;
            }
            output = TotalTeams - NumberOfTeams;
            return output;
        }
        private static int FindNumberOfRounds(int teamcount)
        {
            int output = 1; ;
            int val = 2;
            while (val<teamcount)
            {
                output += 1;

                val *= 2;

            }
            return output;
        }
        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> Teams)
        {
            return Teams.OrderBy(x => Guid.NewGuid()).ToList();
          
        }

    }
}
