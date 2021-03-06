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
-- Table structure for table `contracts`
--

DROP TABLE IF EXISTS `contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contracts` (
  `ContractId` int(11) NOT NULL AUTO_INCREMENT,
  `OcClient` varchar(100) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `File` varchar(150) DEFAULT NULL,
  `RfqId` int(11) DEFAULT NULL,
  `RversionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ContractId`),
  KEY `Ffqid_contracts_idx` (`RfqId`),
  KEY `RversionId_contracts_idx` (`RversionId`),
  CONSTRAINT `RfqId_contracts` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `RversionId_contracts` FOREIGN KEY (`RversionId`) REFERENCES `rversions` (`RversionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contracts`
--

LOCK TABLES `contracts` WRITE;
/*!40000 ALTER TABLE `contracts` DISABLE KEYS */;
INSERT INTO `contracts` VALUES (6,NULL,'2017-03-20','CAMBIO POR CONTINGENCIA.pdf',1047,69),(7,NULL,'2017-03-20','CAMBIO POR CONTINGENCIA.pdf',1047,70),(8,NULL,'2017-03-20','CAMBIO POR CONTINGENCIA.pdf',1048,37),(9,NULL,'2017-03-20','CAMBIO POR CONTINGENCIA.pdf',1049,45),(10,NULL,'2017-03-21','CAMBIO POR CONTINGENCIA.pdf',1050,95);
/*!40000 ALTER TABLE `contracts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-21  8:41:36
