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
using TTracker.DataAccess;

namespace TournamentUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingform;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();
            callingform = caller;
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (validateform())
            {
                PrizeModel model = new PrizeModel(
                    PlaceNameValue.Text,
                    PlaceNumberValue.Text,
                    PlaceAmountValue.Text,
                    PleacePercentageValue.Text);



                TTracker.GlobalConfig.Connections.CreatePrize(model);
                callingform.prizecomplete(model);
                this.Close();
                
                PlaceNameValue.Text = "";
                PlaceNumberValue.Text = "";
                PlaceAmountValue.Text = "0";
                PleacePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid Entries");
            }
        }
        private bool validateform()
        {
            bool output = true;
            int PlaceNumber = 0;
            if (!int.TryParse(PlaceNumberValue.Text,out PlaceNumber))
            {
                output = false;
            }
            if (PlaceNumber < 1)
            {
                output = false;
            }
            if (PlaceNameValue.Text.Length == 0)
            {
                output = false;
            }


            decimal PrizeAmount = 0;
            double prizePercentage = 0;


            bool prizeamountvalid = decimal.TryParse(PlaceAmountValue.Text, out PrizeAmount);
            bool prizepercentagevalid = double.TryParse(PleacePercentageValue.Text, out prizePercentage);


            if(prizeamountvalid==false || prizepercentagevalid == false)
            {
                output = false;
            }
            if (PrizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            return output;
        }

       
    }
}
