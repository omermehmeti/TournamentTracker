using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;
using System.Data;
using Dapper;

using MySql.Data.MySqlClient;

namespace TTracker.DataAccess

{
    public class MysqlConnector : IDataConnection
    {
        private const string db = "tournaments";
        public void CreatePerson(PersonModel Model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                /// running a Mysql stored procedure Using Dapper straight forward
                var p = new DynamicParameters();
                p.Add("@firstname", Model.FirstName);
                p.Add("@lastname", Model.LastName);
                p.Add("@emailaddress", Model.EmailAddress);
                p.Add("@cellphone", Model.Cellphone);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("insert_Players", p, commandType: CommandType.StoredProcedure);
                //Not working Dont Know why 

                Model.Id = p.Get<int>("@lid");


                
            }
        }

        public void CreatePrize(PrizeModel Model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                /// running a Mysql stored procedure Using Dapper straight forward
                var p = new DynamicParameters();
                p.Add("@placenumber",Model.PlaceNumber);
                p.Add("@placename", Model.PlaceName);
                p.Add("@prizeamount", Model.PrizeAmount);
                p.Add("@prizepercentage", Model.PricePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("insert_Prize",p,commandType: CommandType.StoredProcedure);
                //Not working Dont Know why 
               
                    Model.Id=p.Get<int>("@lid");
               

                
            }


           
        }

