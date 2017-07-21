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
INSERT INTO `userroles` VALUES ('72623156-9513-4195-8b76-ece439118b7a','1'),('a87ec9e9-0d64-40b3-b279-5818ef53c919','1'),('a6df8de2-aa7e-4be5-8265-6aed1cde0723','3'),('d0c030bd-2cc0-4bd0-b953-84eddb376e99','4'),('6c4fd9d7-a48a-4d44-a166-6f4adf36c8bd','5'),('c07fcbb0-d858-4ecc-9d05-4ed95a545a7e','6'),('5e2bfb6c-444f-4083-9fab-53070afd83d0','7'),('df786c12-4850-4389-975d-f4a193e3fa60','8'),('1f7b658b-dbf0-46a0-8f31-d716142c9023','9');
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
INSERT INTO `users` VALUES ('1f7b658b-dbf0-46a0-8f31-d716142c9023','dhudson@axisrg.com',0,'AHsKvjrqY97qJHRcMiYAgGqrt36dJJ5JYjqRmoJB1D1CvvI/b7a9ljlBnQTC4/ZKow==','66ed82b8-aff4-4ace-abac-013254e428ff',NULL,0,0,NULL,1,0,'dhudson@axisrg.com'),('5e2bfb6c-444f-4083-9fab-53070afd83d0','gmurrieta@axisrg.com',0,'AC8eHYnMciPOdukOCBzFddKwCIudCr0+cFfEzLTJAOYVml78lEJx5B8VNbCpVPACZQ==','19195966-74bd-4d02-b7f0-c8a010815aa3',NULL,0,0,NULL,1,0,'gmurrieta@axisrg.com'),('6c4fd9d7-a48a-4d44-a166-6f4adf36c8bd','bberentson@axisrg.com',0,'AByYXSgHPWGgT3oxJlL3x6QnuaHVqwje/Ap73TfHtyTqk/oB/j8YKVywGm7YdubZOg==','dcb6f5d4-769c-444a-a517-ebb26d0f7598',NULL,0,0,NULL,1,0,'bberentson@axisrg.com'),('71e7efde-c530-40ca-ac7c-ac7fa1d92cd5','admin@axisrg.com',0,'AETWcfCm4ohGcNrTP9xPwgfiv0nUPAKpyptpTatx+0Oq2pFRN0/CxnEActb5ELbXyw==','ac7a421d-5a64-4197-a6bb-5486bd2f99b9',NULL,0,0,NULL,1,0,'admin@axisrg.com'),('72623156-9513-4195-8b76-ece439118b7a','joseantonio@axis.com',0,'AA8DIQ+X6cmvGIOTc714AmsMSXe/hIJk0PCU60FC5oNSZIHaVljU7NfdTsCC5LLFlQ==','e09b335f-c049-430e-a067-be4a63af7521',NULL,0,0,NULL,1,0,'joseantonio@axis.com'),('a6df8de2-aa7e-4be5-8265-6aed1cde0723','gtapia@axisrg.com',0,'AA+X9hEQcKSfYnPSdYOIL4YuGnyBXSyef47i8+CJE94qNC9AXH7ImoKPiHUlId7ryw==','8351eb16-3cfc-4c6e-9651-80cfcafcc3b7',NULL,0,0,NULL,1,0,'gtapia@axisrg.com'),('a87ec9e9-0d64-40b3-b279-5818ef53c919','admin@axis.com',0,'APg6pELFw5Y6GDtnhfknaFsTSW6rxqx3Xz9Rsy6Mj8+AgJBIh3/UIuIUH5uMwGt99g==','988998cf-2d7b-48ce-9200-fbf431202072',NULL,0,0,NULL,1,0,'admin@axis.com'),('c07fcbb0-d858-4ecc-9d05-4ed95a545a7e','ptattersfield@axisrg.com',0,'ANvTufkpbCsPk9wAZyxuxzjgzxh0U/ac687jZYorD0fshek60L7trL8EzVG5zEEe1w==','aacd276e-3161-4fc6-8b52-43affd380de9',NULL,0,0,NULL,1,0,'ptattersfield@axisrg.com'),('d0c030bd-2cc0-4bd0-b953-84eddb376e99','bmoore@axisrg.com',0,'ANdm2hwPOv06kgO6DNe5emNaD8jsVeJ3zWNtt0rFTgVfqghe+ie2vhWrSsX/35RXLw==','ede039d8-04e9-4612-8add-75c15159bb85',NULL,0,0,NULL,1,0,'bmoore@axisrg.com'),('df786c12-4850-4389-975d-f4a193e3fa60','rgallo@axisrg.com',0,'AO4CkhRIpFE/iAxOBXYnARiQUiiEOdxKiXf1XQXpzeZ1vpzT8jAuMH9X2gPeR30j2Q==','c24bcef4-e885-422f-9e46-04ae6db9f9fb',NULL,0,0,NULL,1,0,'rgallo@axisrg.com');
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

-- Dump completed on 2017-07-21 10:49:38
