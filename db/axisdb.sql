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
INSERT INTO `ccalls` VALUES (1,'2017-03-22','Prueba','Prueba','jose',NULL,1000),(2,'2017-03-30','eeee','eee','eeee',NULL,1001),(3,'2017-03-14','Prueba 34','eeee','eee',NULL,1001),(4,'2017-03-16','Prueba 34','eeee','eee',NULL,1001),(5,'2017-03-21','eeee','eee','eee',NULL,1001),(6,'2017-03-21','eee','eee','eee',NULL,1001),(7,'2017-03-21','eeee','eee','eee',NULL,1001),(8,'2017-03-14','Prueba nota','nota','nota',NULL,1000),(9,'2017-03-14','Prueba 55','Vista','Angel',NULL,1001);
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
  `StreetAddress` varchar(200) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=1005 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farms`
--

LOCK TABLES `farms` WRITE;
/*!40000 ALTER TABLE `farms` DISABLE KEYS */;
INSERT INTO `farms` VALUES (1001,'0','Prueba 10','Conocida','Conocida','Conocida','Conocida','Mexico','Conocida','Conocida','Conocida',4,4,'Conocida',1000,NULL),(1002,'1','Solar Farm','Merida','Merida','cono','ojoj','Mexico','como','como','comco',3,3,'como',1000,NULL),(1003,'2','Other Farm','lklk','lklkl','lklk','lk','lklk','kl','lk','lk',8,8,'ljlj',1000,NULL),(1004,'1','Solar Farm Merida','Calle 66 #570 x 21','Merida','Yucaten','97314','Mexico','GAMESA','Conocida',NULL,5,300,NULL,1000,NULL);
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
  `CostPerUnit` double(11,4) DEFAULT NULL,
  PRIMARY KEY (`QuoteId`),
  KEY `RversionId_idx` (`RversionId`),
  CONSTRAINT `RversionId` FOREIGN KEY (`RversionId`) REFERENCES `rversions` (`RversionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quotes`
--

LOCK TABLES `quotes` WRITE;
/*!40000 ALTER TABLE `quotes` DISABLE KEYS */;
INSERT INTO `quotes` VALUES (1,'fff','pza',90.0000,30.0000,2700.0000,32,12.0000),(2,'fff','pza',90.0000,34.0000,3060.0000,32,12.0000),(3,'fff','pza',234.0000,34.0000,7956.0000,32,12.0000),(4,'fff','pza',234.0000,35.0000,8190.0000,32,12.0000),(5,'descrip','pza',40.0000,50.0000,2000.0000,33,12.0000),(6,'descrip','pza',40.5000,31.0000,1255.5000,33,12.0000);
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
) ENGINE=InnoDB AUTO_INCREMENT=1046 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rfqs`
--

