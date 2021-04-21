# TournamentTracker
A Tournament Tracker


EDIT TournamentTracker/TournamentUi/app.config  



        <add key="filePath" value="ur file path u want to store the  data" />
        <add key="ClientSettingsProvider.ServiceUri" value="" />
        <add key="greaterWins" value="1" /> dont change unless u want to track tournaments where teams with smaller score win
        <add key="SenderEmail" value="" /> ur sending email
        <add key="password" value="urpass" /> ur sending email password
        <add key="DisplaySender" value="ur name" /> name of the sender 
        
        the default database in which program runs is textfile file u may change in TournamentTracker/TournamentUi/program.cs
         set it to mysql 
        if u want to use mysql 
        Sql Code for creating needed tables and stored procedures
         test.sql is used just for testing it deletes all tables
        firstly run the storedprocedures.sql then db.sql(two times the last one)
         Also change the connection string in the app.config file if u using mysql 
         
         <connectionStrings>
          <add name="tournaments" connectionString="Server=localhost;Port=3310;Database=tournaments;Uid=root;Pwd=1234567890;" providerName="MySql.Data.MySqlClient" />
        </connectionStrings>
      
