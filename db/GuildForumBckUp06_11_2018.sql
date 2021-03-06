-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: guild_forum
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `article_comments`
--

DROP TABLE IF EXISTS `article_comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `article_comments` (
  `comment_id` int(6) NOT NULL AUTO_INCREMENT,
  `article_id` int(6) NOT NULL,
  `post_date` datetime NOT NULL,
  `user_id` int(6) NOT NULL,
  `content` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`comment_id`),
  KEY `user_id3_idx` (`user_id`),
  KEY `article_id_idx` (`article_id`),
  CONSTRAINT `article_id` FOREIGN KEY (`article_id`) REFERENCES `articles` (`article_id`) ON DELETE CASCADE,
  CONSTRAINT `user_id3` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `article_comments`
--

LOCK TABLES `article_comments` WRITE;
/*!40000 ALTER TABLE `article_comments` DISABLE KEYS */;
INSERT INTO `article_comments` VALUES (7,1,'2018-10-26 00:00:00',2,'Bardzo fajny artykuł i do tego wartościowy'),(8,1,'2018-10-26 00:00:00',2,'Bardzo fajny artykuł');
/*!40000 ALTER TABLE `article_comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `articles`
--

DROP TABLE IF EXISTS `articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `articles` (
  `article_id` int(6) NOT NULL AUTO_INCREMENT,
  `post_date` datetime NOT NULL,
  `user_id` int(6) NOT NULL,
  `title` varchar(510) COLLATE utf8_polish_ci NOT NULL,
  `content` varchar(2048) COLLATE utf8_polish_ci NOT NULL,
  `photo` mediumblob,
  PRIMARY KEY (`article_id`),
  KEY `user_id2_idx` (`user_id`),
  CONSTRAINT `user_id2` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articles`
--

