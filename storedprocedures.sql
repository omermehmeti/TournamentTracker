####
create schema test;
USE `test`;
DROP procedure IF EXISTS `spTournamentsGetAll`;

DELIMITER $$
USE `test`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTournamentsGetAll`()
BEGIN
select * from tournaments
where activity ='active';
END$$

DELIMITER ;
USE `test`;
DROP procedure IF EXISTS `spTeamMembersGetByTeamId`;

DELIMITER $$
USE `test`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spTeamMembersGetByTeamId`(in TeamId int)
BEGIN
select  pe.*
from people p
inner join teammembers tm on p.id =tm.PersonId
where tm.TeamId =TeamId;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTeamByTournament`(in TournamentId int)
BEGIN
select t.*
from teams t 
inner join tournamententries te on te.TeamId = t.id
where te.Tournamentid = TournamentId;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPrizesByTournament`(in TournamentId int)
BEGIN
	select p.*
    from prizes as p 
    inner join tournamentsprizes tp on p.id =tp.PrizeId
    where tp.id =TournamentId;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMatchupGetByTournament`(in   TournamentId int)
begin
select m.*
from matchup m 

where m.Tournamentid =  TournamentId
order by m.MatchUpRound;

END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMatchupEntriesByMatchup`(in MatchupId int)
BEGIN
select *
from matchupentries as a
where a.matchupid = MatchupId;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAllPeople`()
BEGIN
Select *
from people;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Matchups_Update`(
in ID int,
in winnerID int)
BEGIN
update matchup as m 
set m.WinnerId =winnerID
where m.id=ID;

END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Matchup_Entries_Update`(
in ID int,
in a int,
in score float)
BEGIN

update matchupentries as me set me.TeamCompetingId = a,me.Score =score
where me.id =ID;

END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Last_Inserted_Prize`(out id int )
BEGIN
select id =last_insert_id() from prizes;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Tournaments`(in tname varchar(50),
in tfee float,
inout id int,
out lid int

)
BEGIN
insert into tournaments(TournamentName,EntryFee,activity)
values(tname,tfee,'active');
set lid =last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_TournamentPrizes`(in tid int,in pid int,inout id int,out lid int)
BEGIN
insert into tournamentsprizes (TournamentId,PrizeId)
values (tid,pid);

select id =last_insert_id();
set lid = last_insert_id();


END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_tournament_entries`(in tid int ,in teamid int ,inout id int)
BEGIN
insert into tournamententries(TournamentID,TeamId)
values (tid,teamid);
select id =last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Teams`(in TeamName varchar(30),
inout id int,
out lid int )
BEGIN
insert into teams(teamname)
values(TeamName);
select id =last_insert_id();
set lid =last_insert_id();

END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_TeamMembers`(
in teamid int ,
in personid int,
inout id int
 )
BEGIN
insert into teammembers(TeamId,PersonId)
values(teamid,personid);

select last_insert_id();




END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_Prize`(in placenumber int,in placename varchar(20),in prizeamount double , in prizepercentage float, inout id int,OUT lid int)
BEGIN
insert into prizes (PlaceNumber,PlaceName,PrizeAmount,PrizePercentage)
          values(placenumber,placename,prizeamount,prizepercentage);
select id =last_insert_id();
set lid = last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_Players`(in firstname varchar(30)
									,in lastname varchar(30)
									,in emailaddress varchar(30)
									,cellphone varchar(30),
										inout id int,
                                        out lid int
                                        )
BEGIN
insert into people(FirstName,LastName,EmailAddress,CellphoneNumber)
values(firstname,lastname,emailaddress,cellphone);
select last_insert_id();
set lid =last_insert_id();

END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_matchups`(in  tid int ,in round int,inout id int,out lid int )
BEGIN
insert into matchup(tournamentid,MatchUpRound)
values(tid,round);
set lid =last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Matchup_Entries`(in mchid int,
in parentmid int ,
 in tcomp int ,
 inout id int,
 out lid int
 )
BEGIN
insert into matchupentries(matchupid,ParentMatchupId,TeamCompetingId)
values (mchid,parentmid,tcomp);
set lid = last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_teams_all`()
BEGIN
select * from teams;
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_team_id`(out id int)
BEGIN

select teams.id =last_insert_id();
END$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Deletetables`()
BEGIN
drop table matchup;
drop table matchupentries;
drop table prizes;
drop table people;
drop table tournamententries;
drop table teams;
drop table teammembers;
drop table tournaments;
drop table tournamentsprizes;
END$$



DELIMITER ;
