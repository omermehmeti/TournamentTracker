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
    public partial class CreateTournamentForm : Form,IPrizeRequester,IteamRequester
    {
        List<TeamModel> avaiableteams = TTracker.GlobalConfig.Connections.Get_TeamsAll();
        List<TeamModel> selectedTeams=new List<TeamModel>();
        List<PrizeModel> selectedprizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            InitializeLists();
        }
        private void InitializeLists()
        {
            SelectTeamDrop.DataSource = null;
           SelectTeamDrop.DataSource = avaiableteams;
            SelectTeamDrop.DisplayMember = "TeamName";

            TournamentPlayersListBox.DataSource = null;
            TournamentPlayersListBox.DataSource = selectedTeams;
            TournamentPlayersListBox.DisplayMember= "TeamName";

            PrizesBox.DataSource = null;
           PrizesBox.DataSource = selectedprizes;
            PrizesBox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)SelectTeamDrop.SelectedItem;
            if (t != null)
            {
                avaiableteams.Remove(t);
                selectedTeams.Add(t);
                InitializeLists();
            }
        }

        private void CreatePrize_Click(object sender, EventArgs e)
        {
            //call the create prize form
            //get back from that form a prizemodel
            //add that prize model to selected prize models


            //1
            CreatePrizeForm pfrm = new CreatePrizeForm(this);
            pfrm.Show();

        }

        public void prizecomplete(PrizeModel model)
        {
            selectedprizes.Add(model);
            InitializeLists();
        }

        public void teamcomplete(TeamModel model)
        {
            selectedTeams.Add(model);
            InitializeLists();
        }

        private void CreateNewTeamLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeam frm = new CreateTeam(this);
            frm.Show();
        }

        private void DeleteSelectedTeams_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)TournamentPlayersListBox.SelectedItem;
            if (t != null)
            {
                selectedTeams.Remove(t);
                avaiableteams.Add(t);
                InitializeLists();
            }
        }

        private void DeletePrizes_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)PrizesBox.SelectedItem;
            if (p != null)
            {
                selectedprizes.Remove(p);
                InitializeLists();

            }
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            // Validate Data
            decimal fee = 0;
            bool feacceptable = decimal.TryParse(EnterFeeValue.Text, out fee);
            if (!feacceptable)
            {
                MessageBox.Show("Enter a valid  entry fee","Invalid fee",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Create our tournament model
            TournamentModel Tm = new TournamentModel();
            Tm.TournamentName = TournamentNameText.Text;
            Tm.EntryFee =fee;
            //foreach(PrizeModel p in selectedprizes)
            //{
            //    Tm.Prizes.Add(p);
            //}
            Tm.Prizes = selectedprizes;
            Tm.EnteredTeams = selectedTeams;

            //Create our matchups
            TTracker.TournamentLogic.CreateRounds(Tm);



            //Create tournament entry
            //Create alll of the prizes entries
            //Create all of the team entries

            TTracker.GlobalConfig.Connections.CreateTournamentModel(Tm);
            //TTracker.TournamentLogic.UpdateTournamentResults(Tm);
            Tm.AlertUsersToNewRound();
            Tournamentv frm = new Tournamentv(Tm);
            frm.Show();
            this.Close();


            //Create our matchups
        }

      
    }
}
