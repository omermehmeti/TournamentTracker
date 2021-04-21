#run it two times

CREATE TABLE `prizes` (
   `id` int NOT NULL AUTO_INCREMENT,
   `PlaceNumber` int NOT NULL,
   `PlaceName` varchar(20) DEFAULT NULL,
   `PrizeAmount` double DEFAULT NULL,
   `PrizePercentage` float DEFAULT NULL,
   PRIMARY KEY (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `people` (
   `id` int NOT NULL AUTO_INCREMENT,
   `FirstName` varchar(30) NOT NULL,
   `LastName` varchar(30) NOT NULL,
   `EmailAddress` varchar(30) NOT NULL,
   `CellphoneNumber` varchar(30) NOT NULL,
   PRIMARY KEY (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `teams` (
   `id` int NOT NULL AUTO_INCREMENT,
   `teamname` varchar(30) DEFAULT NULL,
   PRIMARY KEY (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `teammembers` (
   `id` int NOT NULL AUTO_INCREMENT,
   `TeamId` int NOT NULL,
   `PersonId` int NOT NULL,
   PRIMARY KEY (`id`),
   KEY `TeamId` (`TeamId`),
   KEY `PersonId` (`PersonId`),
   CONSTRAINT `teammembers_ibfk_1` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`id`),
   CONSTRAINT `teammembers_ibfk_2` FOREIGN KEY (`PersonId`) REFERENCES `people` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `matchup` (
   `id` int NOT NULL AUTO_INCREMENT,
   `tournamentid` int DEFAULT NULL,
   `WinnerId` int DEFAULT NULL,
   `MatchUpRound` int NOT NULL,
   PRIMARY KEY (`id`),
   KEY `WinnerId` (`WinnerId`),
   KEY `tournamentid` (`tournamentid`),
   CONSTRAINT `matchup_ibfk_1` FOREIGN KEY (`WinnerId`) REFERENCES `teams` (`id`),
   CONSTRAINT `matchup_ibfk_2` FOREIGN KEY (`tournamentid`) REFERENCES `tournaments` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `matchupentries` (
   `id` int NOT NULL AUTO_INCREMENT,
   `matchupid` int DEFAULT NULL,
   `ParentMatchupId` int DEFAULT NULL,
   `TeamCompetingId` int DEFAULT NULL,
   `Score` float DEFAULT NULL,
   PRIMARY KEY (`id`),
   KEY `matchupid` (`matchupid`),
   KEY `TeamCompetingId` (`TeamCompetingId`),
   KEY `ParentMatchupId` (`ParentMatchupId`),
   CONSTRAINT `matchupentries_ibfk_1` FOREIGN KEY (`matchupid`) REFERENCES `matchup` (`id`),
   CONSTRAINT `matchupentries_ibfk_2` FOREIGN KEY (`TeamCompetingId`) REFERENCES `teams` (`id`),
   CONSTRAINT `matchupentries_ibfk_3` FOREIGN KEY (`ParentMatchupId`) REFERENCES `matchup` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `tournaments` (
   `id` int NOT NULL AUTO_INCREMENT,
   `TournamentName` varchar(50) NOT NULL,
   `EntryFee` float NOT NULL,
   `activity` varchar(15) DEFAULT NULL,
   PRIMARY KEY (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `tournamententries` (
   `id` int NOT NULL AUTO_INCREMENT,
   `Tournamentid` int NOT NULL,
   `TeamId` int NOT NULL,
   PRIMARY KEY (`id`),
   KEY `Tournamentid` (`Tournamentid`),
   KEY `TeamId` (`TeamId`),
   CONSTRAINT `tournamententries_ibfk_1` FOREIGN KEY (`Tournamentid`) REFERENCES `tournaments` (`id`),
   CONSTRAINT `tournamententries_ibfk_2` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 
 CREATE TABLE `tournamentsprizes` (
   `id` int NOT NULL AUTO_INCREMENT,
   `TournamentId` int DEFAULT NULL,
   `PrizeId` int DEFAULT NULL,
   PRIMARY KEY (`id`),
   KEY `TournamentId` (`TournamentId`),
   KEY `PrizeId` (`PrizeId`),
   CONSTRAINT `tournamentsprizes_ibfk_1` FOREIGN KEY (`TournamentId`) REFERENCES `tournaments` (`id`),
   CONSTRAINT `tournamentsprizes_ibfk_2` FOREIGN KEY (`PrizeId`) REFERENCES `prizes` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
