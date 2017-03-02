-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: axisdb
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `ClientId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Department` varchar(45) DEFAULT NULL,
  `WorkPhone` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB AUTO_INCREMENT=1001 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1000,'Jose','Garcia','Director','Operacion','999-445-9978','jagr14@gmail.com','Conocida','Merida','Yucatan','+52','Mexico');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `farms`
--

DROP TABLE IF EXISTS `farms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `farms` (
  `FarmId` int(11) NOT NULL AUTO_INCREMENT,
  `TypeFarm` varchar(45) NOT NULL,
  `FarmName` varchar(45) NOT NULL,
  `StreetAddress` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Manufacture` varchar(45) DEFAULT NULL,
  `Platform` varchar(45) DEFAULT NULL,
  `Convertor` varchar(45) DEFAULT NULL,
  `NumberTowers` int(11) DEFAULT NULL,
  `NumberMws` int(11) DEFAULT NULL,
  `Gearbox` varchar(45) DEFAULT NULL,
  `ClientId` int(11) DEFAULT NULL,
  `Panel` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FarmId`),
  KEY `ClientId_idx` (`ClientId`),
  CONSTRAINT `ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`ClientId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1002 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farms`
--

LOCK TABLES `farms` WRITE;
/*!40000 ALTER TABLE `farms` DISABLE KEYS */;
INSERT INTO `farms` VALUES (1001,'0','Prueba 10','Conocida','Conocida','Conocida','Conocida','Mexico','Conocida','Conocida','Conocida',4,4,'Conocida',1000,NULL);
/*!40000 ALTER TABLE `farms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quotes`
--

DROP TABLE IF EXISTS `quotes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quotes` (
  `QouteId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(45) NOT NULL,
  `Um` varchar(45) NOT NULL,
  `PricePerUnit` double(11,3) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Currency` varchar(45) NOT NULL,
  `RversionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`QouteId`),
  UNIQUE KEY `Quantity_UNIQUE` (`Quantity`),
  KEY `RversionId_idx` (`RversionId`),
  CONSTRAINT `RversionId` FOREIGN KEY (`RversionId`) REFERENCES `rversions` (`RversionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quotes`
--

LOCK TABLES `quotes` WRITE;
/*!40000 ALTER TABLE `quotes` DISABLE KEYS */;
/*!40000 ALTER TABLE `quotes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rfqs`
--

DROP TABLE IF EXISTS `rfqs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rfqs` (
  `RfqId` int(11) NOT NULL AUTO_INCREMENT,
  `Status` varchar(45) NOT NULL,
  `ProjectName` varchar(45) DEFAULT NULL,
  `FarmId` int(11) DEFAULT NULL,
  PRIMARY KEY (`RfqId`),
  KEY `FarmId_idx` (`FarmId`),
  CONSTRAINT `FarmId` FOREIGN KEY (`FarmId`) REFERENCES `farms` (`FarmId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1004 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfqs`
--

LOCK TABLES `rfqs` WRITE;
/*!40000 ALTER TABLE `rfqs` DISABLE KEYS */;
INSERT INTO `rfqs` VALUES (1000,'Open','Prueba 16',1001),(1001,'Open','Proyecto prueba 3',1001),(1002,'Open','Prueba 20',1001);
/*!40000 ALTER TABLE `rfqs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rversions`
--

DROP TABLE IF EXISTS `rversions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rversions` (
  `RversionId` int(11) NOT NULL AUTO_INCREMENT,
  `RfqId` int(11) DEFAULT NULL,
  `NumberVersion` tinyint(2) unsigned DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `TypeWork` varchar(45) DEFAULT NULL,
  `ScopeWork` text,
  `ProjectDescription` text,
  `TotalCost` double(11,3) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `NotesAndInstructions` text,
  PRIMARY KEY (`RversionId`),
  KEY `Rfq_idx` (`RfqId`),
  CONSTRAINT `RfqId` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rversions`
--

LOCK TABLES `rversions` WRITE;
/*!40000 ALTER TABLE `rversions` DISABLE KEYS */;
INSERT INTO `rversions` VALUES (4,1000,0,'2017-03-01 11:53:02','0','Prueba','Prueba',0.000,'Open','3');
/*!40000 ALTER TABLE `rversions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
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

-- Dump completed on 2017-03-01 18:00:27
