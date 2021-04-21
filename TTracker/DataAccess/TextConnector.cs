using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;
using TTracker.DataAccess.TextHelper;

namespace TTracker.DataAccess
{
  
    public class TextConnector : IDataConnection
    {
       
        public void CreatePerson(PersonModel Model)
        {
            List<PersonModel> players = GlobalConfig.Playersfile.FullFilePath().LoadFile().ConverttoPlayerModel();
            int currentId = 1;
            if (players.Count > 0)
            {
                currentId = players.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            players.Add(Model);
            players.SaveToPlayersFile(GlobalConfig.Playersfile);
         
        }

        // TODO -- 
        public void CreatePrize(PrizeModel Model)
        {
           List<PrizeModel> prizes= GlobalConfig.Prizesfile.FullFilePath().LoadFile().ConverttoPrizeModel();


            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            prizes.Add(Model);

            prizes.SaveToPrizeFile(GlobalConfig.Prizesfile);
            
           
        }

        public void CreateTeam(TeamModel Model)
        {
            List<TeamModel> Teams = GlobalConfig.Teamsfile.FullFilePath().LoadFile().CoverttoTeamModel(GlobalConfig.Playersfile);
            int currentId = 1;
            if (Teams.Count > 0)
            {
                currentId = Teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            Teams.Add(Model);
            Teams.Savetoteamfile(GlobalConfig.Teamsfile);
            

        }

        public void CreateTournamentModel(TournamentModel model)
        {
            List < TournamentModel > tournaments =
                GlobalConfig.Tournamentsfile.FullFilePath().LoadFile().ConvertToTournamentModel(GlobalConfig.Teamsfile, GlobalConfig.Playersfile, GlobalConfig.Prizesfile);
            
            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            model.SaveRoundsToFile(GlobalConfig.MatchupsFile, GlobalConfig.MatchupEntriesFile);

            tournaments.Add(model);

            tournaments.SavetoTournamentFile(GlobalConfig.Tournamentsfile);
            TTracker.TournamentLogic.UpdateTournamentResults(model);




        }

        public List<PersonModel> Get_PlayersAll()
        {
            return GlobalConfig.Playersfile.FullFilePath().LoadFile().ConverttoPlayerModel();
        }

        public List<TeamModel> Get_TeamsAll()
        {
            return GlobalConfig.Teamsfile.FullFilePath().LoadFile().CoverttoTeamModel(GlobalConfig.Playersfile);
        }

        public List<TournamentModel> Get_TournamentsAll()
        {
            return GlobalConfig.Tournamentsfile.FullFilePath().LoadFile().ConvertToTournamentModel(GlobalConfig.Teamsfile, GlobalConfig.Playersfile, GlobalConfig.Prizesfile);
        }

        public void UpdateMatchup(MatchupModel m)
        {
            m.UpdateMatchuptoFile();
        }
    }
}
