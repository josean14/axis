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
-- Table structure for table `teches`
--

DROP TABLE IF EXISTS `teches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teches` (
  `TechId` int(11) NOT NULL AUTO_INCREMENT,
  `Photo` varchar(100) DEFAULT NULL,
  `FirstName` varchar(80) DEFAULT NULL,
  `LastName` varchar(80) DEFAULT NULL,
  `Language` varchar(80) DEFAULT NULL,
  `StreetAdderess` varchar(200) DEFAULT NULL,
  `CityAdderess` varchar(100) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `Zip` varchar(45) DEFAULT NULL,
  `Country` varchar(80) DEFAULT NULL,
  `Cell` varchar(45) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `LocalAirport` varchar(100) DEFAULT NULL,
  `SSN` int(11) DEFAULT NULL,
  `DriveLicence` varchar(100) DEFAULT NULL,
  `PayRate` double(6,3) DEFAULT NULL,
  `TypePayRate` varchar(45) DEFAULT NULL,
  `Medical` varchar(100) DEFAULT NULL,
  `Passport` int(11) DEFAULT NULL,
  `MaritalStatus` varchar(45) DEFAULT NULL,
  `Children` int(11) DEFAULT NULL,
  `Education` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`TechId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teches`
--

LOCK TABLES `teches` WRITE;
/*!40000 ALTER TABLE `teches` DISABLE KEYS */;
INSERT INTO `teches` VALUES (11,NULL,'Jose ','Garcia','Español','Conocido','Conocido','Yucatan','97314','Mexico','999-999-9999','joseantonio@axis.com','Merida',909090909,'900999j09',890.000,'1','99090990',90999,'0',2,'Maestria'),(12,NULL,'Angel','Lavalle','Español','Otro','Otro','Otro','Otro','Otro','999-999-9999','joseantonio@axis.com','otro',89898989,'yyy9898',890.000,'0','898989jj',90909099,'0',8,'otro');
/*!40000 ALTER TABLE `teches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `techinfoaxis`
--

DROP TABLE IF EXISTS `techinfoaxis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `techinfoaxis` (
  `TechInfoAxiId` int(11) NOT NULL AUTO_INCREMENT,
  `ExperienceDate` datetime DEFAULT NULL,
  `Osha10` varchar(100) DEFAULT NULL,
  `FirstAidCPR` varchar(100) DEFAULT NULL,
  `TowerRescue` varchar(100) DEFAULT NULL,
  `ConfinedSpace` varchar(100) DEFAULT NULL,
  `Nfra70E` varchar(100) DEFAULT NULL,
  `Loto` varchar(100) DEFAULT NULL,
  `Ergonomics` varchar(100) DEFAULT NULL,
  `Hazcom` varchar(100) DEFAULT NULL,
  `CraneSafety` varchar(100) DEFAULT NULL,
  `RiggingSignalMan` varchar(100) DEFAULT NULL,
  `FireExtinguisher` varchar(100) DEFAULT NULL,
  `HasI9` tinyint(1) DEFAULT NULL,
  `I9File` varchar(100) DEFAULT NULL,
  `HasW2` tinyint(1) DEFAULT NULL,
  `W2File` varchar(100) DEFAULT NULL,
  `HasW4` tinyint(1) DEFAULT NULL,
  `W4File` varchar(100) DEFAULT NULL,
  `HasApplicanceOffer` tinyint(1) DEFAULT NULL,
  `ApplicanceOfferFile` varchar(100) DEFAULT NULL,
  `HasAxisLaborCode` tinyint(1) DEFAULT NULL,
  `AxisLaborCodeFile` varchar(100) DEFAULT NULL,
  `TechnicalLevel` varchar(45) DEFAULT NULL,
  `TechId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TechInfoAxiId`),
  KEY `ATechId_idx` (`TechId`),
  CONSTRAINT `ATechId` FOREIGN KEY (`TechId`) REFERENCES `teches` (`TechId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfoaxis`
--

LOCK TABLES `techinfoaxis` WRITE;
/*!40000 ALTER TABLE `techinfoaxis` DISABLE KEYS */;
INSERT INTO `techinfoaxis` VALUES (9,'2014-11-02 00:00:00','IMG_4335.JPG',NULL,NULL,NULL,'IMG_4328.JPG',NULL,'IMG_4331.JPG',NULL,'IMG_4336.JPG','IMG_4339.JPG',NULL,1,'IMG_4352.JPG',1,'IMG_4336.JPG',1,'IMG_4337.JPG',0,NULL,1,'IMG_4356.JPG','1',11),(10,'2014-06-18 00:00:00','IMG_4327.JPG',NULL,NULL,NULL,'IMG_4337.JPG',NULL,NULL,NULL,NULL,NULL,NULL,1,'IMG_4340.JPG',0,NULL,0,NULL,1,'IMG_4355.JPG',0,NULL,'0',12);
/*!40000 ALTER TABLE `techinfoaxis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `techinfocims`
--

DROP TABLE IF EXISTS `techinfocims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `techinfocims` (
  `TechInfoCimId` int(11) NOT NULL AUTO_INCREMENT,
  `Computer` varchar(100) DEFAULT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `Camera` varchar(100) DEFAULT NULL,
  `TechId` int(11) DEFAULT NULL,
  `Other` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`TechInfoCimId`),
  KEY `CTechId_idx` (`TechId`),
  CONSTRAINT `CTechId` FOREIGN KEY (`TechId`) REFERENCES `teches` (`TechId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfocims`
--

LOCK TABLES `techinfocims` WRITE;
/*!40000 ALTER TABLE `techinfocims` DISABLE KEYS */;
INSERT INTO `techinfocims` VALUES (1,'009090909','iphone','camar',11,'other'),(2,'878778','787878','787878',12,'787878');
/*!40000 ALTER TABLE `techinfocims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `techinfokits`
--

DROP TABLE IF EXISTS `techinfokits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `techinfokits` (
  `TechInfoKitId` int(11) NOT NULL AUTO_INCREMENT,
  `HarnessManufacter` varchar(100) DEFAULT NULL,
  `HarnessModel` varchar(45) DEFAULT NULL,
  `HarnessSerial` varchar(45) DEFAULT NULL,
  `HarnessDateManufacture` datetime DEFAULT NULL,
  `HarnessRecertification` varchar(100) DEFAULT NULL,
  `LaynarManufacter` varchar(100) DEFAULT NULL,
  `LaynarModel` varchar(100) DEFAULT NULL,
  `LaynarSerial` varchar(45) DEFAULT NULL,
  `LaynarDateManufacture` datetime DEFAULT NULL,
  `LaynarRecertification` varchar(100) DEFAULT NULL,
  `CableGrab` varchar(100) DEFAULT NULL,
  `Helment` varchar(100) DEFAULT NULL,
  `Uniforms` varchar(100) DEFAULT NULL,
  `Other` varchar(100) DEFAULT NULL,
  `TechId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TechInfoKitId`),
  KEY `KTechId_idx` (`TechId`),
  CONSTRAINT `KTechId` FOREIGN KEY (`TechId`) REFERENCES `teches` (`TechId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfokits`
--

LOCK TABLES `techinfokits` WRITE;
/*!40000 ALTER TABLE `techinfokits` DISABLE KEYS */;
INSERT INTO `techinfokits` VALUES (2,'Prueba','Prueba','Prueba','2010-06-24 00:00:00','Prueba2','Prueba2','Prueba','Prueba','2016-06-16 00:00:00','Prueba3','Prueba23','Prueba23','Prueba23','Prueba3',11),(3,'otro','otro','otro','2014-07-23 00:00:00','9989','98','98','98989','2014-07-30 00:00:00','88989','9889','898998','98989','8989',12);
/*!40000 ALTER TABLE `techinfokits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `techinfoworks`
--

DROP TABLE IF EXISTS `techinfoworks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `techinfoworks` (
  `TechInfoWorkId` int(11) NOT NULL AUTO_INCREMENT,
  `TypeOfService` varchar(45) DEFAULT NULL,
  `ManufacturerName` varchar(45) DEFAULT NULL,
  `PlatformName` varchar(100) DEFAULT NULL,
  `FarmId` int(11) DEFAULT NULL,
  `Notes` text,
  `ScopeWorkId` int(11) DEFAULT NULL,
  `TechId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TechInfoWorkId`),
  KEY `ScopeWorkId_idx` (`ScopeWorkId`),
  KEY `TechId_idx` (`TechId`),
  KEY `FFarmId_idx` (`FarmId`),
  CONSTRAINT `FFarmId` FOREIGN KEY (`FarmId`) REFERENCES `farms` (`FarmId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FScopeWorkId` FOREIGN KEY (`ScopeWorkId`) REFERENCES `scopeworks` (`ScopeWorkId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FTechId` FOREIGN KEY (`TechId`) REFERENCES `teches` (`TechId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfoworks`
--

LOCK TABLES `techinfoworks` WRITE;
/*!40000 ALTER TABLE `techinfoworks` DISABLE KEYS */;
/*!40000 ALTER TABLE `techinfoworks` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-30 14:44:14
