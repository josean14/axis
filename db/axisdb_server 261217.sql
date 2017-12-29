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
-- Table structure for table `assignmentoftools`
--

DROP TABLE IF EXISTS `assignmentoftools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `assignmentoftools` (
  `PurchaseOrderId` int(11) NOT NULL,
  `SuppliedBy` varchar(50) DEFAULT NULL,
  `AditionalInfo` varchar(300) DEFAULT NULL,
  `OrderNumber` varchar(45) DEFAULT NULL,
  `Cost` double DEFAULT NULL,
  `FileT` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`PurchaseOrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignmentoftools`
--

LOCK TABLES `assignmentoftools` WRITE;
/*!40000 ALTER TABLE `assignmentoftools` DISABLE KEYS */;
/*!40000 ALTER TABLE `assignmentoftools` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assignmentoftoolsbyjobs`
--

DROP TABLE IF EXISTS `assignmentoftoolsbyjobs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `assignmentoftoolsbyjobs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Manufacturer` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Serial1` varchar(45) DEFAULT NULL,
  `Serial2` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `CDMD` date DEFAULT NULL,
  `Additional1` varchar(45) DEFAULT NULL,
  `Additional2` varchar(45) DEFAULT NULL,
  `Location` varchar(45) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `ContractId` int(11) DEFAULT '0',
  `CheckJob` enum('true','false') DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignmentoftoolsbyjobs`
--

LOCK TABLES `assignmentoftoolsbyjobs` WRITE;
/*!40000 ALTER TABLE `assignmentoftoolsbyjobs` DISABLE KEYS */;
INSERT INTO `assignmentoftoolsbyjobs` VALUES (1,'AMPROBE','TIC 300 PRO','150500133',NULL,'NA','2017-08-19',NULL,NULL,'WAREHOUSE','TIC TRACER',0,'false'),(2,'AMPROBE','TIC 300 PRO','150300102','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(3,'AMPROBE','TIC 300 PRO','150501154','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(4,'AMPROBE','TIC 300 PRO','150700227','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(5,'AMPROBE','TIC 300 PRO','150600296','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(6,'AMPROBE','TIC 300 PRO','150700411','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(7,'AMPROBE','TIC 300 PRO','150500502','NA','GOOD','2017-08-23','NA','NA','WAREHOUSE','TIC TRACER',0,'false'),(8,'STAHLWILLE','MANOSKOP 730','615236586','NA','GOOD','2017-08-18','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(9,'STAHLWILLE','MANOSKOP 730','615236576','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(10,'STAHLWILLE','MANOSKOP 730','615236578','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(11,'STAHLWILLE','MANOSKOP 730','207198009','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(12,'STAHLWILLE','MANOSKOP 730','615270509','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(13,'STAHLWILLE','MANOSKOP 730 N','615236540','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(14,'STAHLWILLE','MANOSKOP 730','615236583','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(15,'STAHLWILLE','MANOSKOP 730','615236585','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(16,'FACOM','S306-350D','CY0718','NA','NA','2017-07-15','NA','NA','WAREHOUSE','TORQUE WRENCH',0,'false'),(17,'WREN','ML8024','S4/N73186','NA','NA','2017-08-01','NA','NA','WAREHOUSE','TORQUE PUMP',0,'false'),(18,'HASTINGS','8206','160247','NA','NA','2017-05-01','NA','NA','WAREHOUSE','HOT STICK',0,'false'),(19,'HASTINGS','8105','NA','NA','NA','2017-07-15','NA','NA','WAREHOUSE','HOT STICK',0,'false'),(20,'HASTINGS','4009','NA','NA','NA','2017-07-15','NA','NA','WAREHOUSE','HOT STICK',0,'false'),(21,'HASTINGS','8108','NA','NA','NA','2017-07-15','NA','NA','WAREHOUSE','HOT STICK',0,'false'),(22,'BRADY','LOCK BOX','LB-001','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(23,'BRADY','LOCK BOX','LB-002','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(24,'BRADY','LOCK BOX','LB-003','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(25,'BRADY','LOCK BOX','LB-004','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(26,'BRADY','LOCK BOX','LB-005','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(27,'BRADY','LOCK BOX','LB-006','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(28,'BRADY','LOCK BOX','LB-007','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(29,'BRADY','LOCK BOX','LB-008','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(30,'BRADY','LOCK BOX','LB-009','NA','NA','2017-07-15','NA','NA','WAREHOUSE','LOTO BOX',0,'false'),(31,'SALISBURY','FH40GY','40 CAL-900','11520','GOOD','2016-12-13',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(32,'SALISBURY','FH40PLT','40 CAL-002','286858','GOOD','2016-08-12',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(33,'SALISBURY','FH40PLT','40 CAL-001','295146','GOOD','2017-01-26',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(34,'SALISBURY','FH40GY','40 CAL-901','11871','GOOD','2016-08-12',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(35,'SALISBURY','FH40PLT','40 CAL-902','291990','NO FACE SHIELD','2000-01-01',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(36,'SALISBURY','FH40PLT','40 CAL-004','294399','GOOD','2016-08-12',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false'),(37,'SALISBURY','NONE','NONE','NONE','NONE','2000-01-01',NULL,NULL,'WAREHOUSE','40 CAL SUIT',0,'false');
/*!40000 ALTER TABLE `assignmentoftoolsbyjobs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assignmentoftoolsbytrucks`
--

DROP TABLE IF EXISTS `assignmentoftoolsbytrucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `assignmentoftoolsbytrucks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Manufacturer` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Serial1` varchar(45) DEFAULT NULL,
  `Serial2` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `CDMD` date DEFAULT NULL,
  `Additional1` varchar(45) DEFAULT NULL,
  `Additional2` varchar(45) DEFAULT NULL,
  `Location` varchar(45) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `TruckId` int(11) DEFAULT '0',
  `CheckTruck` enum('false','true') DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignmentoftoolsbytrucks`
--

