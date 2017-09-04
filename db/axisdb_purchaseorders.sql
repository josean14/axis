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
-- Table structure for table `purchaseorders`
--

DROP TABLE IF EXISTS `purchaseorders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchaseorders` (
  `PurchaseOrderId` int(11) NOT NULL AUTO_INCREMENT,
  `PO` varchar(45) DEFAULT NULL,
  `Commentary` varchar(200) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `File` varchar(200) DEFAULT NULL,
  `UserName` varchar(200) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Tooling` varchar(100) DEFAULT NULL,
  `SpecialtyItems` varchar(100) DEFAULT NULL,
  `AirportDestination` varchar(200) DEFAULT NULL,
  `DepartureDate` date DEFAULT NULL,
  `TravelPlans` text,
  `AirportCargoAddress` varchar(200) DEFAULT NULL,
  `AirportCargoContact` varchar(200) DEFAULT NULL,
  `LodgingInArea` varchar(200) DEFAULT NULL,
  `Notes` text,
  `ContractId` int(11) DEFAULT NULL,
  PRIMARY KEY (`PurchaseOrderId`),
  KEY `FContractId_idx` (`ContractId`),
  KEY `FUserId_idx` (`UserName`),
  CONSTRAINT `FContractId` FOREIGN KEY (`ContractId`) REFERENCES `contracts` (`ContractId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseorders`
--

LOCK TABLES `purchaseorders` WRITE;
/*!40000 ALTER TABLE `purchaseorders` DISABLE KEYS */;
INSERT INTO `purchaseorders` VALUES (4,'oc0050','comentario','2017-03-22','CAMBIO POR CONTINGENCIA.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,6),(7,'OC9090','Comentaio','2017-03-22','CAMBIO POR CONTINGENCIA.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,8),(8,'OC0043','Comentario PO OC0043','2017-05-20','206940_9EC5B6FF-3C8C-447A-952E-76503A92E322_1471454379272.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,6),(9,'POPRUEBA','Esta es una prueba','2017-08-17','7139 CENTRAL.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,13),(10,'POPRUEBA2','Esta es una prueba 2','2017-08-17','7139 CENTRAL.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,13),(11,'PO434','Prueba','2017-08-30','7139 CENTRAL.pdf',NULL,'OPEN','Tooling','Specialty Item','Airport Destination Merida','2017-10-31','1.- Este es el paso 1\r\n2.- Este es el paso 2\r\n3.- Este es el paso 3 que comprende el 1\r\n4.- Este es el paso 4\r\n5.- Prueba','Airport Cargo Address','Airport Cargo Contact','Lodging in Area','Esta es una nota corta',6),(12,'PO434Septiembre','Comentario','2017-09-03','7139 CENTRAL.pdf',NULL,'OPEN',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,7);
/*!40000 ALTER TABLE `purchaseorders` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-09-04  9:21:27
