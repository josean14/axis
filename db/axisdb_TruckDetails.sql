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
-- Table structure for table `truckdetails`
--

DROP TABLE IF EXISTS `truckdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `truckdetails` (
  `TruckId` int(11) NOT NULL AUTO_INCREMENT,
  `LicencePlate` varchar(45) DEFAULT NULL,
  `MakeModel` varchar(45) DEFAULT NULL,
  `SiteLocation` varchar(45) DEFAULT NULL,
  `VIN` varchar(45) DEFAULT NULL,
  `DateRent` date DEFAULT NULL,
  `Year` int(6) DEFAULT '0',
  `GasDiesel` varchar(45) DEFAULT NULL,
  `GasCard` varchar(45) DEFAULT NULL,
  `InsuranceDocumentacion` varchar(45) DEFAULT NULL,
  `ItemInterior1` varchar(45) DEFAULT NULL,
  `ItemInterior2` varchar(45) DEFAULT NULL,
  `ItemInterior3` varchar(45) DEFAULT NULL,
  `ItemInterior4` varchar(45) DEFAULT NULL,
  `ItemInterior5` varchar(45) DEFAULT NULL,
  `EngineComparment1` varchar(45) DEFAULT NULL,
  `EngineComparment2` varchar(45) DEFAULT NULL,
  `EngineComparment3` varchar(45) DEFAULT NULL,
  `EngineComparment4` varchar(45) DEFAULT NULL,
  `ItemExterior1` varchar(45) DEFAULT NULL,
  `ItemExterior2` varchar(45) DEFAULT NULL,
  `ItemExterior3` varchar(45) DEFAULT NULL,
  `ItemExterior4` varchar(45) DEFAULT NULL,
  `ItemExterior5` varchar(45) DEFAULT NULL,
  `ItemExterior6` varchar(45) DEFAULT NULL,
  `ItemExterior7` varchar(45) DEFAULT NULL,
  `ItemExterior8` varchar(45) DEFAULT NULL,
  `ItemExterior9` varchar(45) DEFAULT NULL,
  `ItemExterior10` varchar(45) DEFAULT NULL,
  `ItemExterior11` varchar(45) DEFAULT NULL,
  `ItemExterior12` varchar(45) DEFAULT NULL,
  `ItemExterior13` varchar(45) DEFAULT NULL,
  `ItemExterior14` varchar(45) DEFAULT NULL,
  `ItemExterior15` varchar(45) DEFAULT NULL,
  `ItemExterior16` varchar(45) DEFAULT NULL,
  `AditionalComments` varchar(200) DEFAULT NULL,
  `PurchaseOrderId` int(11) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`TruckId`),
  KEY `F_TRUK_idx` (`TruckId`,`PurchaseOrderId`),
  KEY `FTruck_idx` (`PurchaseOrderId`),
  CONSTRAINT `FTruck` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `trucks` (`PurchaseOrderId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truckdetails`
--

LOCK TABLES `truckdetails` WRITE;
/*!40000 ALTER TABLE `truckdetails` DISABLE KEYS */;
INSERT INTO `truckdetails` VALUES (1,'Prueba','Prueba','Prueba','Prueba','2017-09-30',2017,'YES','NO',NULL,NULL,'YES',NULL,NULL,NULL,'YES','YES',NULL,NULL,'NO',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'YES',NULL,'YES',NULL,'YES',NULL,NULL,'NO',NULL,11,'RENT'),(2,NULL,NULL,NULL,NULL,'0001-01-01',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,11,'PENDING RENT'),(3,NULL,NULL,NULL,NULL,'0001-01-01',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,11,'PENDING RENT'),(4,NULL,NULL,NULL,NULL,'0001-01-01',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,11,'PENDING RENT');
/*!40000 ALTER TABLE `truckdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-09-01 14:45:28
