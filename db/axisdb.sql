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
-- Table structure for table `ccalls`
--

DROP TABLE IF EXISTS `ccalls`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ccalls` (
  `CcallId` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date DEFAULT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Note` text,
  `UserName` varchar(45) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `ClientId` int(11) DEFAULT NULL,
  PRIMARY KEY (`CcallId`),
  KEY `ClientId_idx` (`ClientId`),
  CONSTRAINT `FClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`ClientId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ccalls`
--

LOCK TABLES `ccalls` WRITE;
/*!40000 ALTER TABLE `ccalls` DISABLE KEYS */;
INSERT INTO `ccalls` VALUES (1,'2017-03-22','Prueba','Prueba','jose',NULL,1000),(2,'2017-03-15','eeee','eee','eeee',NULL,1001),(3,'2017-03-14','Prueba 34','eeee','eee',NULL,1001),(4,'2017-03-14','Prueba 34','eeee','eee',NULL,1001),(5,'2017-03-21','eeee','eee','eee',NULL,1001),(6,'2017-03-21','eee','eee','eee',NULL,1001),(7,'2017-03-21','eeee','eee','eee',NULL,1001),(8,'2017-03-14','Prueba nota','nota','nota',NULL,1000),(9,'2017-03-14','Prueba 55','Vista','Angel',NULL,1001);
/*!40000 ALTER TABLE `ccalls` ENABLE KEYS */;
UNLOCK TABLES;

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
  `Company` varchar(45) DEFAULT NULL,
  `Region` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB AUTO_INCREMENT=1002 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1000,'Jose','Garcia','Director','Operacion','999-445-9978','jagr14@gmail.com','Conocida','Merida','Yucatan','+52','Mexico','Xtx','Sur'),(1001,'Angel','Lavelle','Gerente','Operacion','999-999-6666','eduardo@eduardo.com','Conocida','Merida','Yucatan','64134','Mexico','Cmx','Centro');
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
) ENGINE=InnoDB AUTO_INCREMENT=1004 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farms`
--

LOCK TABLES `farms` WRITE;
/*!40000 ALTER TABLE `farms` DISABLE KEYS */;
INSERT INTO `farms` VALUES (1001,'0','Prueba 10','Conocida','Conocida','Conocida','Conocida','Mexico','Conocida','Conocida','Conocida',4,4,'Conocida',1000,NULL),(1002,'1','Solar Farm','Conocis','cono','cono','ojoj','como','como','como','comco',3,3,'como',1000,NULL),(1003,'2','Other Farm','lklk','lklkl','lklk','lk','lklk','kl','lk','lk',8,8,'ljlj',1000,NULL);
/*!40000 ALTER TABLE `farms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quotes`
--

DROP TABLE IF EXISTS `quotes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quotes` (
  `QuoteId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(45) DEFAULT NULL,
  `Um` varchar(45) DEFAULT NULL,
  `PricePerUnit` double(11,4) DEFAULT NULL,
  `Quantity` double(11,4) DEFAULT NULL,
  `Currency` double(11,4) DEFAULT NULL,
  `RversionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuoteId`),
  KEY `RversionId_idx` (`RversionId`),
  CONSTRAINT `RversionId` FOREIGN KEY (`RversionId`) REFERENCES `rversions` (`RversionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
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
) ENGINE=InnoDB AUTO_INCREMENT=1032 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfqs`
--

LOCK TABLES `rfqs` WRITE;
/*!40000 ALTER TABLE `rfqs` DISABLE KEYS */;
INSERT INTO `rfqs` VALUES (1028,'Open','Prueba 56',1001),(1029,'Open','Prueba 98',1001),(1030,'Open','Prueba 100',1001),(1031,'Open','Prueba 99',1001);
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
  `ProjectDescription` text,
  `TotalCost` double(11,3) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `NotesAndInstructions` text,
  `ScopeWorkId` int(11) DEFAULT NULL,
  PRIMARY KEY (`RversionId`),
  KEY `Rfq_idx` (`RfqId`),
  KEY `ScopeWorkId_idx` (`ScopeWorkId`),
  CONSTRAINT `RfqId` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ScopeWorkId` FOREIGN KEY (`ScopeWorkId`) REFERENCES `scopeworks` (`ScopeWorkId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rversions`
--

LOCK TABLES `rversions` WRITE;
/*!40000 ALTER TABLE `rversions` DISABLE KEYS */;
INSERT INTO `rversions` VALUES (25,1029,1,'0001-01-01 00:00:00','1','Nombre',0.000,'Open','PRueba 55',20),(26,1030,1,'2017-03-11 22:57:26','0','Descripcion de proyecto',0.000,'Open','Prueba de servicios',1),(27,1031,1,'2017-03-11 23:03:11','1','Prueba ',0.000,'Open','Prueba',16);
/*!40000 ALTER TABLE `rversions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scopeworks`
--

DROP TABLE IF EXISTS `scopeworks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scopeworks` (
  `ScopeWorkId` int(11) NOT NULL AUTO_INCREMENT,
  `TypeWork` varchar(45) DEFAULT NULL,
  `Work` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ScopeWorkId`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scopeworks`
--

LOCK TABLES `scopeworks` WRITE;
/*!40000 ALTER TABLE `scopeworks` DISABLE KEYS */;
INSERT INTO `scopeworks` VALUES (1,'SERVICES','SERVICES: OEM SUPPORT'),(2,'SERVICES','SERVICES: LARGE CORRECTIVE CONVERTER'),(3,'SERVICES','SERVICES: LARGE CORRECTIVE GEARBOX'),(4,'SERVICES','SERVICES: LARGE CORRECTIVE GENERATOR'),(5,'SERVICES','SERVICES: LARGE CORRECTIVE TRANSFORMER'),(6,'SERVICES','SERVICES: LARGE CORRECTIVE OPEN'),(7,'SERVICES','SERVICES: PREVENTIVE MAINTENANCE 3 MONTH'),(8,'SERVICES','SERVICES: PREVENTIVE MAINTENANCE 6 MONTH'),(9,'SERVICES','SERVICES: PREVENTIVE MAINTENANCE 12 MONTH'),(10,'SERVICES','SERVICES: PREVENTIVE MAINTENANCE TRANSFORMER'),(11,'SERVICES','SERVICES: PREVENTIVE MAINTENANCE OPEN'),(12,'SERVICES','SERVICES:DESIGN MODIFICATION'),(13,'SERVICES','SERVICES:INSPECTION'),(14,'SERVICES','SERVICES:OPEN'),(15,'CONSTRUCT','CONSTRUCT:TECHNICAL ADVISORS'),(16,'CONSTRUCT','CONSTRUCT: QA / QC'),(17,'CONSTRUCT','CONSTRUCT:  BLADE'),(18,'CONSTRUCT','CONSTRUCT:  NCR'),(19,'CONSTRUCT','CONSTRUCT: LOGISTICS'),(20,'CONSTRUCT','CONSTRUCT: COMMISION'),(21,'CONSTRUCT','CONSTRUCT: OPEN');
/*!40000 ALTER TABLE `scopeworks` ENABLE KEYS */;
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

-- Dump completed on 2017-03-11 23:07:19