LOCK TABLES `rfqs` WRITE;
/*!40000 ALTER TABLE `rfqs` DISABLE KEYS */;
INSERT INTO `rfqs` VALUES (1028,'Open','Prueba 56',1001),(1029,'Open','Prueba 98',1001),(1030,'Open','Prueba 100',1001),(1031,'Open','Prueba 99',1001),(1032,'Open','Prueba 300',1001),(1033,'Open','Prueba 888',1001),(1034,'Open','Prueba solar 99',1002),(1035,'Open','Proyecto Paneles Merida',1004),(1036,'Open','Prueba 9000',1002),(1037,'Open','Paneles Solares Caucel',1004),(1038,'Open','Paneles solares Santa Fe',1004),(1039,'Open','Paneles Solares Caucel 2',1002),(1040,'Open','Prueba 18',1002),(1041,'Open','Prueba 990',1001),(1042,'Open','Prueba PAra TErms',1001),(1043,'Open','Prueba terms',1002),(1044,'Open','Prueba Terms other',1003),(1045,'Open','Prueba Other Farm',1003);
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
  `TermsandConditions` longtext,
  PRIMARY KEY (`RversionId`),
  KEY `Rfq_idx` (`RfqId`),
  KEY `ScopeWorkId_idx` (`ScopeWorkId`),
  CONSTRAINT `RfqId` FOREIGN KEY (`RfqId`) REFERENCES `rfqs` (`RfqId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ScopeWorkId` FOREIGN KEY (`ScopeWorkId`) REFERENCES `scopeworks` (`ScopeWorkId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rversions`
--

LOCK TABLES `rversions` WRITE;
/*!40000 ALTER TABLE `rversions` DISABLE KEYS */;
INSERT INTO `rversions` VALUES (25,1029,1,'0001-01-01 00:00:00','1','Nombre',0.000,'Open','PRueba 55',20,NULL),(26,1030,1,'2017-03-11 22:57:26','0','Descripcion de proyecto',0.000,'Open','Prueba de servicios',1,NULL),(27,1031,1,'2017-03-11 23:03:11','1','Prueba ',0.000,'Open','Prueba',16,NULL),(28,1034,1,'2017-03-12 11:10:27','0','Esta es una prueba',0.000,'Open','Prueba scope',3,NULL),(30,1037,1,'2017-03-13 21:35:05','0','Prueba paneles solares',0.000,'Open','Se realizan trabajos por 6 meses',8,NULL),(31,1041,1,'2017-03-14 14:20:15','0','prueba',0.000,'Open','Prueba',4,'<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">The above pricing is valid 30 days from the bid date and is subject to change upon notice. All the above pricing does not include state, federal, or any applicable taxes. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">1. In the event of inclement weather, or other events beyond the control of Axis Renewable Group Inc., where work is suspended, Axis Renewable Group Inc. will receive compensation for actual hours lost not to exceed 40 hours per Week $75.00/ hour (40 Hours/Week Guarantee).&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">2. No warranty or liability applies to any customer directed or managed work scope.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">3. Rates include workers equipped with Hand Tools commensurate with trade and Personal Protection Equipment including hard hat, safety glasses, gloves, safety shoes, and climbing harnesses, lanyards, and Lad-Safe.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">4. Payment is due within 30 days of invoice date. A finance charge of 2% per month will apply to overdue invoices starting at 60 days.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">5. Crew skill mix will be optimized by Axis Renewable Group, Inc. to control cost and ensure success.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">6. Each Axis Renewable Group, Inc. employee will be furnished with on-site safety orientation by a Customer Site Representative or Designee. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">7. Customer will be responsible for the proper disposal for all onsite generated waste, and will provide proper disposal containers for waste storing while onsite.</span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">8. Mobilization will occur upon Axis Renewable Group, Inc. receiving purchase order from Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">9. Axis Renewable Group, Inc. technicians usually work 6 weeks with one long weekend at home for R&amp;R. This can be changed with any agreements between Axis Renewable Group, Inc. and Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">10. Any changes to the scope of work should be discussed and approved by Nordex and the new scope of work should be clearly provided to Axis Renewable Group, Inc. and a new proposal and contract executed.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p align=\"center\" style=\"text-align:center;line-height:normal\">\r\n	<b><span lang=\"EN-US\" style=\"font-size:10.0pt\">The terms of this contract will be accepted by a purchase order or written acknowledgment to AxisRGG </span> </b></p>\r\n'),(32,1042,1,'2017-03-15 07:16:47','0','kkkk',0.000,'Open','PRuaba',4,'<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">The above pricing is valid 30 days from the bid date and is subject to change upon notice. All the above pricing does not include state, federal, or any applicable taxes. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">1. In the event of inclement weather, or other events beyond the control of Axis Renewable Group Inc., where work is suspended, Axis Renewable Group Inc. will receive compensation for actual hours lost not to exceed 40 hours per Week $75.00/ hour (40 Hours/Week Guarantee).&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">2. No warranty or liability applies to any customer directed or managed work scope.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">3. Rates include workers equipped with Hand Tools commensurate with trade and Personal Protection Equipment including hard hat, safety glasses, gloves, safety shoes, and climbing harnesses, lanyards, and Lad-Safe.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">4. Payment is due within 30 days of invoice date. A finance charge of 2% per month will apply to overdue invoices starting at 60 days.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">5. Crew skill mix will be optimized by Axis Renewable Group, Inc. to control cost and ensure success.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">6. Each Axis Renewable Group, Inc. employee will be furnished with on-site safety orientation by a Customer Site Representative or Designee. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">7. Customer will be responsible for the proper disposal for all onsite generated waste, and will provide proper disposal containers for waste storing while onsite.</span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">8. Mobilization will occur upon Axis Renewable Group, Inc. receiving purchase order from Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">9. Axis Renewable Group, Inc. technicians usually work 6 weeks with one long weekend at home for R&amp;R. This can be changed with any agreements between Axis Renewable Group, Inc. and Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">10. Any changes to the scope of work should be discussed and approved by Nordex and the new scope of work should be clearly provided to Axis Renewable Group, Inc. and a new proposal and contract executed.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p align=\"center\" style=\"text-align:center;line-height:normal\">\r\n	<b><span lang=\"EN-US\" style=\"font-size:10.0pt\">The terms of this contract will be accepted by a purchase order or written acknowledgment to AxisRGG </span> </b></p>\r\n'),(33,1043,1,'2017-03-15 23:10:11','0','Prueba',0.000,'Open','Prueba de modulo',5,'<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">The above pricing is valid 30 days from the bid date and is subject to change upon notice. All the above pricing does not include state, federal, or any applicable taxes. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">1. In the event of inclement weather, or other events beyond the control of Axis Renewable Group Inc., where work is suspended, Axis Renewable Group Inc. will receive compensation for actual hours lost not to exceed 40 hours per Week $75.00/ hour (40 Hours/Week Guarantee).&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">2. No warranty or liability applies to any customer directed or managed work scope.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">3. Rates include workers equipped with Hand Tools commensurate with trade and Personal Protection Equipment including hard hat, safety glasses, gloves, safety shoes, and climbing harnesses, lanyards, and Lad-Safe.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">4. Payment is due within 30 days of invoice date. A finance charge of 2% per month will apply to overdue invoices starting at 60 days.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">5. Crew skill mix will be optimized by Axis Renewable Group, Inc. to control cost and ensure success.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">6. Each Axis Renewable Group, Inc. employee will be furnished with on-site safety orientation by a Customer Site Representative or Designee. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">7. Customer will be responsible for the proper disposal for all onsite generated waste, and will provide proper disposal containers for waste storing while onsite. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">8. Mobilization will occur upon Axis Renewable Group, Inc. receiving purchase order from Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">9. Axis Renewable Group, Inc. technicians usually work 6 weeks with one long weekend at home for R&amp;R. This can be changed with any agreements between Axis Renewable Group, Inc. and Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">10. Any changes to the scope of work should be discussed and approved by Nordex and the new scope of work should be clearly provided to Axis Renewable Group, Inc. and a new proposal and contract executed.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p align=\"center\" style=\"text-align:center;line-height:normal\">\r\n	<b><span lang=\"EN-US\" style=\"font-size:10.0pt\">The terms of this contract will be accepted by a purchase order or written acknowledgment to AxisRGG </span> </b></p>\r\n'),(34,1045,1,'2017-03-16 07:21:23','0','Prueba other',0.000,'Open','Prueba',7,'<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">The above pricing is valid 30 days from the bid date and is subject to change upon notice. All the above pricing does not include state, federal, or any applicable taxes. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">1. In the event of inclement weather, or other events beyond the control of Axis Renewable Group Inc., where work is suspended, Axis Renewable Group Inc. will receive compensation for actual hours lost not to exceed 40 hours per Week $75.00/ hour (40 Hours/Week Guarantee).&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">2. No warranty or liability applies to any customer directed or managed work scope.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">3. Rates include workers equipped with Hand Tools commensurate with trade and Personal Protection Equipment including hard hat, safety glasses, gloves, safety shoes, and climbing harnesses, lanyards, and Lad-Safe.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">4. Payment is due within 30 days of invoice date. A finance charge of 2% per month will apply to overdue invoices starting at 60 days.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">5. Crew skill mix will be optimized by Axis Renewable Group, Inc. to control cost and ensure success.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">6. Each Axis Renewable Group, Inc. employee will be furnished with on-site safety orientation by a Customer Site Representative or Designee. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">7. Customer will be responsible for the proper disposal for all onsite generated waste, and will provide proper disposal containers for waste storing while onsite. </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">8. Mobilization will occur upon Axis Renewable Group, Inc. receiving purchase order from Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">9. Axis Renewable Group, Inc. technicians usually work 6 weeks with one long weekend at home for R&amp;R. This can be changed with any agreements between Axis Renewable Group, Inc. and Nordex.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p style=\"line-height:normal\">\r\n	<span lang=\"EN-US\" style=\"font-size:10.0pt\">10. Any changes to the scope of work should be discussed and approved by Nordex and the new scope of work should be clearly provided to Axis Renewable Group, Inc. and a new proposal and contract executed.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>\r\n<p align=\"center\" style=\"text-align:center;line-height:normal\">\r\n	<b><span lang=\"EN-US\" style=\"font-size:10.0pt\">The terms of this contract will be accepted by a purchase order or written acknowledgment to AxisRGG </span> </b></p>\r\n');
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

-- Dump completed on 2017-03-16 21:41:30
