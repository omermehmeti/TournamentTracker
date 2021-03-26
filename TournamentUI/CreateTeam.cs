using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTracker.Models;

namespace TournamentUI
{
    public partial class CreateTeam : Form
    {
       
        private List<PersonModel> avaiableTeamMembers = TTracker.GlobalConfig.Connections.Get_PlayersAll();
        private List<PersonModel> SelectedTeammembers = new List<PersonModel>();
        private IteamRequester calling;
        public CreateTeam(IteamRequester caller)
        {
            InitializeComponent();
            //CreateSampleData();
            calling = caller;
            wireupLists();
        }
        public CreateTeam()
        {
            InitializeComponent();
            //CreateSampleData();
           
            wireupLists();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void CreateSampleData()
        {
            avaiableTeamMembers.Add(new PersonModel {FirstName="tim",LastName="mehmeti" });
            avaiableTeamMembers.Add(new PersonModel { FirstName = "omer", LastName = "mehmeti" });

            SelectedTeammembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            SelectedTeammembers.Add(new PersonModel { FirstName = "Jemil", LastName = "Smithaj" });
        }
        private void wireupLists()
        {
           
            SelectTeamMembersDrop.DataSource = null;
            SelectTeamMembersDrop.DataSource = avaiableTeamMembers;
            SelectTeamMembersDrop.DisplayMember = "FullName";

            TeamMembersListBox.DataSource = null;
            TeamMembersListBox.DataSource = SelectedTeammembers;
            TeamMembersListBox.DisplayMember = "FullName";

        }

        private void CreatePlayerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = FirstNameValue.Text;
                p.LastName = SurnameValue.Text;
                p.EmailAddress = EmailValue.Text;
                p.Cellphone = CellPhoneValue.Text;
                TTracker.GlobalConfig.Connections.CreatePerson(p);

                //
                SelectedTeammembers.Add(p);

                wireupLists();


                FirstNameValue.Text = "";
                SurnameValue.Text = "";
                EmailValue.Text = "";
                CellPhoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill all fields");
            }
        }
        private bool ValidateForm()
        {
            if (FirstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (SurnameValue.Text.Length == 0)
            {
                return false;
            }
            if (EmailValue.Text.Length == 0)
            {
                return false;
            }
            if (CellPhoneValue.Text.Length== 0)
            {
                return false;
            }

            return true;
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)SelectTeamMembersDrop.SelectedItem;
            if (p != null)
            {
                avaiableTeamMembers.Remove(p);
                SelectedTeammembers.Add(p);

                wireupLists();
            }
           
           
        }

        private void RemoveSelectedMember_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamMembersListBox.SelectedItem;
            if (p != null)
            {
                SelectedTeammembers.Remove(p);
                avaiableTeamMembers.Add(p);

                wireupLists();
            }
           

        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel ekipi = new TeamModel();
            ekipi.TeamName = CreateTeamNameValue.Text;
            ekipi.TeamMembers = SelectedTeammembers;
            TTracker.GlobalConfig.Connections.CreateTeam(ekipi);
            calling.teamcomplete(ekipi);
            this.Close();

        }
    }
}
