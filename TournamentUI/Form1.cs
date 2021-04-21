using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTracker;
using TTracker.Models;

namespace TournamentUI
{
    public partial class Tournamentv : Form
    {
        private TournamentModel tournament;
        List<int> rounds = new List<int>();
        List<MatchupModel> matchups = new List<MatchupModel>();
        public Tournamentv(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;
            LoadFormData();

            LoadRounds();
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadFormData()
        {
            TournamentName.Text = tournament.TournamentName;
        }
        private void WireUpRoundsLists()
        {
            RoundDropdown.DataSource = null;
            RoundDropdown.DataSource = rounds;

           
        }
        private void WireUpMatchupsLists()
        {
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = matchups;
            matchupListBox.DisplayMember = "DisplayName";
        }
        private void LoadRounds()
        {
            rounds = new List<int>();
            rounds.Add(1);
            int currround = 1;
            foreach ( List<MatchupModel> r in  tournament.Rounds)
            {
                //if (r.FirstOrDefault() != null)
                
                    if (r.First().MatchupRound > currround)
                    {
                        currround = r.First().MatchupRound;
                        rounds.Add(currround);
                        //currround += 1;
                    }
               // RoundDropdown.DataSource = null;
                

            }
            

            WireUpRoundsLists();


        }

        private void RoundDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
            UpdateUnplayedMatchups();
        }
        private void LoadMatchups()
        {
            int round = (int)RoundDropdown.SelectedItem;
            foreach (List<MatchupModel> r in tournament.Rounds)
            {
                //if (r.First() != null)
                
                    if (r.First().MatchupRound == round)
                    {
                        matchups = r;
                    }
                
               
                   
                
                
            }
            WireUpMatchupsLists();
            DisplayMatchupInfo(matchups);
        }
        private void DisplayMatchupInfo(List<MatchupModel> M)
        {
            bool isvisible = M.Count > 0;
            teamOneName.Visible = isvisible;
            TeamoneScoreLabel.Visible = isvisible;
            teamOneScoreText.Visible = isvisible;
            teamtwoName.Visible = isvisible;
            teamtwoScoreText.Visible = isvisible;
            ScoreteamoneLabel.Visible = isvisible;
            VsLabel.Visible = isvisible;
            ScoreButton.Visible = isvisible;
        }

        private void LoadMatchup()
        {
           
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            for(int i = 0; i < m.Entries.Count;i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreText.Text = m.Entries[0].Score.ToString();

                        teamtwoName.Text = ">bye>";
                        teamtwoScoreText.Text = "";
                    }
                    else
                    {
                         teamOneName.Text = "Not Yet Set";
                       // teamOneName.Text = m.MatchupRound.ToString();
                        teamOneScoreText.Text = "";
                    }
                    
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamtwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamtwoScoreText.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamtwoName.Text = "Not Yet Set";
                        teamtwoScoreText.Text = "";
                    }

                }
            }
        }
        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchupListBox.SelectedItem != null)
            {
                LoadMatchup();
            }
           
        }
        private void UpdateUnplayedMatchups()
        {
            if (Unplayedbox.Checked)
            {
                List<MatchupModel> unplayedmatchups = new List<MatchupModel>();

                foreach (MatchupModel m in matchups)
                {
                    if (m.Winner == null)
                    {
                        unplayedmatchups.Add(m);
                    }
                }

                matchupListBox.DataSource = null;
                matchupListBox.DataSource = unplayedmatchups;
                matchupListBox.DisplayMember = "DisplayName";
                DisplayMatchupInfo(unplayedmatchups);
            }
            else
            {
                LoadMatchups();
            }
        }

        private void Unplayedbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUnplayedMatchups();



        }
        private string isValidData()
        {
            string output = "";
            double teamonescore = 0;
            double teamtwoscore = 0;
            bool scoreValid = double.TryParse(teamtwoScoreText.Text, out teamtwoscore);
            bool scoreValid1 = double.TryParse(teamOneScoreText.Text, out teamonescore);
            if (!scoreValid || !scoreValid1)
            {
                return "The score of team one is not a valid number";
            }
            if ( !scoreValid1)
            {
                return "The score of team two is not a valid number";
            }
            if (teamonescore == teamtwoscore)
            {
                return "This Application does not process ties!";
            }

            return output;
        }
        private void ScoreButton_Click(object sender, EventArgs e)
        {
            if (isValidData()!="")
            {
                MessageBox.Show($"Input Error: {isValidData()}");
                return;
            }
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamonescore = 0;
            double teamtwoscore = 0;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                       
                        bool scoreValid = double.TryParse(teamOneScoreText.Text, out teamonescore);
                        
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamonescore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1");
                            return;
                        }


                    }
                  

                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamtwoName.Text = m.Entries[1].TeamCompeting.TeamName;

                       
                        bool scoreValid = double.TryParse(teamtwoScoreText.Text, out teamtwoscore);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamtwoscore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2");
                            return;
                        }

                    }
                  

                }

            }


            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex )
            {

                MessageBox.Show($"The Application had the following error: { ex.Message}");
                return;
            }
            if (Unplayedbox.Checked)
            {
                UpdateUnplayedMatchups();
            }


        }
    }
}
