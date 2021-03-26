using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;

namespace TournamentUI
{
    public interface IPrizeRequester
    {
        void prizecomplete(PrizeModel model);
       
    }
}