LOCK TABLES `assignmentoftoolsbytrucks` WRITE;
/*!40000 ALTER TABLE `assignmentoftoolsbytrucks` DISABLE KEYS */;
INSERT INTO `assignmentoftoolsbytrucks` VALUES (1,'SKYLOTEC','MILAN 2.0 HUB','310560-014',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(2,'SKYLOTEC','MILAN 2.0 HUB','7017400',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(3,'SKYLOTEC','MILAN 2.0 HUB','310560027',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(4,'SKYLOTEC','MILAN 2.0 HUB','ARK-601',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(5,'SKYLOTEC','MILAN 2.0 HUB','ARK-002',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(6,'SKYLOTEC','MILAN 2.0 HUB','7017411',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(7,'SKYLOTEC','MILAN 2.0 HUB','7017410',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(8,'SKYLOTEC','MILAN 2.0 HUB','7017413',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(9,'SKYLOTEC','MILAN 2.0 HUB','309937-002',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(10,'SKYLOTEC','MILAN 2.0 HUB','ARK-810',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(11,'SKYLOTEC','MILAN 2.0 HUB','ARK-811',NULL,'NA','2017-08-23',NULL,NULL,'WAREHOUSE','RESCUE KIT',0,'false'),(12,'AXIS','NA','ATK-200','3303087','GOOD','2017-07-15','NO COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(13,'AXIS','NA','ATK-117','35050264WS','GOOD','2017-07-15','NO COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(14,'AXIS','NA','ATK-121','33360274','GOOD','2017-07-15','NO COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(15,'AXIS','NA','ATK-155','32950011WS','GOOD','2017-07-15','NO COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(16,'AXIS','NA','ATK-171','33510139','GOOD','2018-01-31','COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(17,'AXIS','NA','ATK-002','32910212','GOOD','2017-03-07','COMPLETE',NULL,'WAREHOUSE','TOOL KIT',0,'false'),(18,'SALISBURY','CLASS 0','7924135',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(19,'SALISBURY','CLASS 0','8383431',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(20,'SALISBURY','CLASS 0','C0S10B40151',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(21,'SALISBURY','CLASS 0','9364239',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(22,'SALISBURY','CLASS 0','C0S10B40151',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(23,'SALISBURY','CLASS 0','101716',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(24,'SALISBURY','CLASS 0','8100271',NULL,'GOOD','2017-12-05','WITH GLOVE BAG',NULL,'WAREHOUSE','CLASS 0 GLOVES',0,'false'),(25,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-903',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(26,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-904',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(27,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-905',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(28,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-906',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(29,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-907',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(30,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-908',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(31,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-909',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(32,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-910',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(33,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-911',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(34,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-912',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(35,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-913',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(36,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-914',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(37,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-915',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(38,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-916',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(39,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-917',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(40,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-918',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(41,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-919',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(42,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-920',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(43,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-921',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(44,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFC-922',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(45,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFS-013',NULL,'GOOD','2017-07-15',NULL,NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(46,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFS-009',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false'),(47,'SALISBURY/NORTH','TYPE 1 CLASS E','HVFS-002',NULL,'INCOMPLETED','2017-07-15','NO FACE SHIELD',NULL,'WAREHOUSE','CLASS 0 FACE SHIELD',0,'false');
/*!40000 ALTER TABLE `assignmentoftoolsbytrucks` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ccalls`
--

LOCK TABLES `ccalls` WRITE;
/*!40000 ALTER TABLE `ccalls` DISABLE KEYS */;
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
  `Street` varchar(200) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Company` varchar(45) DEFAULT NULL,
  `Region` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB AUTO_INCREMENT=1004 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1000,'DEFAULT','DEFAULT','DEFAULT','IT','0000000000','NO_REPLY@APPSAXISRG.COM','DEFAULT','DEFAULT','DEFAULT','00000','USA','AXISRG','A');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contracts`
--

DROP TABLE IF EXISTS `contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contracts` (
  `ContractId` int(11) NOT NULL AUTO_INCREMENT,
  `Comments` varchar(100) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `File` varchar(150) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `RfqId` int(11) DEFAULT NULL,
  `RversionId` int(11) DEFAULT NULL,
  `UserId` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`ContractId`),
  KEY `Ffqid_contracts_idx` (`RfqId`),
  CONSTRAINT `RfqId_contracts` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contracts`
--

LOCK TABLES `contracts` WRITE;
/*!40000 ALTER TABLE `contracts` DISABLE KEYS */;
/*!40000 ALTER TABLE `contracts` ENABLE KEYS */;
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
  `FarmName` varchar(200) NOT NULL,
  `StreetAddress` varchar(200) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Manufacture` varchar(45) DEFAULT NULL,
  `Platform` varchar(200) DEFAULT NULL,
  `Convertor` varchar(45) DEFAULT NULL,
  `NumberTowers` int(11) DEFAULT NULL,
  `NumberMws` float DEFAULT NULL,
  `Gearbox` varchar(45) DEFAULT NULL,
  `ClientId` int(11) DEFAULT NULL,
  `Panel` varchar(45) DEFAULT NULL,
  `GeoLong` float DEFAULT NULL,
  `GeoLat` float DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FarmId`),
  KEY `ClientId_idx` (`ClientId`),
  CONSTRAINT `ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`ClientId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1009 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farms`
--

LOCK TABLES `farms` WRITE;
/*!40000 ALTER TABLE `farms` DISABLE KEYS */;
INSERT INTO `farms` VALUES (1005,'0','AXIS TEST','CARRETERA PUERTO JUAREZ CHETUMAL','PUERTO MORELOS','QROO','32000','MEXICO','AXIONA','PLATTFORM 1','CONVERTOR 1',1,2.3,'GEARBOX 1',1000,NULL,20.9761,-86.8613,'NO_REPLY@APPSAXISRG.COM');
/*!40000 ALTER TABLE `farms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fieldoperationstechs`
--

DROP TABLE IF EXISTS `fieldoperationstechs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fieldoperationstechs` (
  `FieldOperationsId` int(11) NOT NULL AUTO_INCREMENT,
  `TechApproval` varchar(45) DEFAULT NULL,
  `PerDiemAdvance` int(3) DEFAULT NULL,
  `TechApprovalAdv` varchar(45) DEFAULT NULL,
  `CertificatesStatus` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `RejectionComment` varchar(200) DEFAULT NULL,
  `ARejectionComment` varchar(200) DEFAULT NULL,
  `PurchaseOrderId` int(11) DEFAULT NULL,
  `TechId` int(11) DEFAULT NULL,
  PRIMARY KEY (`FieldOperationsId`),
  KEY `PurchesId_idx` (`PurchaseOrderId`),
  KEY `TechId_idx` (`TechId`),
  CONSTRAINT `PurchaseOrderId` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `purchaseorders` (`PurchaseOrderId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `TechId` FOREIGN KEY (`TechId`) REFERENCES `teches` (`TechId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fieldoperationstechs`
--

LOCK TABLES `fieldoperationstechs` WRITE;
/*!40000 ALTER TABLE `fieldoperationstechs` DISABLE KEYS */;
/*!40000 ALTER TABLE `fieldoperationstechs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flights`
--

DROP TABLE IF EXISTS `flights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flights` (
  `FlightId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) DEFAULT NULL,
  `DataFlight` varchar(150) DEFAULT NULL,
  `CostFlight` double DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `RejectionComment` varchar(200) DEFAULT NULL,
  `FieldOperationsId` int(11) DEFAULT NULL,
  PRIMARY KEY (`FlightId`),
  KEY `FieldOperationsTechsId_idx` (`FieldOperationsId`),
  CONSTRAINT `FFieldOperationsTechsId` FOREIGN KEY (`FieldOperationsId`) REFERENCES `fieldoperationstechs` (`FieldOperationsId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flights`
--

LOCK TABLES `flights` WRITE;
/*!40000 ALTER TABLE `flights` DISABLE KEYS */;
/*!40000 ALTER TABLE `flights` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kitcomponents`
--

DROP TABLE IF EXISTS `kitcomponents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kitcomponents` (
  `KitComponentsId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(60) DEFAULT NULL,
  `ComponentType` varchar(45) DEFAULT NULL,
  `ToolKitsId` int(11) DEFAULT NULL,
  PRIMARY KEY (`KitComponentsId`),
  KEY `ToolKitsId_key_idx` (`ToolKitsId`),
  CONSTRAINT `ToolKitsId_key` FOREIGN KEY (`ToolKitsId`) REFERENCES `toolkits` (`ToolKitsId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kitcomponents`
--

LOCK TABLES `kitcomponents` WRITE;
/*!40000 ALTER TABLE `kitcomponents` DISABLE KEYS */;
/*!40000 ALTER TABLE `kitcomponents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacterers`
--

DROP TABLE IF EXISTS `manufacterers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manufacterers` (
  `ManufactereId` int(11) NOT NULL AUTO_INCREMENT,
  `ManufacturerName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ManufactereId`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacterers`
--

LOCK TABLES `manufacterers` WRITE;
/*!40000 ALTER TABLE `manufacterers` DISABLE KEYS */;
INSERT INTO `manufacterers` VALUES (1,'AAER'),(2,'Acciona'),(3,'Aeroman'),(4,'Aeronautica'),(5,'Alstom'),(6,'Atlantic Orient'),(7,'Bergey Windpower'),(8,'CCWE'),(9,'Clipper'),(10,'Daewoo Dewind'),(11,'Danwin'),(12,'DES'),(13,'Eastern Wind Power'),(14,'Elecon'),(15,'Endurance'),(16,'Enertech'),(17,'EWT'),(18,'Fuhrländer'),(19,'Gamesa'),(20,'GE'),(21,'Goldwind'),(22,'HHI'),(23,'Jonica Impianti'),(24,'Kenersys'),(25,'Kenetech'),(26,'Leitwind'),(27,'Mitsubishi'),(28,'Nordex'),(29,'Nordic'),(30,'Northern Power Systems'),(31,'Pioneer'),(32,'PowerWind'),(33,'Renewegy'),(34,'RRB Energy'),(35,'Sany'),(36,'Senvion'),(37,'SHI'),(38,'Siemens'),(39,'Sinovel'),(40,'Siva'),(41,'Suzlon'),(42,'Turbowinds'),(43,'Unison'),(44,'Vanguard'),(45,'Vensys'),(46,'Vergnet'),(47,'Vestas'),(48,'Wincon'),(49,'Wind Energy Solutions'),(50,'Windmaster'),(51,'Windmatic');
/*!40000 ALTER TABLE `manufacterers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `platforms`
--

DROP TABLE IF EXISTS `platforms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `platforms` (
  `PlatformId` int(11) NOT NULL AUTO_INCREMENT,
  `ManufacturerName` varchar(45) DEFAULT NULL,
  `PlatformName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PlatformId`)
) ENGINE=InnoDB AUTO_INCREMENT=269 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `platforms`
--

LOCK TABLES `platforms` WRITE;
/*!40000 ALTER TABLE `platforms` DISABLE KEYS */;
INSERT INTO `platforms` VALUES (96,'AAER','A1500-77'),(97,'AAER','A1500-70'),(98,'Acciona','AW3000-116'),(99,'Acciona','AW3000-109'),(100,'Acciona','AW1500-82'),(101,'Acciona','AW1500-77'),(102,'Aeroman','Aeroman 14.8'),(103,'Aeronautica','Aeronautic 47'),(104,'Aeronautica','A54-750'),(105,'Alstom','ECO100'),(106,'Alstom','ECO86'),(107,'Atlantic Orient','AOC 15/50'),(108,'Bergey Windpower','XL50'),(109,'CCWE','CCWE-3600D/115'),(110,'Clipper','Liberty 2.5-96'),(111,'Clipper','Liberty 2.5-93'),(112,'Clipper','Liberty 2.5-89'),(113,'Daewoo Dewind','D8.2'),(114,'Daewoo Dewind','D9.2'),(115,'Danwin','23 E2'),(116,'Danwin','24/160'),(117,'DES','Northwind 100'),(118,'Eastern Wind Power','Sky Farm 50kW VAWT'),(119,'Elecon','T600-48'),(120,'Elecon','T600-48DS'),(121,'Endurance','E3120 50kW'),(122,'Enertech','E48'),(123,'Enertech','Enertech 44/40'),(124,'EWT','DW54-900'),(125,'EWT','DW52-750'),(126,'EWT','DW52-900'),(127,'Fuhrländer','FL1500'),(128,'Fuhrländer','FL100'),(129,'Fuhrländer','FL250'),(130,'Fuhrländer','FL2500/90'),(131,'Gamesa','G97-2.0'),(132,'Gamesa','G90-2.0'),(133,'Gamesa','G52-850'),(134,'Gamesa','G87-2.0'),(135,'Gamesa','G58-850'),(136,'Gamesa','G114-2.0'),(137,'Gamesa','G83-2.0'),(138,'Gamesa','G80-2.0'),(139,'GE','GE 1.6 XLE'),(140,'GE','GE 1.5 SLE'),(141,'GE','GE 1.85-82.5'),(142,'GE','GE 1.6-100'),(143,'GE','GE 1.5 XLE'),(144,'GE','GE 1.85-87'),(145,'GE','Z-50'),(146,'GE','GE 1.68-82.5'),(147,'GE','GE 1.5 S'),(148,'GE','GE 2.85-103'),(149,'GE','GE 2.5-120'),(150,'GE','GE 1.7-100'),(151,'GE','GE 1.7-103'),(152,'GE','Z-40'),(153,'GE','GE 1.5SL'),(154,'GE','1.5s (Enron)'),(155,'GE','GE 1.5 SE'),(156,'GE','GE 2.5-100'),(157,'GE','GE 1.5 SL'),(158,'GE','Z-48'),(159,'Goldwind','GW82'),(160,'Goldwind','GW87'),(161,'Goldwind','GW100-2.5'),(162,'Goldwind','GW77'),(163,'HHI','HQ2000'),(164,'HHI','HQ1650'),(165,'Jonica Impianti','JIMP25'),(166,'Kenersys','K100'),(167,'Kenetech','56-100'),(168,'Leitwind','LTW77-1.5'),(169,'Mitsubishi','MWT62/1.0'),(170,'Mitsubishi','MWT-1000'),(171,'Mitsubishi','MWT92/2.4'),(172,'Mitsubishi','MWT-600'),(173,'Mitsubishi','MWT95/2.4'),(174,'Mitsubishi','MWT-250'),(175,'Mitsubishi','MWT102/2.4'),(176,'Mitsubishi','MWT100/2.4'),(177,'Nordex','N54/1000'),(178,'Nordex','N43/600'),(179,'Nordex','N90/2300'),(180,'Nordex','N60/1300'),(181,'Nordex','N100/2500'),(182,'Nordex','N90/2500 LS'),(183,'Nordex','N90/2500 HS'),(184,'Nordex','N117/2400'),(185,'Nordic','N1000'),(186,'Northern Power Systems','NPS 100'),(187,'Northern Power Systems','NPS Prototype'),(188,'Pioneer','P-1650'),(189,'PowerWind','PowerWind 56'),(190,'Renewegy','VP-20'),(191,'RRB Energy','PS-600'),(192,'Sany','SE100/2.0'),(193,'Sany','SE93/2.0'),(194,'Sany','SE8720IIIE'),(195,'Senvion','MM92'),(196,'SHI','SHI2.5-100'),(197,'Siemens','B19/120'),(198,'Siemens','SWT2.3-101'),(199,'Siemens','B37/450'),(200,'Siemens','SWT2.3-93'),(201,'Siemens','SWT3.0-101'),(202,'Siemens','SWT2.3-108'),(203,'Siemens','B62/1300'),(204,'Siemens','SWT-2.3'),(205,'Siemens','B15/65'),(206,'Siemens','SWT3.0-113'),(207,'Siemens','B23/150'),(208,'Sinovel','SL 3000/90'),(209,'Sinovel','SL 1500/82'),(210,'Siva','250/50'),(211,'Suzlon','S88-2.1'),(212,'Suzlon','S64-1.25'),(213,'Suzlon','S95-2.1'),(214,'Suzlon','S97-2.1'),(215,'Turbowinds','T600-48'),(216,'Turbowinds','T400-34'),(217,'Unison','U54'),(218,'Vanguard','95T'),(219,'Vensys','Vensys 70'),(220,'Vensys','Vensys 82'),(221,'Vensys',' Vensys 77'),(222,'Vergnet','MP-R'),(223,'Vestas','V27-225'),(224,'Vestas','M108/19'),(225,'Vestas','NM54/950'),(226,'Vestas','NM52/900'),(227,'Vestas','NTK500/37'),(228,'Vestas','V42'),(229,'Vestas','V47-660'),(230,'Vestas','NM48/750'),(231,'Vestas','V100-1.8'),(232,'Vestas','V82-1.65'),(233,'Vestas','NM82/1650'),(234,'Vestas','V44-600'),(235,'Vestas','NTK65/17'),(236,'Vestas','NM44/750'),(237,'Vestas','W250/29'),(238,'Vestas','V80-1.8'),(239,'Vestas','NM950/54'),(240,'Vestas','M700/225'),(241,'Vestas','NM72c/1500'),(242,'Vestas','V17'),(243,'Vestas','V39-500'),(244,'Vestas','V27'),(245,'Vestas','V20'),(246,'Vestas','V15/65'),(247,'Vestas','V90-3.0'),(248,'Vestas','V100-2.0'),(249,'Vestas','V42-600'),(250,'Vestas','V90-1.8'),(251,'Vestas','V112-3.3'),(252,'Vestas','NM72/1650'),(253,'Vestas','M65/13'),(254,'Vestas','NedWind'),(255,'Vestas','V17E'),(256,'Vestas','V17 '),(257,'Vestas','V112-3.0'),(258,'Vestas','V80-2.0'),(259,'Vestas','NM82/1500'),(260,'Vestas','V110-2.0'),(261,'Vestas','V15'),(262,'Wincon','W200'),(263,'Wincon','W99XT'),(264,'Wind Energy Solutions','WES 250'),(265,'Windmaster','Windmaster-211'),(266,'Windmatic','17S'),(267,'Windmatic','200'),(268,'Windmatic','15S');
/*!40000 ALTER TABLE `platforms` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchaseorders`
--

LOCK TABLES `purchaseorders` WRITE;
/*!40000 ALTER TABLE `purchaseorders` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchaseorders` ENABLE KEYS */;
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
  `PricePerUnit` double(11,4) DEFAULT NULL,
  `NUnits` double(11,4) DEFAULT NULL,
  `HourlyRate` double(11,4) DEFAULT NULL,
  `Technicians` double(11,4) DEFAULT NULL,
  `WeeklyHours` double(11,4) DEFAULT NULL,
  `Weeks` double(11,4) DEFAULT NULL,
  `Total` double(11,4) DEFAULT NULL,
  `RversionId` int(11) DEFAULT NULL,
  `TypeR` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuoteId`),
  KEY `RversionId_idx` (`RversionId`),
  CONSTRAINT `RversionId` FOREIGN KEY (`RversionId`) REFERENCES `rversions` (`RversionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=481 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quotes`
--

LOCK TABLES `quotes` WRITE;
/*!40000 ALTER TABLE `quotes` DISABLE KEYS */;
/*!40000 ALTER TABLE `quotes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quoteslist`
--

DROP TABLE IF EXISTS `quoteslist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quoteslist` (
  `QuotesListId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) DEFAULT NULL,
  `Um` varchar(45) DEFAULT NULL,
  `Cost` double(11,4) DEFAULT NULL,
  `Price` double(11,4) DEFAULT NULL,
  PRIMARY KEY (`QuotesListId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quoteslist`
--

LOCK TABLES `quoteslist` WRITE;
/*!40000 ALTER TABLE `quoteslist` DISABLE KEYS */;
INSERT INTO `quoteslist` VALUES (1,'RATE STANDARD PER TECH','HOURLY',0.0000,75.0000),(2,'RATE CUSTOM PER TECH','HOURLY',0.0000,100.0000),(3,'RATE','FIXED',0.0000,0.0000),(4,'MOBILIZATION STANDARD IN','TECH',0.0000,750.0000),(5,'MOBILIZATION STANDARD OUT','TECH',0.0000,750.0000),(6,'MOBILIZATION CUSTOM IN','TECH',0.0000,0.0000),(7,'MOBILIZATION CUSTOM OUT','TECH',0.0000,0.0000);
/*!40000 ALTER TABLE `quoteslist` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=1081 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfqs`
--

LOCK TABLES `rfqs` WRITE;
/*!40000 ALTER TABLE `rfqs` DISABLE KEYS */;
/*!40000 ALTER TABLE `rfqs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('1','Administrator'),('2','Technician'),('3','FieldManager'),('4','AFManager'),('5','EHSManager'),('6','SalesManager'),('7','RSourceManager'),('8','AAManager'),('9','Salesman');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
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
  `TermsandConditions` longtext,
  `MIPricePerTech` double(11,3) DEFAULT NULL,
  `MITechnicians` double(11,3) DEFAULT NULL,
  `MITotal` double(11,3) DEFAULT NULL,
  `MOPricePerTech` double(11,3) DEFAULT NULL,
  `MOTechnicians` double(11,3) DEFAULT NULL,
  `MOTotal` double(11,3) DEFAULT NULL,
  PRIMARY KEY (`RversionId`),
  KEY `Rfq_idx` (`RfqId`),
  KEY `ScopeWorkId_idx` (`ScopeWorkId`),
  CONSTRAINT `RfqId` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ScopeWorkId` FOREIGN KEY (`ScopeWorkId`) REFERENCES `scopeworks` (`ScopeWorkId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=139 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rversions`
--

LOCK TABLES `rversions` WRITE;
/*!40000 ALTER TABLE `rversions` DISABLE KEYS */;
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
INSERT INTO `scopeworks` VALUES (1,'SERVICES','OEM SUPPORT'),(2,'SERVICES','LARGE CORRECTIVE CONVERTER'),(3,'SERVICES','LARGE CORRECTIVE GEARBOX'),(4,'SERVICES','LARGE CORRECTIVE GENERATOR'),(5,'SERVICES','LARGE CORRECTIVE TRANSFORMER'),(6,'SERVICES','LARGE CORRECTIVE OPEN'),(7,'SERVICES','PREVENTIVE MAINTENANCE 3 MONTH'),(8,'SERVICES','PREVENTIVE MAINTENANCE 6 MONTH'),(9,'SERVICES','PREVENTIVE MAINTENANCE 12 MONTH'),(10,'SERVICES','PREVENTIVE MAINTENANCE TRANSFORMER'),(11,'SERVICES','PREVENTIVE MAINTENANCE OPEN'),(12,'SERVICES','DESIGN MODIFICATION'),(13,'SERVICES','INSPECTION'),(14,'SERVICES','OPEN'),(15,'CONSTRUCT','TECHNICAL ADVISORS'),(16,'CONSTRUCT','QA / QC'),(17,'CONSTRUCT','BLADE'),(18,'CONSTRUCT','NCR'),(19,'CONSTRUCT','LOGISTICS'),(20,'CONSTRUCT','COMMISION'),(21,'CONSTRUCT','OPEN');
/*!40000 ALTER TABLE `scopeworks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shippings`
--

DROP TABLE IF EXISTS `shippings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shippings` (
  `PurchaseOrderId` int(11) NOT NULL,
  `PackingList` text,
  `AirwayBill` varchar(45) DEFAULT NULL,
  `Cost` double DEFAULT '0',
  `Comment` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`PurchaseOrderId`),
  CONSTRAINT `F_Shipping` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `purchaseorders` (`PurchaseOrderId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shippings`
--

LOCK TABLES `shippings` WRITE;
/*!40000 ALTER TABLE `shippings` DISABLE KEYS */;
/*!40000 ALTER TABLE `shippings` ENABLE KEYS */;
UNLOCK TABLES;

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
  `EmailCompany` varchar(200) DEFAULT NULL,
  `LocalAirport` varchar(100) DEFAULT NULL,
  `SSN` int(11) DEFAULT NULL,
  `DriveLicence` varchar(100) DEFAULT NULL,
  `PayRate` double(6,3) DEFAULT NULL,
  `DayliPerDiem` double(6,3) DEFAULT NULL,
  `Medical` varchar(100) DEFAULT NULL,
  `Passport` int(11) DEFAULT NULL,
  `MaritalStatus` varchar(45) DEFAULT NULL,
  `Children` int(11) DEFAULT NULL,
  `Education` varchar(100) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `POAsigned` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`TechId`)
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teches`
--

LOCK TABLES `teches` WRITE;
/*!40000 ALTER TABLE `teches` DISABLE KEYS */;
INSERT INTO `teches` VALUES (22,'','Ross ','Walker','','6420 Trout Creek Ridge Rd','Parkdale','OR','97041','United States','5418064070','walkerross15@gmail.com','rwalker@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(23,'','Joseph','Yelverton','','3876 Riviera Dr','San Diego','CA','92109','United States','8586251521','joecrawford1012@gmail.com','jyelvington@axisrg.com','',0,'0',20.000,100.000,'0',0,'4',0,'','BANCH',''),(24,'','Raul ','Felix','','906 W Boston','Edinburg','TX ','78541','United States','9563779886','RaL1414@gmail.com','rfelix@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(25,'','Erick Eduardo ','Benavides','','204 W. Walnut St','Granger','TX ','76530','United States','5123654954','Ebenavides36@gmail.com','ebenavides@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(26,'','Martin','Benavides','','419 Laimble St','Bartlett','TX','76511','United States','2545981648','benavides1018@gmail.com','mbenivedes@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(27,'','Edward ','Kraku','','9452 Lansford St','Philadelphia','PA','19114','United States','2672052737','','ekraku@axisrg.com','',0,'0',25.000,100.000,'0',0,'4',0,'','BANCH',''),(28,'','Phillip ','Malone','','21946 Reading Dr','Anderson','CA','96007','United States','8187211975','maxrbdavis@gmail.com','pmalone@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(29,'','Garrett','Fitterer','','420 S 4th St','Grand Forks','ND','58201','United States','7012909131','Garrett_fitterer@hotmail.com','gfitterer@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(30,'','Richard ','Ben Muniz','','2624 Mill Creek Drive','Pasadena','TX ','77503','United States','8324178750','Ajcvr2000@gmail.com','rmuniz@axisrg.com','',0,'0',27.000,100.000,'0',0,'4',0,'','BANCH',''),(31,'','Zoawnty ','Zeon','','208 Third Avenue Unit 1','Cranston','RI','2910','United States','4015166773','zeon442@gmail.com','zzeon@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(32,'','Francisco ','Benavides','','837 W Elm St','Bartlett','TX ','76511','United States','5123654954','benavidezfrancisco027@yahoo.com','fbenavidez@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(33,'','Willie','Karwo ','','1710 High St #301','Des Moines','IA','50309','United States','3127091849','Wkarwo@gmail.com','wkarwo@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(34,'','Kerry ','De La Miya','','1216 Chippawa Dr','Union City','MI','49084','United States','5176770306','kerrybrooks36@Gmail.com','kdelamiya@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(35,'','Dusty ','Nyonee','','822 16th Street','Perry','IA','50220','United States','5153573959','dustydnyonee79@outlook.com','dnyonee@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(36,'','Robert ','Butler - NFPA','','2610 Ridge Hollow Drive','Houston','TX ','77067','United States','9798771832','jets_over_u@yahoo.com','rbutler@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(37,'','Baily ','Meyer Martins','','1400 Morniingside Drive','Freeport','IL','61032','United States','8152913153','baily1400@gmail.com','bmartins@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(38,'','Alice','Antil Wierciak','','30648 Sheridan St','Garden City','MI ','48135','United States','3137290764','aliceantil@gmail.com','aantil@axisrg.com','',0,'0',26.000,100.000,'0',0,'4',0,'','BANCH',''),(39,'','David ','Chavez','','209 Berger Lane','Toppenish','WA','98948','United States','2027185886','Chavez_d49@yahoo.com','dchavez@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(40,'','Jory ','Wilson','','6302 Seeger Trail','Houston ','TX ','77066','United States','8323316982','Jorywilson12@gmail.com','jwilson@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(41,'','Daniel ','Gonzalez','','1002 Katy Gap Road #610','Katy','TX ','77494','United States','7865853757','Gonper04@hotmail.com','dgonzalez@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(42,'','Joshua ','Cody Parks','','1806 Webb Rd','Salisbury','NC','28146','United States','7042242491','Joshuaparks12@hotmail.com','jparks@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(43,'','Chad ','Mcdowell','','22 Pleasant Grove Ct','Corinth','MS','38834','United States','6624153372','mcdowellchad44@yahoo.com','cmcdowell@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(44,'','Adrian ','Delgado','','10019 Cheryl St','Manvel','TX','77578','United States','8328583910','adriandelgado74@yahoo.com','adelgado@axisrg.com','',0,'0',26.000,116.000,'0',0,'4',0,'','BANCH',''),(45,'','Agrapino ','Delgado','','5340 West 30th Pl','Cicero','IL','60804','United States','3615167738','pinoad1967@gmail.com','agdelgado@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(46,'','Forrest ','Ferguson','','4401 60th Street','Oklahoma City','OK','73112','United States','4056239951','mobius_1@cox.net','fferguson@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(47,'','Joseph ','Renard','','14628 South Blanca Ave','Yuma','AZ','85365','United States','9284466749','renardje@hotmail.com','jrenard@axisrg.com','',0,'0',26.000,90.000,'0',0,'4',0,'','BANCH',''),(48,'','Victor ','Turca','','1020 Woodland St','Channelview','TX','77530','United States','8325098506','vcturca_23@yahoo.com','vturca@axisrg.com','',0,'0',26.000,116.000,'0',0,'4',0,'','BANCH',''),(49,'','Sevelee K. ','Kabbah','','7235 Bradford Rd.','Upper Darby','PA','19082','United States','6109316275','seveleekabbah@gmail.com','skabbah@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(50,'','Mark ','Weyant','','820 E. Boundary Ave','Chicago','IL','17403','United States','3125052577','markaweyant@yahoo.com','mweyant@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(51,'','Dillon','Rooney','','262 Thunder Circle','Bensalem','PA','19020','United States','2676322289','Frodo519@gmail.com','drooney@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(52,'','Rashaan (Ray) ','Rose','','1941 Vivian Road','Monroe','MI','48162','United States','7346212170','Rashaan125@gmail.com','rrose@axisrg.com','',0,'0',18.000,90.000,'0',0,'4',0,'','BANCH',''),(53,'','Jacob ','McCombs','','13229 CR 457','Hawley','TX','79605','United States','3257257256','Jmccombs922@Gmail.com','jakemccombs@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(54,'','Morris ','Brandon Davis','','229 Morace Drive','Vidalia','LA','71373','United States','3187194399','bdavis2447@yahoo.com','mbdavis@axisrg.com','',0,'0',26.000,100.000,'0',0,'4',0,'','BANCH',''),(55,'','Cheiron V. ','Themistocles I','','740 Shadow Lane','Kalispell','MT','59901','United States','6197563133','cheiron.themistocles@gmail.com','cthermistocles@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(56,'','Josh ','Etherington','','1651 Blackbart Ct','South Lake Tahoe','CA','96151','United States','5303149664','joshetherington530@gmail.com','jetheringnton@axisrg.com','',0,'0',24.000,110.000,'0',0,'4',0,'','BANCH',''),(57,'','Matt ','Boscole','','13640 SE Hwy 212 #9','Clackamas','OR','97015','United States','9712270706','bforboscole@gmail.com','mboscole@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(58,'','Bruno ','Ortega','','5117 Temple Dr','Amarillo','TX','79110','United States','4329354335','brntrg@yahoo.com','bortega@axisrg.com','',0,'0',30.000,116.000,'0',0,'4',0,'','BANCH',''),(59,'','Mario Humberto ','Pacheco','','3561 West  4th Street ','Yuma','AZ','85364','United States','9287237285','checom80@gmail.com','mpacheco@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(60,'','Ernest ','Rangel','','117 High Dr','Kerrville','TX','78028','United States','8309281135','mr2chang@yahoo.com','erangel@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(61,'','Robert L ','Davis Jr','','701 NE Chipman Road Apt A','Lee\'s  Summit','MO','64063','United States','8166162408','Robldavis07@gmail.com','rdavis@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(62,'','Robert ','Huggler','','299 CR 214','Bay City','TX ','77414','United States','9792855049','rob.huggler@gmail.com','rhuggler@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(63,'','John',' Nava','','116 East Bdwy','Portland','TX','78374','United States','3616335425','jetty-rat@hotmail.com','jnava@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(64,'','Jack',' Pacheco','','84540 Vera Cruz','Coachella','CA','92236','United States','7603976923','Jakndabx78@gmail.com','jpacheco@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(65,'','Chad Lovell ','Kurtz ','','2859 w keys in','Anaheim','CA','92804','United States','6619749757','Lovellk19@yahoo.com','ckurtz@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(66,'','Paul ','Tyler','','2302 Gable Ct','Rosamond','CA','93560','United States','6617541614','zulee727@me.com','ptyler@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(67,'','Roman ','Garcia','','2721 Ross Avenue','Waco','TX','76711','United States','2548558282','rgabriel254@gmail.com','rgarcia@axisrg.com','',0,'0',26.000,90.000,'0',0,'4',0,'','BANCH',''),(68,'','Coby ','Tyler Shelton','','70 Cinnamon Lane','San Angelo','TX ','76901','United States','3257030038','coby.shelton85@gmail.com','cshelton@axisrg.com','',0,'0',24.000,90.000,'0',0,'4',0,'','BANCH',''),(69,'','George','Tyler','','107 County Road 4017 PO Box 532','Chilton','TX','76632','United States','2293310887','tyler_george@yahoo.com','gtyler@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(70,'','Roger ','Lee Cockrell','','PO Box 1283','Glenrock','WY','82637','United States','3073155510','rogercockrell418@yahoo.com','rcockrell@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(71,'','Israel','Balzan','','21550 Provincial Boulevard','Katy','TX ','77450','United States','2819321497','zontrac@gmail.com','ibalzan@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(72,'','Thomas A ','Lindsey ','','1547 Parramore','Abilene','TX ','79601','United States','3257010089','Thomaslindsey37@yahoo.com','tlindsey@axisrg.com','',0,'0',21.000,35.000,'0',0,'4',0,'','BANCH',''),(73,'','James Ira','Curd III','','8065 State Highway 114','Jermyn','TX','76459','United States','9402291261','Trey.curd@gmail.com','jcurd@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(74,'','Anthony ','Arballo','','1855 W Main St #210','El Centro','CA','92243','United States','7602349789','aarballo@hotmail.com','aarballo@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(75,'','Carlos ','Garcia jr','','7911 Cool Springs Dr','San Antonio','TX','78254','United States','2105290710','cjg_25@hotmail.com','cgarcia@axisrg.com','',0,'0',26.000,90.000,'0',0,'4',0,'','BANCH',''),(76,'','Alex ','Van Denover','','8817 Quinault Dr NE','Olympia','WA','98516','United States','3605568941','avandenover@gmail.com','avandenover@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(77,'','Andrew ','Miramontes','','5714 Shaw St','San Diego','CA','92139','United States','6199319982','ar_miramontes@yahoo.com','amiramontes@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(78,'','Andrew ','Scheetz','','3180 Warley Road','Hemet','CA','92545','United States','5308598017','efbcbfg40@yahoo.com','ascheetz@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(79,'','Robert ','Brown','','13243 cardinal rd','Victorville','CA','92392','United States','7609003157','Robertbrown32@outlook.com','rbrown@axisrg.com','',0,'0',25.000,100.000,'0',0,'4',0,'','BANCH',''),(80,'','Justin ','Agee','','995 21st St SE','Salem','OR','97301','United States','5033027913','Justinkeitha@gmail.com','jagee@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(81,'','Dhavid ','Antunez Diaz','','1002 Katy Gap Road','Katy','TX ','77494','United States','3468142117','dhavidrantunezd@gmail.com','dantunez@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(82,'','Cesar ','Cervantes','','12814 Magic Dr','Houston','TX','77039','United States','2818444640','theonecez@yahoo.com','ccervantes@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(83,'','Eldridge ','Tensley','','118 Monroe Dr','Tuschumbia','AL','35674','United States','6626600208','t20et@yahoo.com','etinsley@axisrg.com','',0,'0',26.000,110.000,'0',0,'4',0,'','BANCH',''),(84,'','Ryan William ','Meyers','','500 N Pine','Newkirk','OK','74647','United States','5803627057','ryanmeyers1802@yahoo.com','rmeyers@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(85,'','Ivar ','Patrizi','','3826 Wake Forest Lane','Abilene','TX ','79602','United States','8062156745','impatrizi@gmail.com','ipatrizi@axisrg.com','',0,'0',23.000,90.000,'0',0,'4',0,'','BANCH',''),(86,'','Joel ','Mast','','5707 Saggio Road','Hastings','MI','49058','United States','2697623877','Joelamast@yahoo.com','jmast@axisrg.com','',0,'0',22.000,100.000,'0',0,'4',0,'','BANCH',''),(87,'','Timothy D ','Lowe','','15657 Strickler Ave','Eastpointe','MI','48021','United States','5865226475','Timothydlowe@gmail.com','tlowe@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(88,'','Stanton M. ','Kelley','','201 12th Ave NW','Pipestone','MN','56164','United States','9367762344','Stanton.m.kelley@outlook.com','skelley@axisrg.com','',0,'0',27.000,100.000,'0',0,'4',0,'','BANCH',''),(89,'','Grayson ','Spiegel','','3016 Phipps Court','Lafayette','IN','47909','United States','3136906198','grayspiegel@gmail.com','gspiegel@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(90,'','Dweh ','Freeman','','445 Labore Road # 302','St Paul','MN','55117','United States','6125325464','dfree132000@yahoo.com','dfreeman@axisrg.com','',0,'0',28.000,110.000,'0',0,'4',0,'','BANCH',''),(91,'','Nicholas Matthew ','Gonzalez','','5570 Mullings Crossing Road','Miles ','TX ','76861','United States','3252272147','nick.gonzalez90@gmail.com','ngonzalez@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(92,'','Anthony ','Liberty','','2465 riverside dr. 109','Trenton','MI','48183','United States','7347753114','Liberty_anthony@hotmail.com','aliberty@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(93,'','Grady Hardin ','Trantham','','238 Myers Lane','Mcminnville','TN','37110','United States','6612055792','Gtrantham22@yahoo.com','gtrantham@axisrg.com','',0,'0',21.000,100.000,'0',0,'4',0,'','BANCH',''),(94,'','Mitchell ','Taylor','','2201 4th Avenue','Dodge City','KS','67801','United States','8063404892','Taylormademitch@gmail.com','mtaylor@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(95,'','Julian','Curtis','','1527 Brendle Court','Virginia Beach','VA','23464','United States','7575106300','mr.workhorse@yahoo.com','jcurtis@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(96,'','Jesse (Jesus) ','Maldonado Pizano','','203 East Broderick PO BOX 20981041','Granada','CO','81041','United States','7196804641','Pizano.jesse@yahoo.com','jpizano@axisrg.com','',0,'0',20.000,90.000,'0',0,'4',0,'','BANCH',''),(97,'','Tim Eric ','Long','','58849 Delano Trail','Yucca Valley','CA','92284','United States','7609746121','longtim61@gmail.com','tlong@axisrg.com','',0,'0',26.000,90.000,'0',0,'4',0,'','BANCH',''),(98,'','Garret ','Giffin','','8825 McCourtney Rd','Lincon','CA','95648','United States','5303079617','gaggiffin@gmail.com','ggiffin@axisrg.com','',0,'0',19.000,90.000,'0',0,'4',0,'','BANCH',''),(99,'','Colby ','Moore','','1212 East 11th Ave ','Mount Dora','FL','32757','United States','3152192575','cmoore47@icloud.com','cmoore@axisrg.com','',0,'0',26.000,100.000,'0',0,'4',0,'','BANCH',''),(100,'','Daniel ','Zepeda','','1020 County Rd 479','El Campo','TX ','77437','United States','3617203921','danzepeda1994@gmail.com','dzepeda@axisrg.com','',0,'0',26.000,100.000,'0',0,'4',0,'','BANCH',''),(101,'','Jesse ','Bullock','','1717 Cooper Point Rd SW #L80','Olympia','WA','98502','United States','2069148935','jessebullock0991@hotmail.com','Jbullock@axisrg.com','',0,'0',21.000,90.000,'0',0,'4',0,'','BANCH',''),(102,'','Josh ','Guntenaar','','331 S Grant St','Wilkes-Barre','PA','18702','United States','3614551080','Jguntenaar@hotmail.com','Jguntenaar@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(103,'','Nicholas Ryan ','Fox','','1520 N.Beckley Ave #527','Dallas','TX ','75203','United States','7576186348','Foxnicholas24@gmail.com','Foxnicholas24@gmail.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(104,'','Terry ','Jones','','28802 Concho River Court','Spring','TX ','77386','United States','8322601768','t.25jones@yahoo.com','tjones@axisrg.com','',0,'0',25.000,90.000,'0',0,'4',0,'','BANCH',''),(105,'','Eric ','Jenkins','','1204 West Port Drive','Bakersfield','CA','95305','United States','6612203019','Eric_jenkins22@yahoo.com','ejenkins@axisrg.com','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(106,'','Lyle','Johnson','','9100 Mills Road','Houston ','TX ','77070','United States','5046570746','Johnsonlyle754@gmail.com','','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(107,'','Ryan ','Williams','','702 Misty Lea Lane','Houston','TX ','77090','United States','3463300218','ryanewilli19@gmail.com','','',0,'0',22.000,90.000,'0',0,'4',0,'','BANCH',''),(108,'','Dustin ','Hodge','','308 Leroy St','Montrose','MI','78028','United States','8106103968','dustinhodge89@yahoo.com','dhodge@axisrg.com','',0,'0',30.000,116.000,'0',0,'4',0,'','BANCH',''),(109,'','Joldry ','Romero','','1002 Katy Gap Road #327','Katy','TX ','77494','United States','8326618314','joldryromero@gmail.com','','',0,'0',0.000,0.000,'0',0,'4',0,'','BANCH','');
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfoaxis`
--

LOCK TABLES `techinfoaxis` WRITE;
/*!40000 ALTER TABLE `techinfoaxis` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfocims`
--

LOCK TABLES `techinfocims` WRITE;
/*!40000 ALTER TABLE `techinfocims` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfokits`
--

LOCK TABLES `techinfokits` WRITE;
/*!40000 ALTER TABLE `techinfokits` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `techinfoworks`
--

LOCK TABLES `techinfoworks` WRITE;
/*!40000 ALTER TABLE `techinfoworks` DISABLE KEYS */;
/*!40000 ALTER TABLE `techinfoworks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `toolkits`
--

DROP TABLE IF EXISTS `toolkits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `toolkits` (
  `ToolKitsId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(60) DEFAULT NULL,
  `KitType` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ToolKitsId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `toolkits`
--

LOCK TABLES `toolkits` WRITE;
/*!40000 ALTER TABLE `toolkits` DISABLE KEYS */;
/*!40000 ALTER TABLE `toolkits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tools`
--

DROP TABLE IF EXISTS `tools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tools` (
  `ToolId` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(60) DEFAULT NULL,
  `NumberItem` varchar(45) DEFAULT NULL,
  `ToolType` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ToolId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tools`
--

LOCK TABLES `tools` WRITE;
/*!40000 ALTER TABLE `tools` DISABLE KEYS */;
/*!40000 ALTER TABLE `tools` ENABLE KEYS */;
UNLOCK TABLES;

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
  `FullName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`TruckId`),
  KEY `F_TRUK_idx` (`TruckId`,`PurchaseOrderId`),
  KEY `FTruck_idx` (`PurchaseOrderId`),
  CONSTRAINT `FTruck` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `trucks` (`PurchaseOrderId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truckdetails`
--

LOCK TABLES `truckdetails` WRITE;
/*!40000 ALTER TABLE `truckdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `truckdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trucks`
--

DROP TABLE IF EXISTS `trucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trucks` (
  `PurchaseOrderId` int(11) NOT NULL,
  `NumberTrucks` int(11) DEFAULT '0',
  `RentalAgency` varchar(60) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `RejectionComment` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`PurchaseOrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trucks`
--

LOCK TABLES `trucks` WRITE;
/*!40000 ALTER TABLE `trucks` DISABLE KEYS */;
/*!40000 ALTER TABLE `trucks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userclaims`
--

DROP TABLE IF EXISTS `userclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userclaims`
--

LOCK TABLES `userclaims` WRITE;
/*!40000 ALTER TABLE `userclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `userclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlogins`
--

DROP TABLE IF EXISTS `userlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlogins`
--

LOCK TABLES `userlogins` WRITE;
/*!40000 ALTER TABLE `userlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES ('76956e3e-5207-4022-92d4-8a38f8b6fe2d','1'),('517dad22-0ab3-447d-a434-41dea882fcd6','3'),('a6df8de2-aa7e-4be5-8265-6aed1cde0723','3'),('d0c030bd-2cc0-4bd0-b953-84eddb376e99','4'),('6c4fd9d7-a48a-4d44-a166-6f4adf36c8bd','5'),('c07fcbb0-d858-4ecc-9d05-4ed95a545a7e','6'),('5e2bfb6c-444f-4083-9fab-53070afd83d0','7'),('b1e4da49-7b9c-4970-9225-15fd73b3046d','7'),('df786c12-4850-4389-975d-f4a193e3fa60','8'),('1f7b658b-dbf0-46a0-8f31-d716142c9023','9');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('1f7b658b-dbf0-46a0-8f31-d716142c9023','dhudson@axisrg.com',0,'AHsKvjrqY97qJHRcMiYAgGqrt36dJJ5JYjqRmoJB1D1CvvI/b7a9ljlBnQTC4/ZKow==','66ed82b8-aff4-4ace-abac-013254e428ff',NULL,0,0,NULL,1,0,'dhudson@axisrg.com'),('517dad22-0ab3-447d-a434-41dea882fcd6','iprice@axisrg.com',0,'AEtP8Mj6n8GIZdkgx+W2lUzdl1BFz54luEOQzq3zOqmQLp9+IZo5xWUabsTOb6Lb6Q==','52903e15-0d6e-43ba-8b78-1e46ed7d67aa',NULL,0,0,NULL,1,0,'iprice@axisrg.com'),('5e2bfb6c-444f-4083-9fab-53070afd83d0','gmurrieta@axisrg.com',0,'AC8eHYnMciPOdukOCBzFddKwCIudCr0+cFfEzLTJAOYVml78lEJx5B8VNbCpVPACZQ==','19195966-74bd-4d02-b7f0-c8a010815aa3',NULL,0,0,NULL,1,0,'gmurrieta@axisrg.com'),('6c4fd9d7-a48a-4d44-a166-6f4adf36c8bd','bberentson@axisrg.com',0,'AByYXSgHPWGgT3oxJlL3x6QnuaHVqwje/Ap73TfHtyTqk/oB/j8YKVywGm7YdubZOg==','dcb6f5d4-769c-444a-a517-ebb26d0f7598',NULL,0,0,NULL,1,0,'bberentson@axisrg.com'),('76956e3e-5207-4022-92d4-8a38f8b6fe2d','alavalle@axisrg.com',0,'AG+/co/jIglq8jHA6UUfUj6bS3lf1im3vMHr4LL85T+gPuUskwL2F27qHEKSCWB+qA==','78a138cc-15b2-40c9-bc6b-53d08cce721d',NULL,0,0,NULL,1,0,'alavalle@axisrg.com'),('a6df8de2-aa7e-4be5-8265-6aed1cde0723','gtapia@axisrg.com',0,'AA+X9hEQcKSfYnPSdYOIL4YuGnyBXSyef47i8+CJE94qNC9AXH7ImoKPiHUlId7ryw==','8351eb16-3cfc-4c6e-9651-80cfcafcc3b7',NULL,0,0,NULL,1,0,'gtapia@axisrg.com'),('b1e4da49-7b9c-4970-9225-15fd73b3046d','dalarcon@axisrg.com',0,'AO07jRmnvyOVgmsibYMLDtfmL7SjM++DggxUnDXZPYcXBszEM5MQXdav0fXKM9GnNg==','efc4fa53-0df7-4d0f-a06f-9b75127ddd02',NULL,0,0,NULL,1,0,'dalarcon@axisrg.com'),('c07fcbb0-d858-4ecc-9d05-4ed95a545a7e','ptattersfield@axisrg.com',0,'ANvTufkpbCsPk9wAZyxuxzjgzxh0U/ac687jZYorD0fshek60L7trL8EzVG5zEEe1w==','aacd276e-3161-4fc6-8b52-43affd380de9',NULL,0,0,NULL,1,0,'ptattersfield@axisrg.com'),('d0c030bd-2cc0-4bd0-b953-84eddb376e99','bmoore@axisrg.com',0,'ANdm2hwPOv06kgO6DNe5emNaD8jsVeJ3zWNtt0rFTgVfqghe+ie2vhWrSsX/35RXLw==','ede039d8-04e9-4612-8add-75c15159bb85',NULL,0,0,NULL,1,0,'bmoore@axisrg.com'),('df786c12-4850-4389-975d-f4a193e3fa60','rgallo@axisrg.com',0,'AO4CkhRIpFE/iAxOBXYnARiQUiiEOdxKiXf1XQXpzeZ1vpzT8jAuMH9X2gPeR30j2Q==','c24bcef4-e885-422f-9e46-04ae6db9f9fb',NULL,0,0,NULL,1,0,'rgallo@axisrg.com');
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

-- Dump completed on 2017-12-26 22:03:10