        public void CreateTeam(TeamModel Model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                /// running a Mysql stored procedure Using Dapper straight forward
                var p = new DynamicParameters();
                p.Add("@TeamName", Model.TeamName);
               
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("Insert_Teams", p, commandType: CommandType.StoredProcedure);
                //Not working Dont Know why 

                int rowCount = p.Get<int>("@lid");
                Model.Id = rowCount;
                int nr = Model.Id;
               
                foreach(PersonModel i in Model.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@teamid", nr);
                    p.Add("@personid", i.Id);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                    connection.Execute("Insert_TeamMembers", p, commandType: CommandType.StoredProcedure);

                }


                
            }

        }

        public void CreateTournamentModel(TournamentModel Model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {


                SaveTournament(connection, Model);
                SaveTournamentPrizes(connection, Model);
                SaveTournamentTeams(connection, Model);
                SaveTournamentRounds(connection, Model);



                TTracker.TournamentLogic.UpdateTournamentResults(Model);
            }
        
        }
        private void SaveTournamentRounds(IDbConnection connection, TournamentModel Model)
        {
            // LOGIC ------
            // Loop through the rounds 
            //Loop through matchups
            // Save the Matchup
            //Loop through entries Save themm 
            ///------
            ///

            foreach(List<MatchupModel> round in Model.Rounds)
            {
                foreach(MatchupModel matchup in round)
                {
                    var p = new DynamicParameters();
                    p.Add("@tid", Model.Id);
                    p.Add("@round", matchup.MatchupRound);

                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                    p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("insert_matchups", p, commandType: CommandType.StoredProcedure);
                    matchup.Id = p.Get<int>("@lid");

                    foreach(MatchupEntriesModel entry in matchup.Entries)
                    {


                         p = new DynamicParameters();
                        p.Add("@mchid", matchup.Id);
                       
                        if (entry.ParentMatching == null)
                        {
                            p.Add("@parentmid", null);
                        }
                        else
                        {
                            p.Add("@parentmid", entry.ParentMatching.Id);

                        }
                        if (entry.TeamCompeting == null)
                        {
                            p.Add("@tcomp", null);
                        }
                        else
                        {
                            p.Add("@tcomp", entry.TeamCompeting.Id);

                        }


                        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                        p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        connection.Execute("Insert_Matchup_Entries", p, commandType: CommandType.StoredProcedure);
                     
                    }

                }
            }
        }
        private void SaveTournament(IDbConnection connection,TournamentModel Model)
        {
            /// running a Mysql stored procedure Using Dapper straight forward
            var p = new DynamicParameters();
            p.Add("@tname", Model.TournamentName);
            p.Add("@tfee", Model.EntryFee);


            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("Insert_Tournaments", p, commandType: CommandType.StoredProcedure);
            //Not working Dont Know why 

            int rowCount = p.Get<int>("@lid");
            Model.Id = rowCount;
            int nr = Model.Id;
        }
        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel Model)
        {
            foreach (PrizeModel i in Model.Prizes)
            {
               var p = new DynamicParameters();
                p.Add("@tid", Model.Id);
                p.Add("@pid", i.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("@lid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("Insert_TournamentPrizes", p, commandType: CommandType.StoredProcedure);

            }
        }

        private void SaveTournamentTeams(IDbConnection connection, TournamentModel Model)
        {
            foreach (TeamModel tm in Model.EnteredTeams)
            {
                var  p = new DynamicParameters();
                p.Add("@tid", Model.Id);
                p.Add("@teamid", tm.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                connection.Execute("insert_tournament_entries", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonModel> Get_PlayersAll()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<PersonModel>("spGetAllPeople").ToList();
            }
            return output;
        }

        public List<TeamModel> Get_TeamsAll()
        {
            List<TeamModel> output;
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<TeamModel>("get_teams_all").ToList();
                foreach(TeamModel tm in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamId", tm.Id);
                    tm.TeamMembers = connection.Query<PersonModel>("spTeamMembersGetByTeamId",p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;

        }

        public List<TournamentModel> Get_TournamentsAll()
        {
            List<TournamentModel> output;
            var p = new DynamicParameters();
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<TournamentModel>("spTournamentsGetAll").ToList();

                foreach (TournamentModel t  in output)
                {
                    // Populate Prizes
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.Prizes = connection.Query<PrizeModel>("spGetPrizesByTournament", p, commandType: CommandType.StoredProcedure).ToList();


                    //populate teams
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.EnteredTeams = connection.Query<TeamModel>("spGetTeamByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (TeamModel tm in t.EnteredTeams)
                    {
                        var pi = new DynamicParameters();
                        pi.Add("@TeamId", tm.Id);
                        tm.TeamMembers = connection.Query<PersonModel>("spTeamMembersGetByTeamId", pi, commandType: CommandType.StoredProcedure).ToList();
                    }

                    //populate rounds
                     p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("spGetMatchupGetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (MatchupModel m in matchups)
                    {
                         p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);
                        m.Entries= connection.Query<MatchupEntriesModel>("spGetMatchupEntriesByMatchup", p, commandType: CommandType.StoredProcedure).ToList();


                        //populate each entry 2 models
                        //populate each matchup one model

                        List<TeamModel> allTeams = Get_TeamsAll();

                        if (m.WinnerId > 0)
                        {
                            m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                        }
                        foreach (MatchupEntriesModel me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }
                            if (me.ParentMatchupId > 0)
                                {
                                    me.ParentMatching = matchups.Where(x => x.Id == (me.ParentMatchupId)).First();
                                }
                            
                           

                        }
                    }


                    
                    /// List<List<MatchupModel>>
                    // Populating the rounds 
                    List<MatchupModel> currentrow = new List<MatchupModel>();
                    int currentround = 1;
                    foreach (MatchupModel m in matchups)
                    {
                        /// Big BUG Here
                        if (m.MatchupRound > currentround)
                        {
                            t.Rounds.Add(currentrow);
                            currentrow = new List<MatchupModel>();
                            currentround += 1;
                        }
                        currentrow.Add(m);

                    }
                    t.Rounds.Add(currentrow);



                }


               // Populate Prizes 
               //Populate Teams
               //Populate Rounds
               //
            }
            return output;

            
        }

        public void UpdateMatchup(MatchupModel m)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                
                if (m.Winner != null)
                {
                    p.Add("@ID", m.Id);
                    p.Add("@winnerId", m.Winner.Id);
                    connection.Execute("Matchups_Update", p, commandType: CommandType.StoredProcedure);
                   



                    
                }
                foreach (MatchupEntriesModel me in m.Entries)
                {

                    if (me.TeamCompeting != null)
                    {
                        p = new DynamicParameters();
                        p.Add("@ID", me.Id);
                        p.Add("@a", me.TeamCompeting.Id);
                        p.Add("@score", me.Score);

                        connection.Execute("Matchup_Entries_Update", p, commandType: CommandType.StoredProcedure);
                    }




                }



            }

            
        }
    }
}
