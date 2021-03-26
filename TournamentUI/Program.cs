using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TournamentUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // use the Class Library namspace cause happened a error during firts build
            TTracker.GlobalConfig.InitializeConnections1(TTracker.DatabaseType.MySql);
           
            
           
            
            Application.Run(new CreateTournamentForm());
        }
    }
}
