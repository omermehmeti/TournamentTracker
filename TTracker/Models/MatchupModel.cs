using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTracker.Models
{
    public class MatchupModel
    {
        public List<MatchupEntriesModel> Entries { get; set; } = new List<MatchupEntriesModel>();
        public TeamModel Winner { get; set; }
        public int MatchupRound { get; set; }


    }
}
