using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTracker.Models
{
    public class MatchupModel
    {
        public int Id { get; set; }
        public List<MatchupEntriesModel> Entries { get; set; } = new List<MatchupEntriesModel>();
        public TeamModel Winner { get; set; }
        /// <summary>
        /// The winnwr id is used to look up for the winner
        /// </summary>
        public int WinnerId { get; set; }
        public int MatchupRound { get; set; }

        public string DisplayName
        {
            get
            {
                string output = "";
                foreach(MatchupEntriesModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {

                            output += $" vs.{me.TeamCompeting.TeamName} ";
                        }
                    }
                    else
                    {
                        output = "Matchup not yet determined";
                        break;
                    }

                   
                }
                return output;
            }
        }

    }
}
