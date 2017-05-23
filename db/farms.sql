-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: axisdb
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
-- Table structure for table `farms`
--

DROP TABLE IF EXISTS `farms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `farms` (
  `FarmId` int(11) NOT NULL AUTO_INCREMENT,
  `TypeFarm` varchar(45) NOT NULL,
  `FarmName` varchar(45) NOT NULL,
  `StreetAddress` varchar(200) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Manufacture` varchar(45) DEFAULT NULL,
  `Platform` varchar(45) DEFAULT NULL,
  `Convertor` varchar(45) DEFAULT NULL,
  `NumberTowers` int(11) DEFAULT NULL,
  `NumberMws` double(4,3) DEFAULT NULL,
  `Gearbox` varchar(45) DEFAULT NULL,
  `ClientId` int(11) DEFAULT NULL,
  `Panel` varchar(45) DEFAULT NULL,
  `GeoLong` float DEFAULT NULL,
  `GeoLat` float DEFAULT NULL,
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
INSERT INTO `farms` VALUES (1001,'0','Ventosa','Conocida','Conocida','Conocida','Conocida','Mexico','Conocida','Conocida','Conocida',4,4.500,'Conocida',1000,NULL,16.5728,-94.8409),(1002,'1','Solar Farm','Merida','Merida','cono','ojoj','Mexico','como','como','comco',3,3.000,'como',1000,NULL,32.7671,-117.139),(1003,'0','CFE CANCUN','Carr. Chetumal - Puerto Juarez','Tolum','QRooo','97000','Mexico','XX','YY','ZZ',1,5.500,'SSSs',1001,NULL,20.9749,-86.8646);
/*!40000 ALTER TABLE `farms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-23 10:38:41
