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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-31 13:36:20
