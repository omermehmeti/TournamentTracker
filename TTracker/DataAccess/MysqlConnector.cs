using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models;
using System.Data;
using Dapper;

using MySql.Data.MySqlClient;

namespace TTracker.DataAccess

{
    public class MysqlConnector : IDataConnection
    {
        public PrizeModel CreatePrize(PrizeModel Model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString("tournaments")))
            {
                /// running a Mysql stored procedure Using Dapper straight forward
                var p = new DynamicParameters();
                p.Add("@placenumber",Model.PlaceNumber);
                p.Add("@placename", Model.PlaceName);
                p.Add("prizeamount", Model.PrizeAmount);
                p.Add("@prizepercentage", Model.PricePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                connection.Execute("insert_Prize",p,commandType: CommandType.StoredProcedure);
                //Not working Dont Know why 
               
                    Model.Id = p.Get<dynamic>("@id");
                
               
                return Model;
            }


           
        }
    }
}
