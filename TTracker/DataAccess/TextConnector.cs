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
        private const string Prizesfile = "PrizeModels.csv";
        private const string Playersfile = "PlayerModels.csv";
        private const string Teamsfile = "TeamModel.csv";
        private const string Tournamentsfile = "TournamentModels.csv";
        private const string MatchupsFile = "MatchupsModels.csv";
        private const string MatchupEntriesFile = "MatchupEntriesModels.csv";
        public PersonModel CreatePerson(PersonModel Model)
        {
            List<PersonModel> players = Playersfile.FullFilePath().LoadFile().ConverttoPlayerModel();
            int currentId = 1;
            if (players.Count > 0)
            {
                currentId = players.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            players.Add(Model);
            players.SaveToPlayersFile(Playersfile);
            return Model;
        }

        // TODO -- 
        public PrizeModel CreatePrize(PrizeModel Model)
        {
           List<PrizeModel> prizes= Prizesfile.FullFilePath().LoadFile().ConverttoPrizeModel();


            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            prizes.Add(Model);

            prizes.SaveToPrizeFile(Prizesfile);
            
            return Model;
        }

        public TeamModel CreateTeam(TeamModel Model)
        {
            List<TeamModel> Teams = Teamsfile.FullFilePath().LoadFile().CoverttoTeamModel(Playersfile);
            int currentId = 1;
            if (Teams.Count > 0)
            {
                currentId = Teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            Teams.Add(Model);
            Teams.Savetoteamfile(Teamsfile);
            return Model;

        }

        public TournamentModel CreateTournamentModel(TournamentModel model)
        {
            List < TournamentModel > tournaments = Tournamentsfile.FullFilePath().LoadFile().ConvertToTournamentModel(Teamsfile,Playersfile,Prizesfile);
            
            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            model.SaveRoundsToFile(MatchupsFile,MatchupEntriesFile);

            tournaments.Add(model);

            tournaments.SavetoTournamentFile(Tournamentsfile);

            return model;

        }

        public List<PersonModel> Get_PlayersAll()
        {
            return Playersfile.FullFilePath().LoadFile().ConverttoPlayerModel();
        }

        public List<TeamModel> Get_TeamsAll()
        {
            return  Teamsfile.FullFilePath().LoadFile().CoverttoTeamModel(Playersfile);
        }
    }
}
