using System;
using System.Collections.Generic;
using System.Linq;


using System.Text;
using System.Threading.Tasks;

namespace TTracker.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public double PrizeAmount { get; set; }
        public double PricePercentage { get; set; }
        public PrizeModel()
        {

        }
        public PrizeModel(string placeName,string placeNumber,string prizeAmount,string prizePercentage)
        {
            PlaceName = placeName;
            int placeNumberValur = 0;
            int.TryParse(placeNumber,out placeNumberValur);
            PlaceNumber = placeNumberValur;
            double prizeAmountValue = 0;
            double.TryParse(prizeAmount,out prizeAmountValue);
            PrizeAmount = prizeAmountValue;
            double prizePerxentageValue = 0;
            double.TryParse(prizePercentage, out prizePerxentageValue);
            PricePercentage = prizePerxentageValue;
        }
    }
}
