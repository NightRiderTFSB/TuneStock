-- MySQL dump 10.13  Distrib 8.0.36, for Linux (x86_64)
--
-- Host: localhost    Database: TuneStock
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Labels`
--

DROP TABLE IF EXISTS `Labels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Labels` (
  `LabelID` int NOT NULL AUTO_INCREMENT,
  `Labelname` varchar(50) NOT NULL,
  `Description` varchar(100) NOT NULL,
  `IsDeleted` tinyint(1) DEFAULT '0',
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) NOT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`LabelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Labels`
--

LOCK TABLES `Labels` WRITE;
/*!40000 ALTER TABLE `Labels` DISABLE KEYS */;
/*!40000 ALTER TABLE `Labels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sound`
--

DROP TABLE IF EXISTS `Sound`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Sound` (
  `SoundID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `SoundName` varchar(50) NOT NULL,
  `File` varchar(100) NOT NULL,
  `IsPremiun` tinyint(1) DEFAULT '0',
  `Price` double NOT NULL,
  `IsDeleted` tinyint(1) DEFAULT '0',
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) NOT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SoundID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sound`
--

LOCK TABLES `Sound` WRITE;
/*!40000 ALTER TABLE `Sound` DISABLE KEYS */;
/*!40000 ALTER TABLE `Sound` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SoundsLabels`
--

DROP TABLE IF EXISTS `SoundsLabels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SoundsLabels` (
  `SoundID_FK` int NOT NULL,
  `LabelID_FK` int NOT NULL,
  KEY `LabelID_FK_SoundsLabels` (`LabelID_FK`),
  KEY `SoundID_FK_SoundsLabels` (`SoundID_FK`),
  CONSTRAINT `LabelID_FK_SoundsLabels` FOREIGN KEY (`LabelID_FK`) REFERENCES `Labels` (`LabelID`),
  CONSTRAINT `SoundID_FK_SoundsLabels` FOREIGN KEY (`SoundID_FK`) REFERENCES `Sound` (`SoundID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SoundsLabels`
--

LOCK TABLES `SoundsLabels` WRITE;
/*!40000 ALTER TABLE `SoundsLabels` DISABLE KEYS */;
/*!40000 ALTER TABLE `SoundsLabels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `User` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) NOT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `User`
--

LOCK TABLES `User` WRITE;
/*!40000 ALTER TABLE `User` DISABLE KEYS */;
/*!40000 ALTER TABLE `User` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserDownloads`
--

DROP TABLE IF EXISTS `UserDownloads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserDownloads` (
  `DownloadID` int NOT NULL AUTO_INCREMENT,
  `SoundID_FK` int NOT NULL,
  `UserID_FK` int NOT NULL,
  `DownloadedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`DownloadID`),
  KEY `UserID_FK_UserDownloads` (`UserID_FK`),
  KEY `SoundID_FK_UserDownloads` (`SoundID_FK`),
  CONSTRAINT `SoundID_FK_UserDownloads` FOREIGN KEY (`SoundID_FK`) REFERENCES `Sound` (`SoundID`),
  CONSTRAINT `UserID_FK_UserDownloads` FOREIGN KEY (`UserID_FK`) REFERENCES `User` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserDownloads`
--

LOCK TABLES `UserDownloads` WRITE;
/*!40000 ALTER TABLE `UserDownloads` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserDownloads` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserPurchases`
--

DROP TABLE IF EXISTS `UserPurchases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserPurchases` (
  `PurchaseID` int NOT NULL AUTO_INCREMENT,
  `PurchasedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `SoundPrice` double NOT NULL,
  `PaymentStatus` tinyint(1) DEFAULT '0',
  `PaymentMethod` varchar(20) NOT NULL,
  `UserID_FK` int NOT NULL,
  `SoundID_FK` int NOT NULL,
  `IsDeleted` tinyint(1) DEFAULT '0',
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedBy` varchar(50) NOT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PurchaseID`),
  KEY `UserID_FK_UserPurchases` (`UserID_FK`),
  KEY `SoundID_FK_UserPurchases` (`SoundID_FK`),
  CONSTRAINT `SoundID_FK_UserPurchases` FOREIGN KEY (`SoundID_FK`) REFERENCES `Sound` (`SoundID`),
  CONSTRAINT `UserID_FK_UserPurchases` FOREIGN KEY (`UserID_FK`) REFERENCES `User` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserPurchases`
--

LOCK TABLES `UserPurchases` WRITE;
/*!40000 ALTER TABLE `UserPurchases` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserPurchases` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`starboy`@`localhost`*/ /*!50003 TRIGGER `TRG_INSERT_UserPurchases` AFTER INSERT ON `UserPurchases` FOR EACH ROW BEGIN
    INSERT INTO UserSoundStock (UserID_FK, SoundID_FK)
    VALUES (NEW.UserID_FK, NEW.SoundID_FK);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `UserSoundStock`
--

DROP TABLE IF EXISTS `UserSoundStock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserSoundStock` (
  `UserID_FK` int NOT NULL,
  `SoundID_FK` int NOT NULL,
  KEY `UserID_FK_UserSoundStock` (`UserID_FK`),
  KEY `SoundID_FK_UserSoundStock` (`SoundID_FK`),
  CONSTRAINT `SoundID_FK_UserSoundStock` FOREIGN KEY (`SoundID_FK`) REFERENCES `Sound` (`SoundID`),
  CONSTRAINT `UserID_FK_UserSoundStock` FOREIGN KEY (`UserID_FK`) REFERENCES `User` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserSoundStock`
--

LOCK TABLES `UserSoundStock` WRITE;
/*!40000 ALTER TABLE `UserSoundStock` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserSoundStock` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-17 10:16:21
