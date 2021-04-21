using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;

namespace TTracker.DataAccess
{
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel Model);
        void CreatePerson(PersonModel Model);
        void CreateTeam(TeamModel Model);
        void CreateTournamentModel(TournamentModel model);
        List<PersonModel> Get_PlayersAll();
        List<TeamModel> Get_TeamsAll();
        List<TournamentModel> Get_TournamentsAll();
        void UpdateMatchup(MatchupModel m);

    }
}
