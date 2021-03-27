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
        PrizeModel CreatePrize(PrizeModel Model);
        PersonModel CreatePerson(PersonModel Model);
        TeamModel CreateTeam(TeamModel Model);
        TournamentModel CreateTournamentModel(TournamentModel model);
        List<PersonModel> Get_PlayersAll();
        List<TeamModel> Get_TeamsAll();

    }
}
