using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTracker.Models
{
    public class MatchupEntriesModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in the matchup
        /// </summary>

        public int TeamCompetingId { get; set; }
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the Particular score;
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Represents the matchup tha this team come as winner.
        /// </summary>
        /// 
        public int ParentMatchupId { get; set; }
        public MatchupModel ParentMatching { get; set; }
        //public MatchupEntriesModel(double InitialScore)
        //{

        //}
    }
}
