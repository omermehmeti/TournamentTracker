using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;
using TTracker.DataAccess.TextHelper;

namespace TTracker.DataAccess
{
  
    public class TextConnector : IDataConnection
    {
        private const string Prizesfile = "PrizeModels.csv";
        // TODO -- 
        public PrizeModel CreatePrize(PrizeModel Model)
        {
           List<PrizeModel> prizes= Prizesfile.FullFilePath().LoadFile().ConverttoPrizeModel();


            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            Model.Id = currentId;
            prizes.Add(Model);

            prizes.SaveToPrizeFile(Prizesfile);
            
            return Model;
        }
    }
}