LOCK TABLES `articles` WRITE;
/*!40000 ALTER TABLE `articles` DISABLE KEYS */;
INSERT INTO `articles` VALUES (1,'2018-10-26 00:00:00',1,'Postman Test','Postman new test',NULL);
/*!40000 ALTER TABLE `articles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` varchar(2048) DEFAULT NULL,
  `ClaimValue` varchar(2048) DEFAULT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoleID_idx` (`RoleId`),
  CONSTRAINT `RoleID` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  `ConcurrencyStamp` varchar(2024) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','Admin','J4LTOTZHZBHLFNKR4AAOJB6VCLBMJKNS','ADMIN'),('aaa386a1-193b-4bfe-a81f-12656c6cdd82','Tester','98e3e42c-8d57-4faa-99bb-8ca49f865e6e','TESTER');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` varchar(256) DEFAULT NULL,
  `ClaimValue` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserId` (`UserId`),
  CONSTRAINT `FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `IX_UserId` (`UserId`),
  CONSTRAINT `FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserId` (`UserId`),
  KEY `IX_RoleId` (`RoleId`),
  CONSTRAINT `FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('05996dbf-2800-464e-aabd-80773305fcbe','1'),('132cb1ab-af28-490d-bb02-3eff1ce02963','1'),('37fea826-c479-467f-af06-0f05fe0d08e5','1'),('6000b43b-7472-4549-b953-45d9db7d3a27','aaa386a1-193b-4bfe-a81f-12656c6cdd82'),('b7b93b9f-a0a5-49f6-b093-b47bb9624cca','aaa386a1-193b-4bfe-a81f-12656c6cdd82');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` varchar(256) DEFAULT NULL,
  `SecurityStamp` varchar(256) DEFAULT NULL,
  `PhoneNumber` varchar(256) DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  `ConcurrencyStamp` varchar(2024) DEFAULT NULL,
  `LockoutEnd` date DEFAULT NULL,
  `aspnetuserscol` varchar(45) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('05996dbf-2800-464e-aabd-80773305fcbe','Test3@verhardtest.com',_binary '\0','AQAAAAEAACcQAAAAEFisGIqS2ZKGdVz6g2NMQkPb+fiQm4mhPqxyMD1TSNoGQrNRWdhyscAnzGneMH4YmQ==','J4LTOTZHZBHLFNKR4AAOJB6VCLBMJKNS',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test3','abbf6252-cd48-41d4-8305-0e50e8867483',NULL,NULL,'TEST3@VERHARDTEST.COM','TEST3'),('132cb1ab-af28-490d-bb02-3eff1ce02963','test5@example.com',_binary '\0','AQAAAAEAACcQAAAAEJVCJ8zlx/h1H9h8Do5dOfUpHBPCELHrO1afVPJAPqec/RdEgz298SPXEXbiNfkZ+w==','N4IWYDDBZJBBD5J5XYD5YKNURZAQT5E2',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test6','46affd5f-1af9-44b9-844b-bcf92832aa7a',NULL,NULL,'TEST5@EXAMPLE.COM','TEST6'),('37fea826-c479-467f-af06-0f05fe0d08e5','Test5@verhardtest.com',_binary '\0','AQAAAAEAACcQAAAAEOSjOx0v7F8wHx1xpb2/nypKFQ+ApxPm49HAT6oZIP1T19KkwBr2m7JMwIf1xxgEfA==','5VT43WFOWEF2CULBONN2FIHHYCRPDZZA',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test5','a06c04ce-0b23-42df-9e02-9b4c076bce47',NULL,NULL,'TEST5@VERHARDTEST.COM','TEST5'),('6000b43b-7472-4549-b953-45d9db7d3a27','Test12@example.com',_binary '\0','AQAAAAEAACcQAAAAEGtOLxz1xHNVcpEkRVjabzX0LbmaLkIySfHSDCfGBrh5DS/57dl9cQcv2fpAsWhlCQ==','EG6U6KALI7YVVNNNHYWMN5ZOLXL3M6T6',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test12','1c6ac504-429a-431b-bc4a-046190f99e03',NULL,NULL,'TEST12@EXAMPLE.COM','TEST12'),('8240e71d-a959-4c66-acdf-d0581f170f05','Test2@verhardtest.com',_binary '\0','AQAAAAEAACcQAAAAEKCE7rxVj7bRvsd/IIbLdQvVFJl6R31q8PRK7l1kCBYuK7xH24QrhSEBTi7tekAB/A==','ZTR2OMUUXIENTYTNFVMCML3YAOGYVSHI',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test2','cb3b2a85-255d-4702-8608-acd99dfd7201',NULL,NULL,'TEST2@VERHARDTEST.COM','TEST2'),('b7b93b9f-a0a5-49f6-b093-b47bb9624cca','test7@example.com',_binary '\0','AQAAAAEAACcQAAAAEGy/CIGfP2voipecQdqF94gD1pnehrVetJsqdCu/K3FV+s1LkFmtJKhVQrM3xVg80Q==','H4SHUVZ3T76Z2PHSVGR5LF7DZDQBHLZ7',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test7','81fdd683-cf8a-42cc-b45a-183a7e9aecd1',NULL,NULL,'TEST7@EXAMPLE.COM','TEST7'),('d1064a96-16fb-470c-907d-b016134e5f75','Test4@verhardtest.com',_binary '\0','AQAAAAEAACcQAAAAEC9oCVxd74ATE932nyviMn9gcMjFct9Z4hVoQJE3MfLfjJU52v4EC8Of9709Kf3qtQ==','WEGJYY5IWGHRYXDDMQAGJX2E4CGF3UBJ',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Test4','7164cf21-8acd-4f97-a64c-16e4c3e77acc',NULL,NULL,'TEST4@VERHARDTEST.COM','TEST4'),('f8626aa4-3ffc-426f-b381-e3184007e2d7','contact@help.com',_binary '\0','AQAAAAEAACcQAAAAEA1KnIg03mPqIjnT68dR73RXF44yhjTGT6cwvnuB48GWmPqEzdW33K6kTj2OQbnCTg==','NIOIP4ETKVZBAIBZFFO5XOSI7ZQ43Y2G',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'angelsix','f57a5def-a3cb-49a7-acb4-8997606a83bb',NULL,NULL,'CONTACT@HELP.COM','ANGELSIX');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(128) COLLATE utf8_polish_ci NOT NULL,
  `LoginProvider` varchar(128) COLLATE utf8_polish_ci NOT NULL,
  `Name` varchar(128) COLLATE utf8_polish_ci NOT NULL,
  `Value` varchar(4048) COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_members`
--

DROP TABLE IF EXISTS `event_members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `event_members` (
  `event_id` int(6) NOT NULL,
  `user_id` int(6) NOT NULL,
  `standby` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`event_id`,`user_id`),
  KEY `event_id_idx` (`event_id`),
  KEY `user_id_idx` (`user_id`),
  CONSTRAINT `event_id` FOREIGN KEY (`event_id`) REFERENCES `events` (`event_id`),
  CONSTRAINT `user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_members`
--

LOCK TABLES `event_members` WRITE;
/*!40000 ALTER TABLE `event_members` DISABLE KEYS */;
INSERT INTO `event_members` VALUES (1,2,'Oczekiwanie'),(1,3,'Odrzucono');
/*!40000 ALTER TABLE `event_members` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `events`
--

DROP TABLE IF EXISTS `events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `events` (
  `event_id` int(6) NOT NULL AUTO_INCREMENT,
  `event_date` datetime NOT NULL,
  `event_name` varchar(120) COLLATE utf8_polish_ci NOT NULL,
  `event_description` varchar(45) COLLATE utf8_polish_ci DEFAULT NULL,
  `user_id` int(6) NOT NULL,
  PRIMARY KEY (`event_id`),
  KEY `user_id4_idx` (`user_id`),
  CONSTRAINT `user_id4` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events`
--

LOCK TABLES `events` WRITE;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` VALUES (1,'2018-10-26 00:00:00','Wyprawa po złoto','Idziemy po złoto, bo potrzebujemy go bardzo',1);
/*!40000 ALTER TABLE `events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `groups` (
  `group_id` int(6) NOT NULL AUTO_INCREMENT,
  `group_name` varchar(45) NOT NULL,
  PRIMARY KEY (`group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (1,'Brak'),(2,'Babola'),(3,'Fomodia');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `user_id` int(6) NOT NULL AUTO_INCREMENT,
  `identity_id` varchar(128) NOT NULL,
  `group_id` int(6) NOT NULL DEFAULT '1',
  `nick` varchar(64) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `registration_date` datetime NOT NULL,
  `avatar` mediumblob,
  `numbers_of_posts` int(6) DEFAULT NULL,
  `ban` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `identity_id_idx` (`identity_id`),
  KEY `group_id_idx` (`group_id`),
  CONSTRAINT `group_id` FOREIGN KEY (`group_id`) REFERENCES `groups` (`group_id`),
  CONSTRAINT `identity_id` FOREIGN KEY (`identity_id`) REFERENCES `aspnetusers` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'05996dbf-2800-464e-aabd-80773305fcbe',3,'Test3','2018-09-26 11:15:33','',0,0),(2,'d1064a96-16fb-470c-907d-b016134e5f75',1,'Test4','2018-09-26 11:25:25',NULL,0,0),(3,'37fea826-c479-467f-af06-0f05fe0d08e5',2,'Test5','2018-09-26 11:25:53',NULL,0,0),(4,'6000b43b-7472-4549-b953-45d9db7d3a27',1,'Test12','2018-09-26 12:35:01',NULL,0,0),(5,'132cb1ab-af28-490d-bb02-3eff1ce02963',1,'Test6','2018-10-29 09:23:04',NULL,0,0),(6,'b7b93b9f-a0a5-49f6-b093-b47bb9624cca',1,'Test7','2018-11-05 12:20:24',NULL,0,0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-06 15:06:19
